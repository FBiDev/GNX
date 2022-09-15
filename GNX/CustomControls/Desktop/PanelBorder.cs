﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GNX
{
    public partial class PanelBorder : Panel
    {
        private Color _BorderColor = ColorTranslator.FromHtml("#A0A0A0");

        [Browsable(true)]
        [DefaultValue(typeof(Color), "0xA0A0A0")]
        public Color BorderColor
        {
            get { return _BorderColor; }
            set { _BorderColor = value; }
        }

        public PanelBorder()
        {
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            Padding = new Padding(2);
        }

        protected override void OnControlAdded(ControlEventArgs e) { }

        protected override void OnPaint(PaintEventArgs e)
        {
            int thickness = 1;

            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle,
                BorderColor, thickness, ButtonBorderStyle.Solid,
                BorderColor, thickness, ButtonBorderStyle.Solid,
                BorderColor, thickness, ButtonBorderStyle.Solid,
                BorderColor, thickness, ButtonBorderStyle.Solid);
        }
    }
}