using System.Drawing;
using System.Windows.Forms;

namespace GNX.Desktop
{
    public static class RichTextBoxExtension
    {
        public static void AppendText(this RichTextBox box, string text, Color color, Font newFont = null)
        {
            box.SelectionFont = newFont.IsNull() ? box.Font : newFont;

            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }
    }
}