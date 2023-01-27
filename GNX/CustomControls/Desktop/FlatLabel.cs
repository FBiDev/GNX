using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;

namespace GNX
{
    public partial class FlatLabel : Label
    {
        [DefaultValue(false)]
        public new bool UseMnemonic
        {
            get { return base.UseMnemonic; }
            set { base.UseMnemonic = value; }
        }

        [DefaultValue(false)]
        public new bool AutoSize
        {
            get { return base.AutoSize; }
            set { base.AutoSize = value; }
        }

        [DefaultValue(typeof(Size), "48, 24")]
        public new Size MinimumSize
        {
            get { return base.MinimumSize; }
            set { base.MinimumSize = value; }
        }

        [DefaultValue(typeof(Size), "66, 24")]
        public new Size Size
        {
            get { return base.Size; }
            set { base.Size = value; }
        }

        [DefaultValue(typeof(Padding), "0, 0, 0, 1")]
        public new Padding Padding
        {
            get { return base.Padding; }
            set { base.Padding = value; }
        }

        [DefaultValue(typeof(ContentAlignment), "MiddleLeft")]
        public new ContentAlignment TextAlign
        {
            get { return base.TextAlign; }
            set { base.TextAlign = value; }
        }

        [DefaultValue(typeof(Font), "Segoe UI, 9pt")]
        public new Font Font
        {
            get { return base.Font; }
            set { base.Font = value; }
        }

        [DefaultValue(typeof(Color), "Black")]
        public new Color ForeColor
        {
            get { return base.ForeColor; }
            set { base.ForeColor = value; }
        }

        [DefaultValue(typeof(Color), "Transparent")]
        public new Color BackColor
        {
            get { return base.BackColor; }
            set { base.BackColor = value; }
        }

        public FlatLabel()
        {
            InitializeComponent();

            UseMnemonic = false;

            TextAlign = ContentAlignment.MiddleLeft;
            Font = new Font(new FontFamily("Segoe UI"), 9, FontStyle.Regular);
            ForeColor = Color.Black;
            BackColor = Color.Transparent;

            AutoSize = false;

            MinimumSize = new Size(48, 24);
            Size = new Size(66, 24);
            Padding = new Padding(0, 0, 0, 1);
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
        }

        [DefaultValue(false)]
        public bool FirstLineBold { get; set; }

        //protected override void OnPaint(PaintEventArgs e)
        //{
        //    Point drawPoint = new Point(0, 0);

        //    var split = new string[1] { "\r\n" };
        //    string[] ary = Text.Split(split, StringSplitOptions.RemoveEmptyEntries);
        //    if (ary.Length > 1)
        //    {
        //        Font normalFont = Font;
        //        Font boldFont = new Font(normalFont, FontStyle.Bold);
        //        Font reducedFont = new Font(normalFont.Name, 8.75f);

        //        Size boldSize = TextRenderer.MeasureText(ary[0], boldFont);
        //        Size normalSize = TextRenderer.MeasureText(ary[1], normalFont);

        //        var firstText = Text.Substring(0, Text.IndexOf("\r\n"));
        //        var LastText = Text.Substring(Text.IndexOf("\r\n"));

        //        Size allSize = TextRenderer.MeasureText(Text, boldFont);

        //        if (boldSize.Width >= 290)
        //            LastText = "\r\n" + LastText;

        //        Rectangle alldRect = new Rectangle(drawPoint, allSize);

        //        using (Brush cellForeBrush = new SolidBrush(this.ForeColor))
        //            e.Graphics.DrawString(firstText, boldFont, cellForeBrush, alldRect);

        //        using (Brush cellForeBrush = new SolidBrush(this.ForeColor))
        //            e.Graphics.DrawString(LastText, reducedFont, cellForeBrush, alldRect);

        //        //Size = PreferredSize;
        //        //TextRenderer.DrawText(e.Graphics, firstText, boldFont, boldRect, ForeColor);
        //        //TextRenderer.DrawText(e.Graphics, firstText, normalFont, boldRect, ForeColor);
        //    }
        //    else
        //    {
        //        TextRenderer.DrawText(e.Graphics, Text, Font, drawPoint, ForeColor);
        //    }
        //}

        [DefaultValue(false)]
        public bool DoubleClickBlockCopy { get; set; }
        int WM_LBUTTONDBLCLK = 0x203;
        private string sSaved;

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_LBUTTONDBLCLK && DoubleClickBlockCopy)
            {
                sSaved = Clipboard.GetText();

                base.WndProc(ref m);

                if (!string.IsNullOrEmpty(sSaved))
                    Clipboard.SetText(sSaved);
                else
                    Clipboard.Clear();
            }
            else
            {
                base.WndProc(ref m);
            }
        }
    }
}
