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

namespace FFTPatcher.TextEditor.Files
{
    /// <summary>
    /// Contains data for an event that indicates the user wants to save a file.
    /// </summary>
    public class SavingFileEventArgs : EventArgs
    {

        #region Properties (3)


        /// <summary>
        /// Gets the <see cref="IFile"/> the user wants to save.
        /// </summary>
        public IFile File { get; private set; }

        /// <summary>
        /// Gets or sets the partition number to save.
        /// </summary>
        public int PartitionNumber { get; private set; }

        /// <summary>
        /// Gets the suggested filename to use in the save dialog.
        /// </summary>
        public string SuggestedFilename { get; private set; }


        #endregion Properties

        #region Constructors (2)

        /// <summary>
        /// Initializes a new instance of the <see cref="SavingFileEventArgs"/> class.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="suggestedFilename">The suggested filename.</param>
        public SavingFileEventArgs( IFile file, string suggestedFilename )
        {
            File = file;
            SuggestedFilename = suggestedFilename;
            PartitionNumber = -1;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SavingFileEventArgs"/> class.
        /// </summary>
        /// <param name="file">The partitioned file.</param>
        /// <param name="suggestedFilename">The suggested filename.</param>
        /// <param name="whichPartition">Which partition to save to.</param>
        public SavingFileEventArgs( IPartitionedFile file, string suggestedFilename, int whichPartition )
            : this( file, suggestedFilename )
        {
            PartitionNumber = whichPartition;
        }

        #endregion Constructors

    }
}
