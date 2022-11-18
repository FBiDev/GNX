using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace GNX
{
    public partial class FlatProgressBar : ProgressBar
    {
        public FlatProgressBar()
        {
            InitializeComponent();
            //this.SetStyle(ControlStyles.UserPaint, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            LinearGradientBrush brush = null;
            Rectangle rec = new Rectangle(0, 0, this.Width, this.Height);
            
            double scaleFactor = (((double)Value - (double)Minimum) / ((double)Maximum - (double)Minimum));

            if (ProgressBarRenderer.IsSupported)
                ProgressBarRenderer.DrawHorizontalBar(e.Graphics, rec);

            rec.Width = (int)((rec.Width * scaleFactor) - 1);
            rec.Height -= -1;
            brush = new LinearGradientBrush(rec, this.ForeColor, this.BackColor, LinearGradientMode.Vertical);

            e.Graphics.FillRectangle(brush, 0, 0, rec.Width, rec.Height);

            e.Graphics.DrawRoundBorder(this, ColorTranslator.FromHtml("#D5DFE5"), 1, true);
        }
    }
}
