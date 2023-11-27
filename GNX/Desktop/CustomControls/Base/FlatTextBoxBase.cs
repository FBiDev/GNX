﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GNX.Desktop
{
    public partial class FlatTextBoxBase : UserControl
    {
        #region Defaults
        [DefaultValue(typeof(Padding), "2, 2, 2, 2")]
        public new Padding Margin
        {
            get { return base.Margin; }
            set { base.Margin = value; }
        }
        #endregion

        #region Properties
        protected Color _BorderColor = Color.FromArgb(213, 223, 229);
        [Category("_Colors"), DefaultValue(typeof(Color), "213, 223, 229")]
        public Color BorderColor { get { return _BorderColor; } set { _BorderColor = value; } }

        protected Color _BorderColorFocus = Color.FromArgb(108, 132, 199);
        [Category("_Colors"), DefaultValue(typeof(Color), "108, 132, 199")]
        public Color BorderColorFocus { get { return _BorderColorFocus; } set { _BorderColorFocus = value; } }

        protected Color _BackgroundColor = Color.White;
        [Category("_Colors"), DefaultValue(typeof(Color), "White")]
        public Color BackgroundColor { get { return _BackgroundColor; } set { _BackgroundColor = value; } }

        protected Color _LabelTextColor = Color.FromArgb(108, 132, 199);
        [Category("_Colors"), DefaultValue(typeof(Color), "108, 132, 199")]
        public Color LabelTextColor { get { return _LabelTextColor; } set { _LabelTextColor = value; } }

        [Category("_Colors"), DefaultValue(typeof(string), "Label")]
        public string LabelText { get { return lblSubtitle.Text; } set { lblSubtitle.Text = value; } }
        #endregion

        public FlatTextBoxBase()
        {
            InitializeComponent();

            pnlContent.MouseEnter += PnlBg_MouseEnter;
            lblSubtitle.MouseEnter += LblSubtitle_MouseEnter;

            Margin = new Padding(2);
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            BackColor = BorderColor;
            pnlContent.BackColor = BackgroundColor;

            lblSubtitle.BackColor = BackgroundColor;
            lblSubtitle.ForeColor = LabelTextColor;
        }

        protected void ChangeCursor()
        {
            if (TabStop)
                Cursor = Cursors.IBeam;
            else
                Cursor = Cursors.No;
        }

        protected void ChangeCursor2()
        {
            if (TabStop)
                Cursor = Cursors.Default;
            else
                Cursor = Cursors.No;
        }

        protected void TextBoxBase_Paint(object sender, PaintEventArgs e)
        {
            if (Parent != null)
            {
                //this.MaximumSize = new Size(Parent.Width, this.MaximumSize.Height);
                //if (Width > MaximumSize.Width)
                //{
                //    Width = MaximumSize.Width;
                //}
            }
        }

        protected void PnlBg_MouseEnter(object sender, EventArgs e)
        {
            ChangeCursor();
        }

        protected void LblSubtitle_MouseEnter(object sender, EventArgs e)
        {
            ChangeCursor2();
        }
    }
}
