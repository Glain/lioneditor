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
using System.Windows.Forms;
using FFTPatcher.Datatypes;

namespace FFTPatcher.Editors
{
    public partial class AllItemAttributesEditor : UserControl
    {

		#region Properties (1) 


        public int SelectedIndex { get { return offsetListBox.SelectedIndex; } set { offsetListBox.SelectedIndex = value; } }


		#endregion Properties 

		#region Constructors (1) 

        public AllItemAttributesEditor()
        {
            InitializeComponent();
            itemAttributeEditor.DataChanged += new EventHandler( itemAttributeEditor_DataChanged );
            offsetListBox.ContextMenu = new ContextMenu(
                new MenuItem[] { new MenuItem( "Clone", CopyClickEventHandler ), new MenuItem( "Paste clone", PasteClickEventHandler ) } );
            offsetListBox.ContextMenu.MenuItems[1].Enabled = false;
        }

        private ItemAttributes ClipBoardAttributes;

		#endregion Constructors 

		#region Methods (3) 

        private void CopyClickEventHandler( object sender, System.EventArgs args )
        {
            offsetListBox.ContextMenu.MenuItems[1].Enabled = true;
            ClipBoardAttributes = offsetListBox.SelectedItem as ItemAttributes;
        }

        private void PasteClickEventHandler( object sender, System.EventArgs args )
        {
            if ( ClipBoardAttributes != null )
            {
                ClipBoardAttributes.CopyTo( offsetListBox.SelectedItem as ItemAttributes );
                itemAttributeEditor.ItemAttributes = null;
                itemAttributeEditor.ItemAttributes = offsetListBox.SelectedItem as ItemAttributes;
                itemAttributeEditor.UpdateView();
                itemAttributeEditor_DataChanged( itemAttributeEditor, System.EventArgs.Empty );
                itemAttributeEditor.PerformLayout();
            }
        }


        private void itemAttributeEditor_DataChanged( object sender, EventArgs e )
        {
            CurrencyManager cm = (CurrencyManager)BindingContext[offsetListBox.DataSource];
            cm.Refresh();
        }

        private void offsetListBox_SelectedIndexChanged( object sender, EventArgs e )
        {
            itemAttributeEditor.ItemAttributes = offsetListBox.SelectedItem as ItemAttributes;
        }

        private Context ourContext = Context.Default;
        public void UpdateView( AllItemAttributes attributes )
        {
            if ( ourContext != FFTPatch.Context )
            {
                ourContext = FFTPatch.Context;
                ClipBoardAttributes = null;
                offsetListBox.ContextMenu.MenuItems[1].Enabled = false;
            }

            offsetListBox.SelectedIndexChanged -= offsetListBox_SelectedIndexChanged;
            offsetListBox.DataSource = attributes.ItemAttributes;
            offsetListBox.SelectedIndexChanged += offsetListBox_SelectedIndexChanged;
            offsetListBox.SelectedIndex = 0;
            itemAttributeEditor.ItemAttributes = offsetListBox.SelectedItem as ItemAttributes;
        }


		#endregion Methods 

    }
}
