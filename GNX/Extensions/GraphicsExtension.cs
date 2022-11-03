using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GNX
{
    public static class GraphicsExtension
    {
        public static void DrawRoundBorder(this Graphics g, Control ctl, Color color, bool groupBox = false)
        {
            Rectangle recInner = ctl.ClientRectangle;
            if (groupBox) recInner = new Rectangle(0, 6, ctl.Width, ctl.Height - 6);

            ControlPaint.DrawBorder(g, recInner, color, ButtonBorderStyle.Solid);

            Pen pBorder = new Pen(color);
            Pen pBlank = new Pen(ctl.Parent.BackColor);
            if (pBlank.Color == Color.Transparent) pBlank = new Pen(ctl.BackColor);

            int WidthB = ctl.Width - 1;
            int HeightB = ctl.Height - 1;
            int Height0 = 0;

            if (groupBox) Height0 = 6;

            //TopL
            g.DrawLine(pBlank, 0, Height0, 2, Height0);
            g.DrawLine(pBlank, 0, Height0, 0, Height0 + 2);
            g.DrawLine(pBlank, 0, Height0, 1, Height0 + 1);
            g.DrawLine(pBorder, 0, Height0 + 3, 3, Height0);

            //TopR
            g.DrawLine(pBlank, WidthB, Height0, WidthB - 2, Height0);
            g.DrawLine(pBlank, WidthB, Height0, WidthB, Height0 + 2);
            g.DrawLine(pBlank, WidthB, Height0, WidthB - 1, Height0 + 1);
            g.DrawLine(pBorder, WidthB, Height0 + 3, WidthB - 3, Height0);

            //BottomL
            g.DrawLine(pBlank, 0, HeightB, 2, HeightB);
            g.DrawLine(pBlank, 0, HeightB, 0, HeightB - 2);
            g.DrawLine(pBlank, 0, HeightB, 1, HeightB - 1);
            g.DrawLine(pBorder, 0, HeightB - 3, 3, HeightB);

            //BottomR
            g.DrawLine(pBlank, WidthB, HeightB, WidthB - 2, HeightB);
            g.DrawLine(pBlank, WidthB, HeightB, WidthB, HeightB - 2);
            g.DrawLine(pBlank, WidthB, HeightB, WidthB - 1, HeightB - 1);
            g.DrawLine(pBorder, WidthB, HeightB - 3, WidthB - 3, HeightB);
        }
    }
}
