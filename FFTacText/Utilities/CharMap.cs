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
using System.Text.RegularExpressions;

namespace FFTPatcher.TextEditor
{
    public abstract class GenericCharMap : Dictionary<int, string>
    {

		#region Fields (2) 

        private static Regex regex = new Regex( @"{0x([0-9A-Fa-f]+)}" );
        private Dictionary<string, int> reverse = null;

		#endregion Fields 

		#region Properties (1) 


        public Dictionary<string, int> Reverse
        {
            get
            {
                if( reverse == null )
                {
                    reverse = BuildValueToKeyMapping();
                }

                return reverse;
            }
        }


		#endregion Properties 

		#region Methods (4) 


        private Dictionary<string, int> BuildValueToKeyMapping()
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            foreach( KeyValuePair<int, string> kvp in this )
            {
                if( !result.ContainsKey( kvp.Value ) )
                {
                    result.Add( kvp.Value, kvp.Key );
                }
                else if( kvp.Key < result[kvp.Value] )
                {
                    result[kvp.Value] = kvp.Key;
                }
            }

            return result;
        }

        private byte[] IntToOneOrTwoOrThreeBytes( int i )
        {
            if( i < 256 )
            {
                return new byte[] { (byte)i };
            }
            else if( i < 65536 )
            {
                return new byte[] { (byte)((i & 0xFF00) >> 8), (byte)(i & 0xFF) };
            }
            else
            {
                return new byte[] { (byte)((i & 0xFF000) >> 16), (byte)((i & 0xFF00) >> 8), (byte)(i & 0xFF) };
            }
        }

        public string GetNextChar( IList<byte> bytes, ref int pos )
        {
            int resultPos = pos + 1;
            byte val = bytes[pos];
            int key = val;
            if( (val >= 0xD0 && val <= 0xDA) || (val == 0xE2) || (val == 0xE3) || (val == 0xEE) || (val == 0xF5) || (val == 0xF6) )
            {
                byte nextVal = bytes[pos + 1];
                resultPos++;
                key = val * 256 + nextVal;
            }
            else if( val >= 0xF0 && val <= 0xF3 && (pos + 2) < bytes.Count )
            {
                resultPos += 2;
                key = val * 256 * 256 + bytes[pos + 1] * 256 + bytes[pos + 2];
            }

            string result = string.Format( "{{0x{0:X2}", key ) + @"}";
            if( this.ContainsKey( key ) )
            {
                result = this[key];
            }

            pos = resultPos;

            return result;
        }

        public byte[] StringToByteArray( string s )
        {
            List<byte> result = new List<byte>( s.Length );

            for( int i = 0; i < s.Length; i++ )
            {
                int val = 0;
                if( s[i] == '{' )
                {
                    int j = s.IndexOf( '}', i );
                    string key = s.Substring( i, j - i + 1 );
                    if( Reverse.ContainsKey( key ) )
                    {
                        val = Reverse[key];
                    }
                    else
                    {
                        Match match = regex.Match( key );
                        if( match.Success )
                        {
                            result.AddRange( IntToOneOrTwoOrThreeBytes( Convert.ToInt32( match.Groups[1].Value, 16 ) ) );
                            val = -1;
                        }
                        else
                        {
                            throw new Exception();
                        }
                    }
                    i = j;
                }
                else if( s[i] == '\r' && (i + 1) < s.Length && s[i + 1] == '\n' )
                {
                    i += 1;
                    val = Reverse["\r\n"];
                }
                else
                {
                    val = Reverse[s[i].ToString()];
                }
                if( val >= 0 )
                {
                    result.AddRange( IntToOneOrTwoOrThreeBytes( val ) );
                }
            }

            return result.ToArray();
        }


		#endregion Methods 

    }

    public class PSPCharMap : GenericCharMap
    {
    }

    public class PSXCharMap : GenericCharMap
    {
    }

}
