﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using FFTPatcher.Datatypes;
using System.Reflection;

namespace FFTPatcher.Editors
{
    public partial class AbilityAttributesEditor : UserControl
    {
            
        private List<NumericUpDown> spinners;
        private static readonly List<string> FieldNames = new List<string>(new string[] {
            "Range", "Effect", "Vertical", "Formula", "X", "Y", "StatusMagic", "CT", "MPCost" });
        private static readonly List<string> FlagNames = new List<string>(new string[] {
            "Blank6", "Blank7", "WeaponRange", "VerticalFixed", "VerticalTolerance", "WeaponStrike", "Auto", "TargetSelf",
            "HitEnemies", "HitAllies", "Blank8", "FollowTarget", "RandomFire", "LinearAttack", "ThreeDirections", "HitCaster",
            "Reflect", "Arithmetick", "Silence", "Mimic", "NormalAttack", "Perservere", "ShowQuote", "Unknown5",
            "CounterFlood", "CounterMagic", "Direct", "Shirahadori", "RequiresSword", "RequiresMateriaBlade", "Evadeable", "Targeting"});

        private AbilityAttributes attributes;
        public AbilityAttributes Attributes
        {
            get { return attributes; }
            set
            {
                if (value == null)
                {
                    this.Enabled = false;
                    this.elementsEditor.Elements = null;
                    attributes = null;
                }
                else if (attributes != value)
                {
                    this.Enabled = true;
                    attributes = value;
                    UpdateView();
                }
            }
        }

        private void UpdateView()
        {
            this.SuspendLayout();
            elementsEditor.SuspendLayout();

            ignoreChanges = true;
            for (int i = 0; i < flagsCheckedListBox.Items.Count; i++)
            {
                flagsCheckedListBox.SetItemChecked(i, Utilities.GetFlag(attributes, FlagNames[i]));
            }

            rangeSpinner.Value = attributes.Range;
            effectSpinner.Value = attributes.Effect;
            verticalSpinner.Value = attributes.Vertical;
            formulaSpinner.Value = attributes.Formula;
            xSpinner.Value = attributes.X;
            ySpinner.Value = attributes.Y;
            statusSpinner.Value = attributes.StatusMagic;
            ctSpinner.Value = attributes.CT;
            mpSpinner.Value = attributes.MPCost;

            elementsEditor.Elements = attributes.Elements;
            ignoreChanges = false;

            elementsEditor.ResumeLayout();
            this.ResumeLayout();
        }

        public AbilityAttributesEditor()
        {
            InitializeComponent();
            spinners = new List<NumericUpDown>(new NumericUpDown[] { rangeSpinner, effectSpinner, verticalSpinner, formulaSpinner, xSpinner, ySpinner, statusSpinner, ctSpinner, mpSpinner });
            foreach (NumericUpDown spinner in spinners)
            {
                spinner.ValueChanged += spinner_ValueChanged;
            }
            flagsCheckedListBox.ItemCheck += flagsCheckedListBox_ItemCheck;
        }

        private void spinner_ValueChanged(object sender, EventArgs e)
        {
            if (!ignoreChanges)
            {
                NumericUpDown c = sender as NumericUpDown;
                int i = spinners.IndexOf(c);
                Utilities.SetFieldOrProperty(attributes, FieldNames[i], (byte)c.Value);
            }
        }

        private bool ignoreChanges = false;

        private void flagsCheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (!ignoreChanges)
            {
                Utilities.SetFlag(attributes, FlagNames[e.Index], e.NewValue == CheckState.Checked);
            }
        }
    }
}
