using System;
using System.Collections.Generic;
using System.Linq;
//
using System.Drawing;
using System.Windows.Forms;

namespace GNX
{
    public static class BitmapExtension
    {
        public static void ScaleTo(this PictureBox picBox, Bitmap bit)
        {
            picBox.Size = bit.MaxSize(picBox.MaximumSize);
            picBox.Image = bit;
        }

        public static Size MaxSize(this Bitmap Bitmap, Size maxSize)
        {
            float factor = Bitmap.Width >= Bitmap.Height ? (float)Bitmap.Height / (float)Bitmap.Width : (float)Bitmap.Width / (float)Bitmap.Height;

            int width = Bitmap.Width;
            int height = Bitmap.Height;

            if (width >= height)
            {
                if (width > maxSize.Width) { width = maxSize.Width; }
                height = (int)Math.Round(width * factor);
            }
            else if (width < height)
            {
                if (height > maxSize.Height) { height = maxSize.Height; }
                width = (int)Math.Round(height * factor);
            }
            return new Size(width, height);
        }
    }
}
