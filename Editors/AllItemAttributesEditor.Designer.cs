﻿namespace FFTPatcher.Editors
{
    partial class AllItemAttributesEditor
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if( disposing && (components != null) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.offsetListBox = new System.Windows.Forms.ListBox();
            this.itemAttributeEditor = new FFTPatcher.Editors.ItemAttributeEditor();
            this.SuspendLayout();
            // 
            // offsetListBox
            // 
            this.offsetListBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.offsetListBox.FormattingEnabled = true;
            this.offsetListBox.Location = new System.Drawing.Point( 0, 0 );
            this.offsetListBox.Name = "offsetListBox";
            this.offsetListBox.Size = new System.Drawing.Size( 57, 446 );
            this.offsetListBox.TabIndex = 0;
            // 
            // itemAttributeEditor
            // 
            this.itemAttributeEditor.AutoScroll = true;
            this.itemAttributeEditor.AutoSize = true;
            this.itemAttributeEditor.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.itemAttributeEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemAttributeEditor.ItemAttributes = null;
            this.itemAttributeEditor.Location = new System.Drawing.Point( 57, 0 );
            this.itemAttributeEditor.Name = "itemAttributeEditor";
            this.itemAttributeEditor.Size = new System.Drawing.Size( 682, 449 );
            this.itemAttributeEditor.TabIndex = 1;
            // 
            // AllItemAttributesEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add( this.itemAttributeEditor );
            this.Controls.Add( this.offsetListBox );
            this.Name = "AllItemAttributesEditor";
            this.Size = new System.Drawing.Size( 739, 449 );
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox offsetListBox;
        private ItemAttributeEditor itemAttributeEditor;
    }
}
