﻿/*
    Copyright 2007, Joe Davidson <joedavidson@gmail.com>

    This file is part of FFTPatcher.

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
using System.Windows.Forms;
using FFTPatcher.Datatypes;

namespace FFTPatcher.Editors
{
    public partial class SkillSetEditor : UserControl
    {
        private bool ignoreChanges = false;
        private SkillSet skillSet;
        public SkillSet SkillSet
        {
            get { return skillSet; }
            set
            {
                if( value == null )
                {
                    this.Enabled = false;
                    skillSet = null;
                }
                else if( skillSet != value )
                {
                    this.Enabled = true;
                    skillSet = value;
                    UpdateView();
                }
            }
        }


        private List<ComboBox> actionComboBoxes;
        private List<ComboBox> theRestComboBoxes;

        public SkillSetEditor()
        {
            InitializeComponent();
            actionComboBoxes = new List<ComboBox>( new ComboBox[] { 
                actionComboBox1, actionComboBox2, actionComboBox3, actionComboBox4, 
                actionComboBox5, actionComboBox6, actionComboBox7, actionComboBox8, 
                actionComboBox9, actionComboBox10, actionComboBox11, actionComboBox12, 
                actionComboBox13, actionComboBox14, actionComboBox15, actionComboBox16 } );
            theRestComboBoxes = new List<ComboBox>( new ComboBox[] {
                theRestComboBox1, theRestComboBox2, theRestComboBox3,
                theRestComboBox4, theRestComboBox5, theRestComboBox6 } );
            foreach( ComboBox actionComboBox in actionComboBoxes )
            {
                actionComboBox.BindingContext = new BindingContext();
                actionComboBox.DataSource = AllAbilities.DummyAbilities;
                actionComboBox.SelectedIndexChanged += actionComboBox_SelectedIndexChanged;
            }
            foreach( ComboBox theRestComboBox in theRestComboBoxes )
            {
                theRestComboBox.BindingContext = new BindingContext();
                theRestComboBox.DataSource = AllAbilities.DummyAbilities;
                theRestComboBox.SelectedIndexChanged += theRestComboBox_SelectedIndexChanged;
            }
        }

        private void actionComboBox_SelectedIndexChanged( object sender, EventArgs e )
        {
            if( !ignoreChanges )
            {
                ComboBox c = sender as ComboBox;
                int i = actionComboBoxes.IndexOf( c );
                skillSet.Actions[i] = c.SelectedItem as Ability;
            }
        }

        private void theRestComboBox_SelectedIndexChanged( object sender, EventArgs e )
        {
            if( !ignoreChanges )
            {
                ComboBox c = sender as ComboBox;
                int i = theRestComboBoxes.IndexOf( c );
                skillSet.TheRest[i] = c.SelectedItem as Ability;
            }
        }

        private void UpdateView()
        {
            this.ignoreChanges = true;
            this.SuspendLayout();
            actionGroupBox.SuspendLayout();
            theRestGroupBox.SuspendLayout();

            for( int i = 0; i < 16; i++ )
            {
                actionComboBoxes[i].SelectedItem = skillSet.Actions[i];
            }
            for( int i = 0; i < 6; i++ )
            {
                theRestComboBoxes[i].SelectedItem = skillSet.TheRest[i];
            }

            theRestGroupBox.ResumeLayout();
            actionGroupBox.ResumeLayout();
            this.ResumeLayout();
            this.ignoreChanges = false;
        }

    }
}
