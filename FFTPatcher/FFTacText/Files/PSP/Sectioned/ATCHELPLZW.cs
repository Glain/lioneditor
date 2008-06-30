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
using System.Collections.Generic;

namespace FFTPatcher.TextEditor.Files.PSP
{
    /// <summary>
    /// Represents the text for the ATCHELP.LZW file.
    /// </summary>
    public class ATCHELPLZW : BasePSPSectionedFile, IFFTPackFile
    {

		#region Static Fields (1) 

        private static Dictionary<Enum, long> locations;

		#endregion Static Fields 

		#region Fields (2) 

        private const int fftpackIndex = 41;
        private const string filename = "ATCHELP.LZW";

		#endregion Fields 

		#region Properties (5) 


        /// <summary>
        /// Gets the index of this file in fftpack.bin
        /// </summary>
        public int Index
        {
            get { return fftpackIndex; }
        }



        /// <summary>
        /// Gets the number of sections.
        /// </summary>
        /// <value>The number of sections.</value>
        protected override int NumberOfSections
        {
            get { return 21; }
        }

        /// <summary>
        /// Gets the filename.
        /// </summary>
        public override string Filename { get { return filename; } }

        /// <summary>
        /// Gets the filenames and locations for this file.
        /// </summary>
        public override IDictionary<Enum, long> Locations
        {
            get
            {
                if( locations == null )
                {
                    locations = new Dictionary<Enum, long>();
                    //locations.Add( "EVENT/ATCHELP.LZW", 0x00 );
                }
                return locations;
            }
        }

        /// <summary>
        /// Gets the maximum length of this file as a byte array.
        /// </summary>
        public override int MaxLength
        {
            get { return 0x1F834; }
        }


		#endregion Properties 

		#region Constructors (2) 

        private ATCHELPLZW()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ATCHELPLZW"/> class.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        public ATCHELPLZW( IList<byte> bytes )
            : base( bytes )
        {
        }

		#endregion Constructors 

		#region Methods (1) 


        /// <summary>
        /// Gets a list of indices for named sections.
        /// </summary>
        public override IList<NamedSection> GetNamedSections()
        {
            var result = base.GetNamedSections();
            result.Add( new NamedSection( this, SectionType.JobDescriptions, 12 ) );
            result.Add( new NamedSection( this, SectionType.ItemDescriptions, 13 ) );
            result.Add( new NamedSection( this, SectionType.AbilityDescriptions, 15 ) );
            result.Add( new NamedSection( this, SectionType.SkillsetDescriptions, 19 ) );
            return result;
        }


		#endregion Methods 

    }
}
