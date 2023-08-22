﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GNX.Desktop
{
    public partial class FlatTextBox : FlatTextBoxBase
    {
        #region Defaults
        [DefaultValue(typeof(Size), "1500, 34")]
        public new Size MaximumSize
        {
            get { return base.MaximumSize; }
            set { base.MaximumSize = value; }
        }

        [DefaultValue(typeof(Size), "64, 34")]
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
        public Color _BackgroundColorFocus = Color.FromArgb(252, 245, 237);
        [Category("_Colors"), DefaultValue(typeof(Color), "252, 245, 237")]
        public Color BackgroundColorFocus { get { return _BackgroundColorFocus; } set { _BackgroundColorFocus = value; } }

        protected Color _TextColor = Color.FromArgb(47, 47, 47);
        [Category("_Colors"), DefaultValue(typeof(Color), "47, 47, 47")]
        public Color TextColor { get { return _TextColor; } set { _TextColor = value; } }

        [Category("_Colors"), DefaultValue(typeof(Color), "47, 47, 47")]
        public Color TextColorFocus { get { return _TextColorFocus; } set { _TextColorFocus = value; } }
        protected Color _TextColorFocus = Color.FromArgb(47, 47, 47);

        [Category("_Colors"), DefaultValue(typeof(string), "")]
        public string DefaultText { get { return TextBox.Text; } set { TextBox.Text = value; } }

        [Category("_Colors"), DefaultValue(typeof(string), "")]
        public string PlaceholderText { get { return lblPlaceholder.Text; } set { lblPlaceholder.Text = value; } }
        #endregion

        #region TextBox
        TextBox TextBox { get { return txtMain; } }
        public new string Text { get { return TextBox.Text; } set { TextBox.Text = value; } }

        [DefaultValue(0)]
        public int SelectionStart
        {
            get { return TextBox.SelectionStart; }
            set { TextBox.SelectionStart = value; }
        }

        [DefaultValue(0)]
        public int SelectionLength
        {
            get { return TextBox.SelectionLength; }
            set { TextBox.SelectionLength = value; }
        }

        [DefaultValue(false)]
        public bool ReadOnly { get { return TextBox.ReadOnly; } set { TextBox.ReadOnly = value; } }

        [DefaultValue(false)]
        public bool Multiline { get { return TextBox.Multiline; } set { TextBox.Multiline = value; } }

        [DefaultValue(typeof(ScrollBars), "None")]
        public ScrollBars ScrollBars { get { return TextBox.ScrollBars; } set { TextBox.ScrollBars = value; } }

        public string previousText { get; set; }
        string previousTextBackup { get; set; }
        bool previousTextChanged { get; set; }

        public new bool Focused { get; set; }

        public new event EventHandler TextChanged;
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

            TextBox.KeyPress += TextBox_KeyPress;
            TextBox.KeyDown += TextBox_KeyDown;
            TextBox.KeyUp += TextBox_KeyUp;
            TextBox.MouseUp += TextBox_MouseUp;

            TextBox.GotFocus += TextBox_GotFocus;
            TextBox.LostFocus += TextBox_LostFocus;
            TextBox.TextChanged += TextBox_TextChanged;

            TextBox.Enter += TextBox_Enter;
            TextBox.Leave += TextBox_Leave;

            Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
            Size = new Size(206, 34);
            MaximumSize = new Size(1500, 34);
            MinimumSize = new Size(64, 34);
        }

        public void ResetColors()
        {
            pnlBorder.BackColor = BorderColor;
            pnlBg.BackColor = BackgroundColor;

            lblSubtitle.BackColor = BackgroundColor;
            lblSubtitle.ForeColor = LabelTextColor;

            lblPlaceholder.BackColor = BackgroundColor;

            TextBox.BackColor = BackgroundColor;
            TextBox.ForeColor = TextColor;
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            ResetColors();

            previousText = TextBox.Text;
            previousTextBackup = TextBox.Text;

            if (TextBox.ScrollBars == ScrollBars.None)
                TextBox.Height += 15;
            else
                TextBox.Height -= 15;
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

        void TextBox_Enter(object sender, EventArgs e) { if (Enter.NotNull()) { Enter(sender, e); } }
        void TextBox_Leave(object sender, EventArgs e) { if (Leave.NotNull()) { Leave(sender, e); } }

        void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (KeyPress.NotNull())
            {
                KeyPress(sender, e);
            }

            OnKeyPress(e);
        }

        //bool prevent;
        void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            //e.SuppressKeyPress = prevent;
            OnKeyDown(e);
        }

        void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            //prevent = false;
            OnKeyUp(e);
        }

        void TextBox_MouseUp(object sender, MouseEventArgs e)
        {
            OnMouseUp(e);
        }

        void TextBox_GotFocus(object sender, EventArgs e)
        {
            pnlBorder.BackColor = BorderColorFocus;
            pnlBg.BackColor = BackgroundColorFocus;
            lblSubtitle.BackColor = BackgroundColorFocus;

            TextBox.BackColor = BackgroundColorFocus;
            TextBox.ForeColor = TextColorFocus;

            lblPlaceholder.Visible = false;
            Focused = true;
        }

        void TextBox_LostFocus(object sender, EventArgs e)
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
            if (!TextBox.Focused)
            {
                lblPlaceholder.Visible = TextBox.Text.Length == 0;
            }

            if (TextChanged.IsNull()) { return; }

            //prevent = true;

            if (previousTextBackup != TextBox.Text)
            {
                previousTextChanged = !previousTextChanged;

                if (previousTextChanged)
                {
                    previousTextChanged = false;
                    previousText = previousTextBackup;
                }

                previousTextBackup = TextBox.Text;
            }

            TextChanged(sender, e);
        }
    }
}