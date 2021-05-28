﻿using System;
using System.Windows.Forms;
//
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
            set { base.BackColor = value; }
        }

        [DefaultValue(typeof(Color), "47, 47, 47")]
        public new Color ForeColor
        {
            get { return base.ForeColor; }
            set { base.ForeColor = value; }
        }

        [DefaultValue(typeof(Font), "Segoe UI, 9")]
        public new Font Font
        {
            get { return base.Font; }
            set { base.Font = value; }
        }

        [DefaultValue(typeof(Size), "80, 34")]
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

        [DefaultValue(typeof(AnchorStyles), "Top")]
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
        protected Color BackgroundColor = Color.FromArgb(237, 237, 237);

        [Category("_Properties")]
        public Color _BackgroundColorFocus { get { return BackgroundColorFocus; } }
        protected Color BackgroundColorFocus = Color.FromArgb(213, 213, 213);

        [Category("_Properties")]
        public Color _TextColor { get { return TextColor; } }
        protected Color TextColor = Color.FromArgb(47, 47, 47);
        #endregion

        public FlatButton()
        {
            Cursor = Cursors.Hand;
            Anchor = AnchorStyles.Top;
            ImageAlign = ContentAlignment.MiddleLeft;
            Font = new Font("Segoe UI", 9);
            Size = new Size(80, 34);

            base.UseVisualStyleBackColor = false;
            FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            //foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(this))
            //    property.ResetValue(this);
        }

        protected override void OnHandleCreated(EventArgs e)
        {
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
            get
            {
                return false;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Draw Border using color specified in Flat Appearance
            Pen pen = new Pen(FlatAppearance.BorderColor, 1);
            Rectangle rectangle = new Rectangle(0, 0, Size.Width - 1, Size.Height - 1);
            e.Graphics.DrawRectangle(pen, rectangle);

            if (Focused)
            {
                Pen penDot = new Pen(SystemColors.ControlDarkDark, 1);
                penDot.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                Rectangle rectangleDot = new Rectangle(2, 2, Size.Width - 5, Size.Height - 5);
                e.Graphics.DrawRectangle(penDot, rectangleDot);
            }
        }
    }
}