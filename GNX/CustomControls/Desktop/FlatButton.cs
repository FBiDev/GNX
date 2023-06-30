using System;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace GNX
{
    public class FlatButton : Button
    {
        #region Defaults
        [DefaultValue(typeof(Color), "237, 237, 237")]
        public new Color BackColor
        {
            get { return base.BackColor; }
            set
            {
                base.BackColor = value;
                BackgroundColor = value;
            }
        }

        [DefaultValue(typeof(Color), "47, 47, 47")]
        public new Color ForeColor
        {
            get { return base.ForeColor; }
            set
            {
                base.ForeColor = value;
                TextColor = value;
            }
        }

        [DefaultValue(typeof(Font), "Segoe UI, 9")]
        public new Font Font
        {
            get { return base.Font; }
            set { base.Font = value; }
        }

        [DefaultValue(typeof(Size), "82, 34")]
        public new Size Size
        {
            get { return base.Size; }
            set { base.Size = value; }
        }

        [DefaultValue(typeof(bool), "false")]
        public new bool UseVisualStyleBackColor
        {
            get { return base.UseVisualStyleBackColor; }
        }

        [DefaultValue(typeof(ContentAlignment), "MiddleLeft")]
        public new ContentAlignment ImageAlign
        {
            get { return base.ImageAlign; }
            set { base.ImageAlign = value; }
        }

        [DefaultValue(typeof(AnchorStyles), "Top, Left")]
        public new AnchorStyles Anchor
        {
            get { return base.Anchor; }
            set { base.Anchor = value; }
        }

        [DefaultValue(typeof(Cursor), "Hand")]
        public new Cursor Cursor
        {
            get { return base.Cursor; }
            set { base.Cursor = value; }
        }

        [DefaultValue(typeof(FlatStyle), "Flat")]
        public new FlatStyle FlatStyle
        {
            get { return base.FlatStyle; }
            set { base.FlatStyle = value; }
        }

        [DefaultValue(typeof(Size), "24, 24")]
        public new Size MinimumSize
        {
            get { return base.MinimumSize; }
            set { base.MinimumSize = value; }
        }
        #endregion

        #region Properties
        protected Color BackgroundColor = Color.FromArgb(237, 237, 237);
        [Category("_Properties"), DefaultValue(typeof(Color), "237, 237, 237")]
        public Color _BackgroundColor
        {
            get { return BackgroundColor; }
            set
            {
                BackgroundColor = value;
                BackColor = value;
            }
        }

        protected Color BackgroundColorFocus = Color.FromArgb(213, 213, 213);
        [Category("_Properties"), DefaultValue(typeof(Color), "213, 213, 213")]
        public Color _BackgroundColorFocus
        {
            get { return BackgroundColorFocus; }
            set
            {
                BackgroundColorFocus = value;
                FlatAppearance.MouseOverBackColor = value;
            }
        }

        protected Color BorderColorDefault;
        protected Color BorderColor = Color.FromArgb(213, 223, 229);
        [Category("_Properties"), DefaultValue(typeof(Color), "213, 223, 229")]
        public Color _BorderColor
        {
            get { return BorderColor; }
            set
            {
                BorderColor = value;
                FlatAppearance.BorderColor = value;
            }
        }

        protected Color BorderColorFocus = Color.FromArgb(108, 132, 199);
        [Category("_Properties"), DefaultValue(typeof(Color), "108, 132, 199")]
        public Color _BorderColorFocus
        {
            get { return BorderColorFocus; }
            set { BorderColorFocus = value; }
        }

        protected Color TextColor = Color.FromArgb(47, 47, 47);
        [Category("_Properties"), DefaultValue(typeof(Color), "47, 47, 47")]
        public Color _TextColor
        {
            get { return TextColor; }
            set
            {
                TextColor = value;
                ForeColor = value;
            }
        }

        protected Color SelectedColor = Color.FromArgb(203, 223, 254);
        [Category("_Properties"), DefaultValue(typeof(Color), "203, 223, 254")]
        public Color _SelectedColor { get { return SelectedColor; } }

        [DefaultValue(false)]
        public bool LockedColor { get; set; }

        public bool _Selected;
        [DefaultValue(false)]
        public bool Selected
        {
            get { return _Selected; }
            set
            {
                _Selected = value;
                if (_Selected)
                {
                    BackColor = SelectedColor;

                    if (BorderColorDefault == default(Color))
                        BorderColorDefault = BorderColor;
                    //BorderColor = BorderColorFocus;
                }
                else
                {
                    BackColor = BackgroundColor;

                    BorderColor = BorderColorDefault;
                    OnLostFocus(null);
                }
            }
        }
        #endregion

        public FlatButton()
        {
            Cursor = Cursors.Hand;
            Anchor = AnchorStyles.Top | AnchorStyles.Left;
            ImageAlign = ContentAlignment.MiddleLeft;
            Font = new Font("Segoe UI", 9);

            MinimumSize = new Size(24, 24);
            Size = new Size(82, 34);

            base.UseVisualStyleBackColor = false;
            FlatStyle = FlatStyle.Flat;

            //foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(this))
            //    property.ResetValue(this);
        }

        public virtual void DarkTheme()
        {
            BackgroundColor = ColorTranslator.FromHtml("#505050");
            BackgroundColorFocus = BackgroundColor;
            TextColor = ColorTranslator.FromHtml("#D2D2D2");
            BorderColor = ColorTranslator.FromHtml("#666666");
            SelectedColor = ColorTranslator.FromHtml("#191919");
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            if (LockedColor) return;

            // Prevent the button from drawing its own border
            FlatAppearance.BorderSize = 0;
            FlatAppearance.BorderColor = BorderColor;
            FlatAppearance.MouseOverBackColor = BackgroundColorFocus;

            BackColor = BackgroundColor;
            ForeColor = TextColor;
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            FlatAppearance.BorderColor = BorderColorFocus;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            if (!Focused) { FlatAppearance.BorderColor = BorderColor; }
        }

        protected override void OnGotFocus(EventArgs e)
        {
            FlatAppearance.BorderColor = BorderColorFocus;
        }

        protected override void OnLostFocus(EventArgs e)
        {
            FlatAppearance.BorderColor = BorderColor;
        }

        protected override bool ShowFocusCues
        {
            get { return false; }
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);

            // Draw Border using color specified in Flat Appearance
            var pen = new Pen(FlatAppearance.BorderColor, 1);
            var rectangle = new Rectangle(0, 0, Size.Width - 1, Size.Height - 1);
            pevent.Graphics.DrawRectangle(pen, rectangle);

            if (Focused)
            {
                var penDot = new Pen(SystemColors.ControlDarkDark, 1);
                penDot.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                var rectangleDot = new Rectangle(2, 2, Size.Width - 5, Size.Height - 5);
                pevent.Graphics.DrawRectangle(penDot, rectangleDot);
            }
        }
    }
}