﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Collections.ObjectModel;
using System.Drawing.Imaging;

namespace FFTPatcher.SpriteEditor
{
    public abstract class AbstractShapedSprite : AbstractCompressedSprite
    {
        private IList<Bitmap> frames;

        protected bool FramesDirty { get; set; }

        public abstract int ThumbnailFrame { get; }

        public IList<Bitmap> Frames 
        {
            get
            {
                if ( FramesDirty )
                {
                    frames = Shape.GetFrames( this );
                    FramesDirty = false;
                }

                return new ReadOnlyCollection<Bitmap>( frames );
            }
        }

        public AbstractShapedSprite( string name, IList<byte> bytes, params IList<byte>[] otherBytes )
            : base( name, bytes, otherBytes )
        {
            FramesDirty = true;
        }

        public override Image GetThumbnail()
        {
            Bitmap result = new Bitmap( 80, 48, PixelFormat.Format24bppRgb );

            Shape.Frames[ThumbnailFrame].GetFrame( this ).CopyRectangleToPointNonIndexed(
                ThumbnailRectangle,
                result,
                new Point( ( 48 - ThumbnailRectangle.Width ) / 2, ( 48 - ThumbnailRectangle.Height ) / 2 ),
                Palettes[0],
                false );

            using ( Bitmap portrait = new Bitmap( 48, 32, PixelFormat.Format8bppIndexed ) )
            using ( Bitmap wholeImage = ToBitmap() )
            {
                ColorPalette palette2 = portrait.Palette;
                FixupColorPalette( palette2 );
                portrait.Palette = palette2;

                wholeImage.CopyRectangleToPoint( PortraitRectangle, portrait, Point.Empty, Palettes[8], false );
                portrait.RotateFlip( RotateFlipType.Rotate270FlipNone );
                portrait.CopyRectangleToPointNonIndexed( new Rectangle( 0, 0, 32, 48 ), result, new Point( 48, 0 ), Palettes[8], false );
            }

            return result;
        }
    }
}
