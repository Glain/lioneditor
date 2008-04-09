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

using System.Windows.Forms;

namespace FFTPatcher.SpriteEditor
{
    public class SpriteViewer : UserControl
    {

		#region Fields (3) 

        private int palette = 0;
        private int portraitPalette = 8;
        private Sprite sprite = null;

		#endregion Fields 

		#region Properties (1) 


        public Sprite Sprite
        {
            get { return sprite; }
            set
            {
                if( value != sprite )
                {
                    sprite = value;
                    Invalidate();
                }
            }
        }


		#endregion Properties 

		#region Methods (3) 


        protected override void OnPaint( PaintEventArgs e )
        {
            base.OnPaint( e );
            if( sprite != null )
            {
                e.Graphics.DrawSprite( sprite, sprite.Palettes[palette], sprite.Palettes[portraitPalette] );
            }
        }

        public void SetPalette( int paletteId )
        {
            SetPalette( paletteId, paletteId );
        }

        public void SetPalette( int paletteId, int portraitPaletteId )
        {
            if( palette != paletteId || portraitPalette != portraitPaletteId )
            {
                palette = paletteId;
                portraitPalette = portraitPaletteId;
                Invalidate();
            }
        }


		#endregion Methods 

    }
}
