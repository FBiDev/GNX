﻿using System;
using System.Windows.Forms;
//
using System.Drawing;
using System.ComponentModel;

namespace GNX
{
    public partial class FlatTextBox : FlatTextBoxBase
    {
        #region Defaults
        [DefaultValue(typeof(Size), "800, 34")]
        public new Size MaximumSize
        {
            get { return base.MaximumSize; }
            set { base.MaximumSize = value; }
        }

        [DefaultValue(typeof(Size), "100, 34")]
        public new Size MinimumSize
        {
            get { return base.MinimumSize; }
            set { base.MinimumSize = value; }
        }

        [DefaultValue(typeof(AnchorStyles), "Top, Left, Right")]
        public new AnchorStyles Anchor
        {
            get { return base.Anchor; }
            set { base.Anchor = value; }
        }
        #endregion

        #region Properties
        [Category("_Properties")]
        public Color _BackgroundColorFocus { get { return BackgroundColorFocus; } }
        public Color BackgroundColorFocus = Color.FromArgb(252, 245, 237);

        [Category("_Properties")]
        public Color _TextColor { get { return TextColor; } }
        protected Color TextColor = Color.FromArgb(47, 47, 47);

        [Category("_Properties")]
        public Color _TextColorFocus { get { return TextColorFocus; } }
        protected Color TextColorFocus = Color.FromArgb(47, 47, 47);

        [Category("_Properties")]
        [DefaultValue(typeof(string), "")]
        public string DefaultText { get { return TextBox.Text; } set { TextBox.Text = value; } }

        [Category("_Properties")]
        [DefaultValue(typeof(string), "")]
        public string PlaceholderText { get { return lblPlaceholder.Text; } set { lblPlaceholder.Text = value; } }
        #endregion

        #region TextBox
        private TextBox TextBox { get { return txtMain; } }
        public Color TextBoxColor { get { return TextBox.BackColor; } set { TextBox.BackColor = value; lblPlaceholder.BackColor = value; } }
        public new string Text { get { return TextBox.Text; } set { TextBox.Text = value; } }

        public new bool Focused { get; set; }

        public new EventHandler TextChanged;
        public new EventHandler Enter;
        public new EventHandler Leave;
        public new KeyPressEventHandler KeyPress;
        #endregion

        public FlatTextBox()
        {
            InitializeComponent();

            lblPlaceholder.MouseEnter += lblPlaceholder_MouseEnter;

            pnlBg.Click += pnlBg_Click;
            lblSubtitle.Click += lblSubtitle_Click;
            lblPlaceholder.Click += lblPlaceholder_Click;

            lblPlaceholder.BackColor = BackgroundColor;

            TextBox.KeyPress += TextBox_KeyPress;
            TextBox.KeyDown += TextBox_KeyDown;

            TextBox.GotFocus += TextBox_GotFocus;
            TextBox.LostFocus += TextBox_LostFocus;
            TextBox.TextChanged += TextBox_TextChanged;

            TextBox.Enter += TextBox_Enter;
            TextBox.Leave += TextBox_Leave;

            Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
            Size = new Size(206, 34);
            MaximumSize = new Size(800, 34);
            MinimumSize = new Size(100, 34);
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            pnlBorder.BackColor = BorderColor;
            pnlBg.BackColor = BackgroundColor;

            lblSubtitle.BackColor = BackgroundColor;
            lblSubtitle.ForeColor = LabelTextColor;

            TextBox.BackColor = BackgroundColor;
            TextBox.ForeColor = TextColor;
        }

        protected void lblPlaceholder_MouseEnter(object sender, EventArgs e)
        {
            ChangeCursor();
        }

        protected void pnlBg_Click(object sender, EventArgs e)
        {
            TextBox.Focus();
        }

        protected void lblSubtitle_Click(object sender, EventArgs e)
        {
            TextBox.Focus();
        }

        protected void lblPlaceholder_Click(object sender, EventArgs e)
        {
            TextBox.Focus();
        }

        private void TextBox_Enter(object sender, EventArgs e) { if (Enter.NotNull()) { Enter(sender, e); } }
        private void TextBox_Leave(object sender, EventArgs e) { if (Leave.NotNull()) { Leave(sender, e); } }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (KeyPress.NotNull())
            {
                KeyPress(sender, e);
            }

            OnKeyPress(e);
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            OnKeyDown(e);
        }

        private void TextBox_GotFocus(object sender, EventArgs e)
        {
            pnlBorder.BackColor = BorderColorFocus;
            pnlBg.BackColor = BackgroundColorFocus;
            lblSubtitle.BackColor = BackgroundColorFocus;

            TextBox.BackColor = BackgroundColorFocus;
            TextBox.ForeColor = TextColorFocus;

            lblPlaceholder.Visible = false;
            Focused = true;
        }

        private void TextBox_LostFocus(object sender, EventArgs e)
        {
            pnlBorder.BackColor = BorderColor;
            pnlBg.BackColor = BackgroundColor;
            lblSubtitle.BackColor = BackgroundColor;

            TextBox.BackColor = BackgroundColor;
            TextBox.ForeColor = TextColor;

            lblPlaceholder.Visible = TextBox.Text.Length == 0;
            Focused = false;
        }

        protected void TextBox_TextChanged(object sender, EventArgs e)
        {
            if (TextChanged.NotNull())
            {
                TextChanged(sender, e);
            }

            if (!TextBox.Focused)
            {
                lblPlaceholder.Visible = TextBox.Text.Length == 0;
            }
        }
    }
}
