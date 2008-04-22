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

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using FFTPatcher.Editors;

namespace FFTPatcher.Controls
{
    /// <summary>
    /// Represents a <see cref="ComboBox"/> that allows a default value to be specified.
    /// </summary>
    public class ComboBoxWithDefault : ComboBox
    {

		#region Properties (6) 


        public object DefaultValue { get; private set; }



        [DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
        public new AutoCompleteMode AutoCompleteMode { get { return base.AutoCompleteMode; } private set { base.AutoCompleteMode = value; } }

        [DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
        public new AutoCompleteSource AutoCompleteSource { get { return base.AutoCompleteSource; } private set { base.AutoCompleteSource = value; } }

        [DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
        public new DrawMode DrawMode { get { return base.DrawMode; } private set { base.DrawMode = value; } }

        [DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
        public new ComboBoxStyle DropDownStyle { get { return base.DropDownStyle; } private set { base.DropDownStyle = value; } }

        /// <summary>
        /// Gets the currently selected item.
        /// </summary>
        public new object SelectedItem
        {
            get { return base.SelectedItem; }
            private set { base.SelectedItem = value; }
        }


		#endregion Properties 

		#region Constructors (1) 

        public ComboBoxWithDefault()
            : base()
        {
            DropDownStyle = ComboBoxStyle.DropDownList;
            AutoCompleteSource = AutoCompleteSource.ListItems;
            AutoCompleteMode = AutoCompleteMode.Append;
        }

		#endregion Constructors 

		#region Methods (5) 


        private void SetColors()
        {
            if( Enabled && !DroppedDown && (SelectedItem != null) && !SelectedItem.Equals( DefaultValue ) )
            {
                BackColor = Color.Blue;
                ForeColor = Color.White;
            }
            else if( Enabled && !DroppedDown )
            {
                BackColor = SystemColors.Window;
                ForeColor = SystemColors.WindowText;
            }
            else if( Enabled && DroppedDown )
            {
                BackColor = SystemColors.Window;
                ForeColor = SystemColors.WindowText;
            }
        }

        /// <summary>
        /// Sets the SelectedItem and its default value.
        /// </summary>
        public void SetValueAndDefault( object value, object defaultValue )
        {
            FFTPatchEditor.ToolTip.SetToolTip( this, "Default: " + defaultValue.ToString() );

            DefaultValue = defaultValue;
            SelectedItem = value;
            OnSelectedIndexChanged( EventArgs.Empty );
        }



        protected override void OnInvalidated( InvalidateEventArgs e )
        {
            SetColors();
            base.OnInvalidated( e );
        }

        protected override void OnKeyDown( KeyEventArgs e )
        {
            if( e.KeyData == Keys.F12 )
            {
                SetValueAndDefault( DefaultValue, DefaultValue );
            }
            base.OnKeyDown( e );
        }

        protected override void OnSelectedIndexChanged( EventArgs e )
        {
            base.OnSelectedIndexChanged( e );
            SetColors();
        }


		#endregion Methods 

    }
}
