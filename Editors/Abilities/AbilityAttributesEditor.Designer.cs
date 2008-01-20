﻿/*
    Copyright 2007, Joe Davidson <joedavidson@gmail.com>

    This file is part of FFTPatcher.

    FFTPatcher is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    FFTPatcher is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with FFTPatcher.  If not, see <http://www.gnu.org/licenses/>.
*/

namespace FFTPatcher.Editors
{
    partial class AbilityAttributesEditor
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.GroupBox attributesGroupBox;
            System.Windows.Forms.Label hLabel2;
            System.Windows.Forms.Label hLabel1;
            System.Windows.Forms.Label mpLabel;
            System.Windows.Forms.Label ctLabel;
            System.Windows.Forms.Label yLabel;
            System.Windows.Forms.Label xLabel;
            System.Windows.Forms.Label formulaLabel;
            System.Windows.Forms.Label verticalLabel;
            System.Windows.Forms.Label effectLabel;
            System.Windows.Forms.Label rangeLabel;
            this.inflictStatusLabel = new System.Windows.Forms.LinkLabel();
            this.flagsCheckedListBox = new FFTPatcher.Controls.CheckedListBoxNoHighlightWithDefault();
            this.mpSpinner = new FFTPatcher.Controls.NumericUpDownWithDefault();
            this.ctSpinner = new FFTPatcher.Controls.NumericUpDownWithDefault();
            this.statusSpinner = new FFTPatcher.Controls.NumericUpDownWithDefault();
            this.ySpinner = new FFTPatcher.Controls.NumericUpDownWithDefault();
            this.xSpinner = new FFTPatcher.Controls.NumericUpDownWithDefault();
            this.formulaSpinner = new FFTPatcher.Controls.NumericUpDownWithDefault();
            this.verticalSpinner = new FFTPatcher.Controls.NumericUpDownWithDefault();
            this.effectSpinner = new FFTPatcher.Controls.NumericUpDownWithDefault();
            this.rangeSpinner = new FFTPatcher.Controls.NumericUpDownWithDefault();
            this.elementsEditor = new FFTPatcher.Editors.ElementsEditor();
            attributesGroupBox = new System.Windows.Forms.GroupBox();
            hLabel2 = new System.Windows.Forms.Label();
            hLabel1 = new System.Windows.Forms.Label();
            mpLabel = new System.Windows.Forms.Label();
            ctLabel = new System.Windows.Forms.Label();
            yLabel = new System.Windows.Forms.Label();
            xLabel = new System.Windows.Forms.Label();
            formulaLabel = new System.Windows.Forms.Label();
            verticalLabel = new System.Windows.Forms.Label();
            effectLabel = new System.Windows.Forms.Label();
            rangeLabel = new System.Windows.Forms.Label();
            attributesGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mpSpinner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctSpinner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusSpinner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ySpinner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xSpinner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.formulaSpinner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.verticalSpinner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.effectSpinner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rangeSpinner)).BeginInit();
            this.SuspendLayout();
            // 
            // attributesGroupBox
            // 
            attributesGroupBox.AutoSize = true;
            attributesGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            attributesGroupBox.Controls.Add( this.inflictStatusLabel );
            attributesGroupBox.Controls.Add( hLabel2 );
            attributesGroupBox.Controls.Add( hLabel1 );
            attributesGroupBox.Controls.Add( this.flagsCheckedListBox );
            attributesGroupBox.Controls.Add( this.mpSpinner );
            attributesGroupBox.Controls.Add( this.ctSpinner );
            attributesGroupBox.Controls.Add( this.statusSpinner );
            attributesGroupBox.Controls.Add( this.ySpinner );
            attributesGroupBox.Controls.Add( this.xSpinner );
            attributesGroupBox.Controls.Add( this.formulaSpinner );
            attributesGroupBox.Controls.Add( this.verticalSpinner );
            attributesGroupBox.Controls.Add( this.effectSpinner );
            attributesGroupBox.Controls.Add( this.rangeSpinner );
            attributesGroupBox.Controls.Add( mpLabel );
            attributesGroupBox.Controls.Add( ctLabel );
            attributesGroupBox.Controls.Add( yLabel );
            attributesGroupBox.Controls.Add( xLabel );
            attributesGroupBox.Controls.Add( formulaLabel );
            attributesGroupBox.Controls.Add( verticalLabel );
            attributesGroupBox.Controls.Add( effectLabel );
            attributesGroupBox.Controls.Add( rangeLabel );
            attributesGroupBox.Controls.Add( this.elementsEditor );
            attributesGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            attributesGroupBox.Location = new System.Drawing.Point( 0, 0 );
            attributesGroupBox.Name = "attributesGroupBox";
            attributesGroupBox.Size = new System.Drawing.Size( 314, 517 );
            attributesGroupBox.TabIndex = 0;
            attributesGroupBox.TabStop = false;
            attributesGroupBox.Text = "Attributes";
            // 
            // inflictStatusLabel
            // 
            this.inflictStatusLabel.AutoSize = true;
            this.inflictStatusLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.inflictStatusLabel.Location = new System.Drawing.Point( 6, 154 );
            this.inflictStatusLabel.Name = "inflictStatusLabel";
            this.inflictStatusLabel.Size = new System.Drawing.Size( 66, 13 );
            this.inflictStatusLabel.TabIndex = 12;
            this.inflictStatusLabel.TabStop = true;
            this.inflictStatusLabel.Text = "Inflict status:";
            // 
            // hLabel2
            // 
            hLabel2.AutoSize = true;
            hLabel2.Location = new System.Drawing.Point( 148, 154 );
            hLabel2.Name = "hLabel2";
            hLabel2.Size = new System.Drawing.Size( 13, 13 );
            hLabel2.TabIndex = 11;
            hLabel2.Text = "h";
            // 
            // hLabel1
            // 
            hLabel1.AutoSize = true;
            hLabel1.Location = new System.Drawing.Point( 148, 85 );
            hLabel1.Name = "hLabel1";
            hLabel1.Size = new System.Drawing.Size( 13, 13 );
            hLabel1.TabIndex = 10;
            hLabel1.Text = "h";
            // 
            // flagsCheckedListBox
            // 
            this.flagsCheckedListBox.FormattingEnabled = true;
            this.flagsCheckedListBox.Location = new System.Drawing.Point( 164, 14 );
            this.flagsCheckedListBox.Name = "flagsCheckedListBox";
            this.flagsCheckedListBox.Size = new System.Drawing.Size( 144, 484 );
            this.flagsCheckedListBox.TabIndex = 9;
            // 
            // mpSpinner
            // 
            this.mpSpinner.AutoSize = true;
            this.mpSpinner.Location = new System.Drawing.Point( 102, 198 );
            this.mpSpinner.Maximum = new decimal( new int[] {
            255,
            0,
            0,
            0} );
            this.mpSpinner.Name = "mpSpinner";
            this.mpSpinner.Size = new System.Drawing.Size( 45, 20 );
            this.mpSpinner.TabIndex = 8;
            this.mpSpinner.Tag = "MPCost";
            this.mpSpinner.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ctSpinner
            // 
            this.ctSpinner.AutoSize = true;
            this.ctSpinner.Location = new System.Drawing.Point( 102, 175 );
            this.ctSpinner.Maximum = new decimal( new int[] {
            255,
            0,
            0,
            0} );
            this.ctSpinner.Name = "ctSpinner";
            this.ctSpinner.Size = new System.Drawing.Size( 45, 20 );
            this.ctSpinner.TabIndex = 7;
            this.ctSpinner.Tag = "CT";
            this.ctSpinner.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // statusSpinner
            // 
            this.statusSpinner.AutoSize = true;
            this.statusSpinner.Hexadecimal = true;
            this.statusSpinner.Location = new System.Drawing.Point( 102, 152 );
            this.statusSpinner.Maximum = new decimal( new int[] {
            127,
            0,
            0,
            0} );
            this.statusSpinner.Name = "statusSpinner";
            this.statusSpinner.Size = new System.Drawing.Size( 45, 20 );
            this.statusSpinner.TabIndex = 6;
            this.statusSpinner.Tag = "InflictStatus";
            this.statusSpinner.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ySpinner
            // 
            this.ySpinner.AutoSize = true;
            this.ySpinner.Location = new System.Drawing.Point( 102, 129 );
            this.ySpinner.Maximum = new decimal( new int[] {
            255,
            0,
            0,
            0} );
            this.ySpinner.Name = "ySpinner";
            this.ySpinner.Size = new System.Drawing.Size( 45, 20 );
            this.ySpinner.TabIndex = 5;
            this.ySpinner.Tag = "Y";
            this.ySpinner.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // xSpinner
            // 
            this.xSpinner.AutoSize = true;
            this.xSpinner.Location = new System.Drawing.Point( 102, 106 );
            this.xSpinner.Maximum = new decimal( new int[] {
            255,
            0,
            0,
            0} );
            this.xSpinner.Name = "xSpinner";
            this.xSpinner.Size = new System.Drawing.Size( 45, 20 );
            this.xSpinner.TabIndex = 4;
            this.xSpinner.Tag = "X";
            this.xSpinner.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // formulaSpinner
            // 
            this.formulaSpinner.Hexadecimal = true;
            this.formulaSpinner.Location = new System.Drawing.Point( 102, 83 );
            this.formulaSpinner.Maximum = new decimal( new int[] {
            255,
            0,
            0,
            0} );
            this.formulaSpinner.Name = "formulaSpinner";
            this.formulaSpinner.Size = new System.Drawing.Size( 45, 20 );
            this.formulaSpinner.TabIndex = 3;
            this.formulaSpinner.Tag = "Formula";
            this.formulaSpinner.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // verticalSpinner
            // 
            this.verticalSpinner.AutoSize = true;
            this.verticalSpinner.Location = new System.Drawing.Point( 102, 60 );
            this.verticalSpinner.Maximum = new decimal( new int[] {
            255,
            0,
            0,
            0} );
            this.verticalSpinner.Name = "verticalSpinner";
            this.verticalSpinner.Size = new System.Drawing.Size( 45, 20 );
            this.verticalSpinner.TabIndex = 2;
            this.verticalSpinner.Tag = "Vertical";
            this.verticalSpinner.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // effectSpinner
            // 
            this.effectSpinner.AutoSize = true;
            this.effectSpinner.Location = new System.Drawing.Point( 102, 37 );
            this.effectSpinner.Maximum = new decimal( new int[] {
            255,
            0,
            0,
            0} );
            this.effectSpinner.Name = "effectSpinner";
            this.effectSpinner.Size = new System.Drawing.Size( 45, 20 );
            this.effectSpinner.TabIndex = 1;
            this.effectSpinner.Tag = "Effect";
            this.effectSpinner.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // rangeSpinner
            // 
            this.rangeSpinner.AutoSize = true;
            this.rangeSpinner.Location = new System.Drawing.Point( 102, 14 );
            this.rangeSpinner.Maximum = new decimal( new int[] {
            255,
            0,
            0,
            0} );
            this.rangeSpinner.Name = "rangeSpinner";
            this.rangeSpinner.Size = new System.Drawing.Size( 45, 20 );
            this.rangeSpinner.TabIndex = 0;
            this.rangeSpinner.Tag = "Range";
            this.rangeSpinner.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // mpLabel
            // 
            mpLabel.AutoSize = true;
            mpLabel.Location = new System.Drawing.Point( 6, 200 );
            mpLabel.Name = "mpLabel";
            mpLabel.Size = new System.Drawing.Size( 50, 13 );
            mpLabel.TabIndex = 9;
            mpLabel.Text = "MP Cost:";
            // 
            // ctLabel
            // 
            ctLabel.AutoSize = true;
            ctLabel.Location = new System.Drawing.Point( 6, 177 );
            ctLabel.Name = "ctLabel";
            ctLabel.Size = new System.Drawing.Size( 24, 13 );
            ctLabel.TabIndex = 8;
            ctLabel.Text = "CT:";
            // 
            // yLabel
            // 
            yLabel.AutoSize = true;
            yLabel.Location = new System.Drawing.Point( 16, 131 );
            yLabel.Name = "yLabel";
            yLabel.Size = new System.Drawing.Size( 14, 13 );
            yLabel.TabIndex = 6;
            yLabel.Text = "Y";
            // 
            // xLabel
            // 
            xLabel.AutoSize = true;
            xLabel.Location = new System.Drawing.Point( 16, 108 );
            xLabel.Name = "xLabel";
            xLabel.Size = new System.Drawing.Size( 14, 13 );
            xLabel.TabIndex = 5;
            xLabel.Text = "X";
            // 
            // formulaLabel
            // 
            formulaLabel.AutoSize = true;
            formulaLabel.Location = new System.Drawing.Point( 6, 85 );
            formulaLabel.Name = "formulaLabel";
            formulaLabel.Size = new System.Drawing.Size( 47, 13 );
            formulaLabel.TabIndex = 4;
            formulaLabel.Text = "Formula:";
            // 
            // verticalLabel
            // 
            verticalLabel.AutoSize = true;
            verticalLabel.Location = new System.Drawing.Point( 6, 62 );
            verticalLabel.Name = "verticalLabel";
            verticalLabel.Size = new System.Drawing.Size( 45, 13 );
            verticalLabel.TabIndex = 3;
            verticalLabel.Text = "Vertical:";
            // 
            // effectLabel
            // 
            effectLabel.AutoSize = true;
            effectLabel.Location = new System.Drawing.Point( 6, 39 );
            effectLabel.Name = "effectLabel";
            effectLabel.Size = new System.Drawing.Size( 62, 13 );
            effectLabel.TabIndex = 2;
            effectLabel.Text = "Effect area:";
            // 
            // rangeLabel
            // 
            rangeLabel.AutoSize = true;
            rangeLabel.Location = new System.Drawing.Point( 6, 16 );
            rangeLabel.Name = "rangeLabel";
            rangeLabel.Size = new System.Drawing.Size( 42, 13 );
            rangeLabel.TabIndex = 1;
            rangeLabel.Text = "Range:";
            // 
            // elementsEditor
            // 
            this.elementsEditor.AutoSize = true;
            this.elementsEditor.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.elementsEditor.GroupBoxText = "Elements";
            this.elementsEditor.Location = new System.Drawing.Point( 9, 224 );
            this.elementsEditor.Name = "elementsEditor";
            this.elementsEditor.Size = new System.Drawing.Size( 94, 162 );
            this.elementsEditor.TabIndex = 0;
            this.elementsEditor.TabStop = false;
            // 
            // AbilityAttributesEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add( attributesGroupBox );
            this.Name = "AbilityAttributesEditor";
            this.Size = new System.Drawing.Size( 314, 517 );
            attributesGroupBox.ResumeLayout( false );
            attributesGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mpSpinner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctSpinner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusSpinner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ySpinner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xSpinner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.formulaSpinner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.verticalSpinner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.effectSpinner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rangeSpinner)).EndInit();
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion

        private ElementsEditor elementsEditor;
        private FFTPatcher.Controls.NumericUpDownWithDefault mpSpinner;
        private FFTPatcher.Controls.NumericUpDownWithDefault ctSpinner;
        private FFTPatcher.Controls.NumericUpDownWithDefault statusSpinner;
        private FFTPatcher.Controls.NumericUpDownWithDefault ySpinner;
        private FFTPatcher.Controls.NumericUpDownWithDefault xSpinner;
        private FFTPatcher.Controls.NumericUpDownWithDefault formulaSpinner;
        private FFTPatcher.Controls.NumericUpDownWithDefault verticalSpinner;
        private FFTPatcher.Controls.NumericUpDownWithDefault effectSpinner;
        private FFTPatcher.Controls.NumericUpDownWithDefault rangeSpinner;
        private FFTPatcher.Controls.CheckedListBoxNoHighlightWithDefault flagsCheckedListBox;
        private System.Windows.Forms.LinkLabel inflictStatusLabel;
    }
}
