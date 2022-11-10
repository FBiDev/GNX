using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//
using System.Windows.Forms;
using System.Drawing;

namespace GNX
{
    public static class RichTextBoxExtension
    {
        public static void AppendText(this RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }
    }
}
