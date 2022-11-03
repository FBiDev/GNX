using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
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

        [DefaultValue(typeof(Padding), "2, 2, 2, 2")]
        public new Padding Padding
        {
            get { return base.Padding; }
            set { base.Padding = value; }
        }

        public PanelBorder()
        {
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
        }

        protected override void OnControlAdded(ControlEventArgs e) { }

        protected override void OnPaint(PaintEventArgs e)
        {
            //int thickness = 1;
            //ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle,
            //    BorderColor, thickness, ButtonBorderStyle.Solid,
            //    BorderColor, thickness, ButtonBorderStyle.Solid,
            //    BorderColor, thickness, ButtonBorderStyle.Solid,
            //    BorderColor, thickness, ButtonBorderStyle.Solid);
            e.Graphics.DrawRoundBorder(this, BorderColor);
        }
    }
}
