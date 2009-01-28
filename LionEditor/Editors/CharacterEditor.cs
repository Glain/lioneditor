/*
    Copyright 2007, Joe Davidson <joedavidson@gmail.com>

    This file is part of LionEditor.

    LionEditor is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    LionEditor is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with LionEditor.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace LionEditor
{
    public partial class CharacterEditor : UserControl
    {
        #region Fields

        private bool ignoreChanges = false;
        private Character character;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the character currently being edited
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Character Character
        {
            get { return character; }
            set
            {
                character = value;
                if( value != null )
                {
                    UpdateView();
                }
            }
        }

        #endregion

        #region Utilities

        /// <summary>
        /// Updates every control's data
        /// </summary>
        private void UpdateView()
        {
            if (character == null)
            {
                return;
            }
            this.SuspendLayout();
            // HACK: find a better way to do this
            ignoreChanges = true;
            unavailableCheckbox.Checked = character.OnProposition;
            rightHandCombo.SelectedIndex = (rightHandCombo.DataSource as List<Item>).IndexOf( character.RightHand );
            rightShieldCombo.SelectedIndex = (rightShieldCombo.DataSource as List<Item>).IndexOf( character.RightShield );
            leftHandCombo.SelectedIndex = (leftHandCombo.DataSource as List<Item>).IndexOf( character.LeftHand );
            leftShieldCombo.SelectedIndex = (leftShieldCombo.DataSource as List<Item>).IndexOf( character.LeftShield );
            accessoryCombo.SelectedIndex = (accessoryCombo.DataSource as List<Item>).IndexOf( character.Accessory );
            headCombo.SelectedIndex = (headCombo.DataSource as List<Item>).IndexOf( character.Head );
            bodyCombo.SelectedIndex = (bodyCombo.DataSource as List<Item>).IndexOf( character.Body );

            this.braverySpinner.Value = character.Bravery;
            this.experienceSpinner.Value = character.Experience;
            this.faithSpinner.Value = character.Faith;
            this.groupBox.Text = string.Format("{0}", character.Index + 1);
            this.classComboBox.SelectedItem = character.Job;
            this.movementCombo.SelectedIndex = (movementCombo.DataSource as List<Ability>).IndexOf( character.MovementAbility );
            this.reactionCombo.SelectedIndex = (reactionCombo.DataSource as List<Ability>).IndexOf( character.ReactAbility );
            this.supportCombo.SelectedIndex = (supportCombo.DataSource as List<Ability>).IndexOf( character.SupportAbility );
            this.nameTextBox.Text = character.Name;

            this.secondaryCombo.SelectedItem = character.SecondaryAction;
            this.spriteSetCombo.SelectedItem = character.SpriteSet;
            this.levelSpinner.Value = character.Level;
            this.zodiacComboBox.SelectedItem = character.ZodiacSign;
            this.genderComboBox.SelectedItem = character.Gender;

            UpdateSkillLabel();

            UpdateMove();
            UpdateJump();

            UpdateHPValue();
            UpdateMPValue();
            UpdateSPValue();
            UpdatePAValue();
            UpdateMAValue();
            UpdateRightWeapon();
            UpdateLeftWeapon();
            UpdateCEV();
            UpdateSEV();
            UpdateAEV();

            ignoreChanges = false;
            this.ResumeLayout();
        }

        /// <summary>
        ///  Updates the right weapon labels
        /// </summary>
        private void UpdateRightWeapon()
        {
            rightWeaponEvade.Text = string.Format( "/ {0:00}%", character.RBlockRate );
            rightWeaponPower.Text = string.Format( "{0:000}", character.RPower );
        }

        /// <summary>
        /// Updates the left weapon labels
        /// </summary>
        private void UpdateLeftWeapon()
        {
            leftWeaponEvade.Text = string.Format( "/ {0:00}%", character.LBlockRate );
            leftWeaponPower.Text = string.Format( "{0:000}", character.LPower );
        }

        /// <summary>
        /// Updates the CEV labels
        /// </summary>
        private void UpdateCEV()
        {
            cevPhysical.Text = string.Format( "{0:00}%", character.PhysicalCEV );
            cevMagic.Text = string.Format( "{0:00}%", character.MagicCEV );
        }

        /// <summary>
        /// Updates the SEV labels
        /// </summary>
        private void UpdateSEV()
        {
            sevMagic.Text = string.Format( "{0:00}%", character.MagicSEV );
            sevPhysical.Text = string.Format( "{0:00}%", character.PhysicalSEV );
        }

        /// <summary>
        /// Updates the AEV labels
        /// </summary>
        private void UpdateAEV()
        {
            aevMagic.Text = string.Format( "{0:00}%", character.MagicAEV );
            aevPhysical.Text = string.Format( "{0:00}%", character.PhysicalAEV );
        }

        /// <summary>
        /// Updates the move label and tooltip
        /// </summary>
        private void UpdateMove()
        {
            moveValueLabel.Text = character.Move.ToString();
            toolTip.SetToolTip( moveValueLabel, string.Format( "Base: {0}", character.Job.Move ) );
        }

        /// <summary>
        /// Updates the jump label and tooltip
        /// </summary>
        private void UpdateJump()
        {
            jumpValueLabel.Text = character.Jump.ToString();
            toolTip.SetToolTip( jumpValueLabel, string.Format( "Base: {0}", character.Job.Jump ) );
        }

        /// <summary>
        /// Updates the HP spinner's min, max, value, and tooltip
        /// </summary>
        private void UpdateHPValue()
        {
            hpSpinner.Minimum = 0;
            hpSpinner.Maximum = character.MaxHP;
            hpSpinner.Value = (character.HP > hpSpinner.Maximum) ? hpSpinner.Maximum : character.HP;
            hpSpinner.Minimum = character.HP - character.Job.ActualHP( character.RawHP );
            UpdateHPToolTip();
        }

        /// <summary>
        /// Updates the HP spinner's tooltip
        /// </summary>
        private void UpdateHPToolTip()
        {
            toolTip.SetToolTip( hpSpinner, 
                string.Format( "Raw: {0}\nBase: {1}\nMultiplier: x{2}\nBonus: +{3}", 
                character.RawHP, character.Job.ActualHP( character.RawHP ), character.HPMultiplier, character.HPBonus ) );
        }

        /// <summary>
        /// Updates the MP spinner's min, max, value, and tooltip
        /// </summary>
        private void UpdateMPValue()
        {
            mpSpinner.Minimum = 0;
            mpSpinner.Maximum = character.MaxMP;
            mpSpinner.Value = (character.MP > mpSpinner.Maximum) ? mpSpinner.Maximum : character.MP;
            mpSpinner.Minimum = character.MP - character.Job.ActualMP( character.RawMP );
            UpdateMPToolTip();
        }

        /// <summary>
        /// Updates the MP spinner's tooltip
        /// </summary>
        private void UpdateMPToolTip()
        {
            toolTip.SetToolTip( mpSpinner, 
                string.Format( "Raw: {0}\nBase: {1}\nBonus: +{2}", 
                character.RawMP, character.Job.ActualMP( character.RawMP ), character.MPBonus ) );
        }

        /// <summary>
        /// Updates the speed spinner's min, max, value, and tooltip
        /// </summary>
        private void UpdateSPValue()
        {
            speedSpinner.Minimum = 0;
            speedSpinner.Maximum = character.MaxSpeed;
            speedSpinner.Value = (character.Speed > speedSpinner.Maximum) ? speedSpinner.Maximum : character.Speed;
            speedSpinner.Minimum = character.Speed - character.Job.ActualSP( character.RawSP );
            UpdateSpeedToolTip();
        }

        /// <summary>
        /// Updates the speed spinner's tooltip
        /// </summary>
        private void UpdateSpeedToolTip()
        {
            toolTip.SetToolTip( speedSpinner, 
                string.Format( "Raw: {0}\nBase: {1}\nBonus: +{2}", 
                character.RawSP, character.Job.ActualSP( character.RawSP ), character.SpeedBonus ) );
        }

        /// <summary>
        /// Updates the magic attack spinner's min, max, value, and tooltip
        /// </summary>
        private void UpdateMAValue()
        {
            maSpinner.Minimum = 0;
            maSpinner.Maximum = character.MaxMA;
            maSpinner.Value = (character.MA > maSpinner.Maximum) ? maSpinner.Maximum : character.MA;
            maSpinner.Minimum = character.MA - character.Job.ActualMA( character.RawMA );
            UpdateMAToolTip();
        }

        /// <summary>
        /// Updates the magic attack spinner's tooltip
        /// </summary>
        private void UpdateMAToolTip()
        {
            toolTip.SetToolTip( maSpinner, 
                string.Format( "Raw: {0}\nBase: {1}\nBonus: +{2}", 
                character.RawMA, character.Job.ActualMA( character.RawMA ), character.MABonus ) );
        }

        /// <summary>
        /// Updates the physical attack spinner's min, max, value and tooltip
        /// </summary>
        private void UpdatePAValue()
        {
            paSpinner.Minimum = 0;
            paSpinner.Maximum = character.MaxPA;
            paSpinner.Value = (character.PA > paSpinner.Maximum) ? paSpinner.Maximum : character.PA;
            paSpinner.Minimum = character.PA - character.Job.ActualPA( character.RawPA );
            UpdatePAToolTip();
        }

        /// <summary>
        /// Updates the physical attack spinner's tooltip
        /// </summary>
        private void UpdatePAToolTip()
        {
            toolTip.SetToolTip( paSpinner, string.Format( "Raw: {0}\nBase: {1}\nBonus: +{2}", character.RawPA, character.Job.ActualPA( character.RawPA ), character.PABonus ) );
        }

        /// <summary>
        /// Updates the primary skill label
        /// </summary>
        private void UpdateSkillLabel()
        {
            skillTextLabel.Text = character.Job.Command;
        }

        #endregion

        #region Events

        private void SetupEvents()
        {
            // TODO: make these delegates not anonymous
            randomNameButton.Click +=
                delegate(object sender, EventArgs e)
                {
                    string s = character.GetRandomName();
                    nameTextBox.Text = s;
                    character.Name = s;
                    FireDataChangedEvent();
                };

            unavailableCheckbox.CheckedChanged +=
                delegate( object sender, EventArgs e )
                {
                    character.OnProposition = unavailableCheckbox.Checked;
                    FireDataChangedEvent();
                };
            jobButton.Click +=
                delegate( object sender, EventArgs e )
                {
                    JobsAndAbilitiesEditor editor = new JobsAndAbilitiesEditor( character.JobsAndAbilities, character.SpriteSet.Value );
                    editor.ShowDialog( this );
                    if( editor.ChangesMade )
                    {
                        FireDataChangedEvent();
                    }
                };
            classComboBox.SelectedIndexChanged +=
                delegate( object sender, EventArgs e )
                {
                    character.Job = (Class)classComboBox.SelectedItem;
                    ignoreChanges = true;
                    UpdateMove();
                    UpdateJump();
                    UpdateSPValue();
                    UpdateMAValue();
                    UpdatePAValue();
                    UpdateCEV();
                    UpdateHPValue();
                    UpdateMPValue();
                    UpdateSkillLabel();
                    ignoreChanges = false;
                    FireDataChangedEvent();
                };
            nameTextBox.Validated +=
                delegate( object sender, EventArgs e )
                {
                    character.Name = nameTextBox.Text;
                    FireDataChangedEvent();
                };
            spriteSetCombo.SelectedIndexChanged +=
                delegate( object sender, EventArgs e )
                {
                    character.SpriteSet = (SpriteSet)spriteSetCombo.SelectedItem;
                    FireDataChangedEvent();
                };
            levelSpinner.ValueChanged +=
                delegate( object sender, EventArgs e )
                {
                    character.Level = (byte)levelSpinner.Value;
                    FireDataChangedEvent();
                };
            experienceSpinner.ValueChanged +=
                delegate( object sender, EventArgs e )
                {
                    character.Experience = (byte)experienceSpinner.Value;
                    FireDataChangedEvent();
                };
            hpSpinner.ValueChanged +=
                delegate( object sender, EventArgs e )
                {
                    if( !ignoreChanges )
                    {
                        character.HP = (uint)hpSpinner.Value;
                        UpdateHPToolTip();
                        FireDataChangedEvent();
                    }
                };
            speedSpinner.ValueChanged +=
                delegate( object sender, EventArgs e )
                {
                    if( !ignoreChanges )
                    {
                        character.Speed = (uint)speedSpinner.Value;
                        UpdateSpeedToolTip();
                        FireDataChangedEvent();
                    }
                };
            mpSpinner.ValueChanged +=
                delegate( object sender, EventArgs e )
                {
                    if( !ignoreChanges )
                    {
                        character.MP = (uint)mpSpinner.Value;
                        UpdateMPToolTip();
                        FireDataChangedEvent();
                    }
                };
            paSpinner.ValueChanged +=
                delegate( object sender, EventArgs e )
                {
                    if( !ignoreChanges )
                    {
                        character.PA = (uint)paSpinner.Value;
                        UpdatePAToolTip();
                        FireDataChangedEvent();
                    }
                };
            maSpinner.ValueChanged +=
                delegate( object sender, EventArgs e )
                {
                    if( !ignoreChanges )
                    {
                        character.MA = (uint)maSpinner.Value;
                        UpdateMAToolTip();
                        FireDataChangedEvent();
                    }
                };
            genderComboBox.SelectedValueChanged +=
                delegate( object sender, EventArgs e )
                {
                    character.Gender = (Gender)genderComboBox.SelectedValue;
                    FireDataChangedEvent();
                };
            zodiacComboBox.SelectedValueChanged +=
                delegate( object sender, EventArgs e )
                {
                    character.ZodiacSign = (Zodiac)zodiacComboBox.SelectedValue;
                    FireDataChangedEvent();
                };
            braverySpinner.ValueChanged +=
                delegate( object sender, EventArgs e )
                {
                    character.Bravery = (byte)braverySpinner.Value;
                    FireDataChangedEvent();
                };
            faithSpinner.ValueChanged +=
                delegate( object sender, EventArgs e )
                {
                    character.Faith = (byte)faithSpinner.Value;
                    FireDataChangedEvent();
                };

            rightHandCombo.SelectedValueChanged +=
                delegate( object sender, EventArgs e )
                {
                    ignoreChanges = true;
                    character.RightHand = (Item)rightHandCombo.SelectedItem;
                    UpdateRightWeapon();
                    UpdateMove();
                    UpdateJump();
                    UpdateSPValue();
                    UpdateHPValue();
                    UpdatePAValue();
                    UpdateMAValue();
                    UpdateMPValue();
                    UpdateSEV();
                    UpdateAEV();
                    ignoreChanges = false;
                    FireDataChangedEvent();
                };
            rightShieldCombo.SelectedValueChanged +=
                delegate( object sender, EventArgs e )
                {
                    ignoreChanges = true;
                    character.RightShield = (Item)rightShieldCombo.SelectedItem;
                    UpdateMove();
                    UpdateJump();
                    UpdateSPValue();
                    UpdateHPValue();
                    UpdatePAValue();
                    UpdateMAValue();
                    UpdateMPValue();
                    UpdateSEV();
                    UpdateAEV();
                    ignoreChanges = false;
                    FireDataChangedEvent();
                };
            leftHandCombo.SelectedValueChanged +=
                delegate( object sender, EventArgs e )
                {
                    ignoreChanges = true;
                    character.LeftHand = (Item)leftHandCombo.SelectedItem;
                    UpdateLeftWeapon();
                    UpdateMove();
                    UpdateJump();
                    UpdateSPValue();
                    UpdateHPValue();
                    UpdatePAValue();
                    UpdateMAValue();
                    UpdateMPValue();
                    UpdateSEV();
                    UpdateAEV();
                    ignoreChanges = false;
                    FireDataChangedEvent();
                };
            leftShieldCombo.SelectedValueChanged +=
                delegate( object sender, EventArgs e )
                {
                    ignoreChanges = true;
                    character.LeftShield = (Item)leftShieldCombo.SelectedItem;
                    UpdateMove();
                    UpdateJump();
                    UpdateSPValue();
                    UpdateHPValue();
                    UpdatePAValue();
                    UpdateMAValue();
                    UpdateMPValue();
                    UpdateSEV();
                    UpdateAEV();
                    ignoreChanges = false;
                    FireDataChangedEvent();
                };
            headCombo.SelectedValueChanged +=
                delegate( object sender, EventArgs e )
                {
                    ignoreChanges = true;
                    character.Head = (Item)headCombo.SelectedItem;
                    UpdateMove();
                    UpdateJump();
                    UpdateSPValue();
                    UpdateHPValue();
                    UpdatePAValue();
                    UpdateMAValue();
                    UpdateMPValue();
                    UpdateSEV();
                    UpdateAEV();
                    ignoreChanges = false;
                    FireDataChangedEvent();
                };
            bodyCombo.SelectedValueChanged +=
                delegate( object sender, EventArgs e )
                {
                    ignoreChanges = true;
                    character.Body = (Item)bodyCombo.SelectedItem;
                    UpdateMove();
                    UpdateJump();
                    UpdateSPValue();
                    UpdateHPValue();
                    UpdatePAValue();
                    UpdateMAValue();
                    UpdateMPValue();
                    UpdateSEV();
                    UpdateAEV();
                    ignoreChanges = false;
                    FireDataChangedEvent();
                };
            accessoryCombo.SelectedValueChanged +=
                delegate( object sender, EventArgs e )
                {
                    ignoreChanges = true;
                    character.Accessory = (Item)accessoryCombo.SelectedItem;
                    UpdateMove();
                    UpdateJump();
                    UpdateSPValue();
                    UpdateHPValue();
                    UpdatePAValue();
                    UpdateMAValue();
                    UpdateMPValue();
                    UpdateSEV();
                    UpdateAEV();
                    ignoreChanges = false;
                    FireDataChangedEvent();
                };
            secondaryCombo.SelectedIndexChanged +=
                delegate( object sender, EventArgs e )
                {
                    character.SecondaryAction = (SecondaryAction)secondaryCombo.SelectedItem;
                    FireDataChangedEvent();
                };
            reactionCombo.SelectedValueChanged +=
                delegate( object sender, EventArgs e )
                {
                    ignoreChanges = true;
                    character.ReactAbility = (Ability)reactionCombo.SelectedItem;
                    UpdateMove();
                    UpdateJump();
                    UpdateHPValue();
                    ignoreChanges = false;
                    FireDataChangedEvent();
                };
            supportCombo.SelectedValueChanged +=
                delegate( object sender, EventArgs e )
                {
                    ignoreChanges = true;
                    character.SupportAbility = (Ability)supportCombo.SelectedItem;
                    UpdateMove();
                    UpdateJump();
                    UpdateHPValue();
                    ignoreChanges = false;
                    FireDataChangedEvent();
                };
            movementCombo.SelectedValueChanged +=
                delegate( object sender, EventArgs e )
                {
                    ignoreChanges = true;
                    character.MovementAbility = (Ability)movementCombo.SelectedItem;
                    UpdateMove();
                    UpdateJump();
                    UpdateHPValue();
                    ignoreChanges = false;
                    FireDataChangedEvent();
                };

        }

        private void nameTextBox_Validating( object sender, CancelEventArgs e )
        {
            List<char> charList = new List<char>( Character.characterMap );
            foreach( char c in nameTextBox.Text )
            {
                if( charList.IndexOf( c ) < 0 )
                {
                    e.Cancel = true;
                    return;
                }
            }
        }

        private void ComboBoxValidating( object sender, CancelEventArgs e )
        {
            ComboBox c = sender as ComboBox;
            if( c.SelectedItem == null )
            {
                e.Cancel = true;
            }
        }

        public event EventHandler DataChangedEvent;

        private void FireDataChangedEvent()
        {
            if( DataChangedEvent != null )
            {
                DataChangedEvent( this, EventArgs.Empty );
            }
        }

        #endregion

        #region Utilities
        private int GetIdealDropDownWidth( ICollection items, ComboBox c, int minimumWidth )
        {
            int width = minimumWidth;
            Graphics g = c.CreateGraphics();
            Font f = c.Font;
            int scrollBarWidth = (items.Count > c.MaxDropDownItems) ? SystemInformation.VerticalScrollBarWidth : 0;
            int itemWidth;
            foreach( object o in items )
            {
                string s = o.ToString();
                itemWidth = (int)g.MeasureString( s, f ).Width + scrollBarWidth;
                if( width < itemWidth )
                {
                    width = itemWidth;
                }
            }

            return width;
        }

        private void AssignComboBoxItems()
        {
            ComboBox[] itemCombos = new ComboBox[] { rightHandCombo, rightShieldCombo, leftHandCombo, leftShieldCombo, headCombo, bodyCombo, accessoryCombo };
            foreach( ComboBox c in itemCombos )
            {
                c.DisplayMember = "String";
                c.ValueMember = "Offset";
                c.DataSource = Item.ItemList;
                c.Validating += ComboBoxValidating;

                //c.DropDownWidth = GetIdealDropDownWidth( Item.ItemList, c, 0 );
            }

            secondaryCombo.DisplayMember = "String";
            secondaryCombo.ValueMember = "Byte";
            secondaryCombo.DataSource = SecondaryAction.ActionList;
            //secondaryCombo.DropDownWidth = GetIdealDropDownWidth( SecondaryAction.ActionList, secondaryCombo, 0 );

            ComboBox[] abilityCombos = new ComboBox[] { movementCombo, reactionCombo, supportCombo };
            foreach( ComboBox a in abilityCombos )
            {
                a.DisplayMember = "String";
                a.ValueMember = "Value";
                a.DataSource = Ability.AbilityList;
                //a.DropDownWidth = GetIdealDropDownWidth( Ability.AbilityList, a, 0 );
            }

            classComboBox.DataSource = Class.ClassList;
            //classComboBox.DropDownWidth = GetIdealDropDownWidth( Class.ClassList, classComboBox, 0 );

            zodiacComboBox.DataSource = Enum.GetValues( typeof( Zodiac ) );
            //zodiacComboBox.DropDownWidth = GetIdealDropDownWidth( Enum.GetValues( typeof( Zodiac ) ), zodiacComboBox, 0 );

            spriteSetCombo.DataSource = SpriteSet.AllSprites;
            //spriteSetCombo.DropDownWidth = GetIdealDropDownWidth( SpriteSet.AllSprites, spriteSetCombo, 0 );

            genderComboBox.DataSource = Enum.GetValues( typeof( Gender ) );
        }

        #endregion

        public CharacterEditor()
        {
            InitializeComponent();
            AssignComboBoxItems();

            nameTextBox.Validating += new CancelEventHandler( nameTextBox_Validating );

            UpdateView();
            SetupEvents();
        }
    }
}
