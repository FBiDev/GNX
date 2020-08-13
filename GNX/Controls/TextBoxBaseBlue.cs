using System;
using System.Windows.Forms;
//
using System.ComponentModel;
using System.Drawing;

namespace GNX
{
    public partial class TextBoxBaseBlue : UserControl
    {
        #region Properties
        [Category("_Data")]
        public string _Legend { get { return lblLegend.Text; } set { lblLegend.Text = value; } }
        [Category("_Data")]
        public string _Placeholder { get { return lblPlaceholder.Text; } set { lblPlaceholder.Text = value; } }

        private Color _BorderColorVar;
        [Category("_Data")]
        protected Color _BorderColor
        {
            get { return _BorderColorVar; }
            set
            {
                _BorderColorVar = value;
                pnlBg.BackColor = _BorderColorVar;
            }
        }

        private Color _BorderColorFocusVar;
        [Category("_Data")]
        protected Color _BorderColorFocus
        {
            get { return _BorderColorFocusVar; }
            set
            {
                _BorderColorFocusVar = value;
            }
        }
        #endregion

        public TextBoxBaseBlue()
        {
            InitializeComponent();

            //_Legend = "Legend";
            //_Placeholder = "Placeholder";
            _BorderColor = Color.FromArgb(213, 223, 229);
            _BorderColorFocus = Color.FromArgb(108, 132, 199);
            //LegendColor
            //TextColor
            TabIndex = 0;

            //TxtTextChanged += txtBlue_event;
        }

        protected void _MouseHover()
        {
            pnlBg.BackColor = _BorderColorFocus;
        }

        protected void _MouseLeave()
        {
            pnlBg.BackColor = _BorderColor;
        }

        protected void TextBoxBaseBlue_Paint(object sender, PaintEventArgs e)
        {
            if (Parent != null)
            {
                this.MaximumSize = new Size(Parent.Width, this.MaximumSize.Height);
                if (Width > MaximumSize.Width)
                {
                    Width = MaximumSize.Width;
                }
            }
        }

        protected void pnlBgWhite_MouseEnter(object sender, EventArgs e)
        {
            //_MouseHover();
            Cursor = Cursors.IBeam;
        }

        protected void lblLegend_MouseEnter(object sender, EventArgs e)
        {
            //_MouseHover();
            Cursor = Cursors.Default;
        }

        protected void lblPlaceholder_MouseEnter(object sender, EventArgs e)
        {
            //_MouseHover();
            Cursor = Cursors.IBeam;
        }
    }
}
