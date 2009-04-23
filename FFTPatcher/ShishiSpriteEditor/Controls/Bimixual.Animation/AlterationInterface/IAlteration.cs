//Copyright 2009 Derek Duban
//This file is part of the Bimixual Animation Library.
//
//Bimixual Animation is free software: you can redistribute it and/or modify
//it under the terms of the GNU Lesser General Public License as published by
//the Free Software Foundation, either version 3 of the License, or
//(at your option) any later version.
//
//Bimixual Animation is distributed in the hope that it will be useful,
//but WITHOUT ANY WARRANTY; without even the implied warranty of
//MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//GNU Lesser General Public License for more details.
//
//You should have received a copy of the GNU Lesser General Public License
//along with Bimixual Animation Library.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Drawing;

namespace Bimixual.Animation
{
    /// <summary>
    /// Alterations are changes to apply to an Sprite before it is drawn at its location.
    /// Apply alterations via Sprite.AddAlteration()
    /// The alteration can alter the matrix of the Graphics object to achieve its goal or
    /// change how the bitmap is displayed.
    /// </summary>
    public interface IAlteration
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_g">Graphics object to be manipulated</param>
        /// <param name="p_point">Location where object is being drawn</param>
        /// <param name="p_bitmap">Can change the bitmap if you want</param>
        void ApplyAlteration(Graphics p_g, Point p_point, ref Bitmap p_bitmap);
    }
}
