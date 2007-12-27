﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FFTPatcher.Datatypes;

namespace FFTPatcher.Editors
{
    public partial class AbilityEditor : UserControl
    {
        private Ability ability;
        public Ability Ability
        {
            get { return ability; }
            set
            {
                if( ability != value )
                {
                    ability = value;
                    UpdateView();
                }
            }
        }

        private bool ignoreChanges = false;

        private void UpdateView()
        {
            ignoreChanges = true;

            commonAbilitiesEditor.Ability = ability;

            abilityAttributesEditor.Visible = ability.IsNormal;
            abilityAttributesEditor.Attributes = ability.Attributes;

            arithmeticksLabel.Visible = ability.IsArithmetick;
            arithmeticksSpinner.Visible = ability.IsArithmetick;
            arithmeticksSpinner.Value = ability.ArithmetickSkill;

            hLabel.Visible = ability.IsArithmetick || ability.IsOther;

            chargingLabel.Visible = ability.IsCharging;
            ctLabel.Visible = ability.IsCharging;
            powerLabel.Visible = ability.IsCharging;
            ctSpinner.Visible = ability.IsCharging;
            powerSpinner.Visible = ability.IsCharging;
            ctSpinner.Value = ability.ChargeCT;
            powerSpinner.Value = ability.ChargeBonus;

            jumpingLabel.Visible = ability.IsJumping;
            horizontalLabel.Visible = ability.IsJumping;
            verticalLabel.Visible = ability.IsJumping;
            horizontalSpinner.Visible = ability.IsJumping;
            verticalSpinner.Visible = ability.IsJumping;
            horizontalSpinner.Value = ability.JumpHorizontal;
            verticalSpinner.Value = ability.JumpVertical;

            idLabel.Visible = ability.IsOther;
            idSpinner.Visible = ability.IsOther;
            idSpinner.Value = ability.OtherID;

            itemUseLabel.Visible = ability.IsItem;
            itemUseComboBox.Visible = ability.IsItem;
            itemUseComboBox.SelectedItem = ability.Item;

            throwingLabel.Visible = ability.IsThrowing;
            throwingComboBox.Visible = ability.IsThrowing;
            throwingComboBox.SelectedItem = ability.Throwing;

            ignoreChanges = false;
        }

        private List<NumericUpDown> spinners;
        private List<ComboBox> comboBoxes;

        public AbilityEditor()
        {
            InitializeComponent();
            spinners = new List<NumericUpDown>( new NumericUpDown[] { 
                arithmeticksSpinner, ctSpinner, powerSpinner, horizontalSpinner, verticalSpinner, idSpinner } );
            comboBoxes = new List<ComboBox>( new ComboBox[] { itemUseComboBox, throwingComboBox } );

            itemUseComboBox.BindingContext = new BindingContext();
            List<Item> validItems = new List<Item>( 256 );
            foreach( Item i in Item.DummyItems )
            {
                if( i.Offset <= 0xFF )
                {
                    validItems.Add( i );
                }
            }

            itemUseComboBox.DataSource = validItems;
            throwingComboBox.DataSource = Enum.GetValues( typeof( ItemSubType ) );

            arithmeticksSpinner.Tag = "ArithmetickSkill";
            ctSpinner.Tag = "ChargeCT";
            powerSpinner.Tag = "ChargeBonus";
            horizontalSpinner.Tag = "JumpHorizontal";
            verticalSpinner.Tag = "JumpVertical";
            itemUseComboBox.Tag = "Item";
            throwingComboBox.Tag = "Throwing";

            foreach( NumericUpDown spinner in spinners )
            {
                spinner.ValueChanged += spinner_ValueChanged;
            }
            foreach( ComboBox combo in comboBoxes )
            {
                combo.SelectedIndexChanged += combo_SelectedIndexChanged;
            }
        }

        private void combo_SelectedIndexChanged( object sender, EventArgs e )
        {
            if( !ignoreChanges )
            {
                ComboBox c = sender as ComboBox;
                Utilities.SetFieldOrProperty( ability, c.Tag as string, c.SelectedItem );
            }
        }

        private void spinner_ValueChanged( object sender, EventArgs e )
        {
            if( !ignoreChanges )
            {
                NumericUpDown c = sender as NumericUpDown;
                Utilities.SetFieldOrProperty( ability, c.Tag as string, (byte)c.Value );
            }
        }
    }
}
