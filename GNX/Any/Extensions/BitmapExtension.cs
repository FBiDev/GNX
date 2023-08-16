using System;
using System.Drawing;

namespace GNX
{
    public static class BitmapExtension
    {
        public static Size MaxSize(this Bitmap Bitmap, Size maxSize)
        {
            int width = Bitmap.Width;
            int height = Bitmap.Height;

            if (maxSize.Width == 0 && maxSize.Height == 0) { return new Size(width, height); }

            float factor = Bitmap.Width >= Bitmap.Height ? Bitmap.Height / (float)Bitmap.Width : Bitmap.Width / (float)Bitmap.Height;

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