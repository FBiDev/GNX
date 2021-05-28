using System;
using System.Windows.Forms;
//
using System.Drawing;
using System.ComponentModel;

namespace GNX
{
    public partial class FlatTextBoxBase : UserControl
    {
        #region Defaults
        #endregion

        #region Properties
        [Category("_Properties")]
        public Color _BorderColor { get { return BorderColor; } }
        protected Color BorderColor = Color.FromArgb(213, 223, 229);

        [Category("_Properties")]
        public Color _BorderColorFocus { get { return BorderColorFocus; } }
        protected Color BorderColorFocus = Color.FromArgb(108, 132, 199);

        [Category("_Properties")]
        public Color _BackgroundColor { get { return BackgroundColor; } }
        protected Color BackgroundColor = Color.White;

        [Category("_Properties")]
        public Color _LabelTextColor { get { return LabelTextColor; } }
        protected Color LabelTextColor = Color.FromArgb(108, 132, 199);

        [Category("_Properties")]
        [DefaultValue(typeof(string), "Label")]
        public string LabelText { get { return lblSubtitle.Text; } set { lblSubtitle.Text = value; } }
        #endregion

        public FlatTextBoxBase()
        {
            InitializeComponent();

            pnlBg.MouseEnter += pnlBg_MouseEnter;
            lblSubtitle.MouseEnter += lblSubtitle_MouseEnter;
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            pnlBorder.BackColor = BorderColor;
            pnlBg.BackColor = BackgroundColor;

            lblSubtitle.BackColor = BackgroundColor;
            lblSubtitle.ForeColor = LabelTextColor;
        }

        protected void ChangeCursor()
        {
            Cursor = Cursors.IBeam;
        }

        protected void ChangeCursor2()
        {
            Cursor = Cursors.Default;
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

        protected void pnlBg_MouseEnter(object sender, EventArgs e)
        {
            ChangeCursor();
        }

        protected void lblSubtitle_MouseEnter(object sender, EventArgs e)
        {
            ChangeCursor2();
        }
    }
}
