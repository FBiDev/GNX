using System.Drawing;
using System.Windows.Forms;

namespace GNX.Desktop
{
    public static class PictureBoxExtension
    {
        public static void ScaleTo(this PictureBox picBox, Bitmap bit)
        {
            picBox.Size = bit.MaxSize(picBox.MaximumSize);
            picBox.Image = bit;
        }
    }
}