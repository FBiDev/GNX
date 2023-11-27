﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GNX.Desktop
{
    public partial class ButtonExe : UserControl
    {
        [DefaultValue(typeof(Size), "76, 69")]
        public new Size Size { get { return base.Size; } set { base.Size = value; } }

        [DefaultValue(typeof(Padding), "1, 1, 1, 1")]
        public new Padding Padding
        {
            get { return base.Padding; }
            set { base.Padding = value; }
        }

        [DefaultValue(typeof(Padding), "2, 2, 2, 2")]
        public new Padding Margin
        {
            get { return base.Margin; }
            set { base.Margin = value; }
        }

        [DefaultValue(typeof(Color), "Transparent")]
        public Color BorderColor { get { return base.BackColor; } set { base.BackColor = value; } }

        [DefaultValue(typeof(Color), "Transparent")]
        public new Color BackColor { get { return pnlBack.BackColor; } set { pnlBack.BackColor = value; } }

        public Button Btn { get { return btnExe; } }

        [DefaultValue(typeof(Size), "48, 48")]
        public Size SizeButton { get { return btnExe.Size; } set { btnExe.Size = value; } }
        public new Image BackgroundImage { get { return btnExe.BackgroundImage; } set { btnExe.BackgroundImage = value; } }
        public new ImageLayout BackgroundImageLayout { get { return btnExe.BackgroundImageLayout; } set { btnExe.BackgroundImageLayout = value; } }

        public new Font Font { get { return lblExe.Font; } set { lblExe.Font = value; } }
        public string TextLabel { get { return lblExe.Text; } set { lblExe.Text = value; } }

        protected Color _TextColor = Color.FromArgb(47, 47, 47);
        [Category("_Colors"), DefaultValue(typeof(Color), "47, 47, 47")]
        public Color TextColor
        {
            get { return lblExe.ForeColor; }
            set { lblExe.ForeColor = value; }
        }

        public new event EventHandler Click;

        public ButtonExe()
        {
            InitializeComponent();

            Btn.MouseEnter += OnMouseEnter;
            Btn.MouseLeave += OnMouseLeave;
            Btn.Click += OnClick;
            Btn.SizeChanged += OnSizeChanged;
            SizeChanged += OnSizeChanged;

            BackColor = Colors.RGB(151, 184, 243);
            BorderColor = Color.WhiteSmoke;
            TextColor = _TextColor;
        }

        void AlignControl()
        {
            var newLocation = new Point((pnlBack.Width - btnExe.Width) / 2, btnExe.Location.Y);
            btnExe.Location = newLocation;
        }
        void OnSizeChanged(object sender, EventArgs e)
        {
            AlignControl();
        }

        void OnClick(object sender, EventArgs e)
        {
            if (Click.IsNull()) { return; }
            Click(sender, e);
        }

        void OnMouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        void OnMouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }
    }
}