using System;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace GNX
{
    public partial class FlatMaskedTextBox : FlatTextBoxBase
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

        int MaxLength;
        TextMask _Mask_;

        [Category("_Properties")]
        [DefaultValue(typeof(string), "")]
        public TextMask _Mask
        {
            get { return _Mask_; }
            set
            {
                _Mask_ = value;

                TextBox.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                txtMain.Mask = "";
                txtMain.PromptChar = '_';

                MaxLength = 50;
                switch (_Mask_)
                {
                    case TextMask.None:
                        lblPlaceholder.Text = "";
                        break;
                    case TextMask.CPF:
                        txtMain.Mask = "000.000.000-00";
                        lblPlaceholder.Text = "000.000.000-00";
                        break;
                    case TextMask.CNPJ:
                        txtMain.Mask = "00.000.000/0000-00";
                        lblPlaceholder.Text = "00.000.000/0000-00";
                        break;
                    case TextMask.DATA:
                        txtMain.Mask = "00/00/0000";
                        lblPlaceholder.Text = "00/00/0000";
                        txtMain.TextMaskFormat = MaskFormat.IncludeLiterals;
                        break;
                    case TextMask.HORA:
                        txtMain.Mask = "00:00";
                        lblPlaceholder.Text = "00:00";
                        break;
                    case TextMask.CELULAR:
                        txtMain.Mask = "(00) 00000-0009";
                        lblPlaceholder.Text = "(00) 00000-0000";
                        break;
                    case TextMask.NUMERO:
                        lblPlaceholder.Text = "999";
                        MaxLength = 10;
                        break;
                    case TextMask.DINHEIRO:
                        lblPlaceholder.Text = "999,00";
                        break;
                    case TextMask.CEP:
                        txtMain.Mask = "00000-000";
                        lblPlaceholder.Text = "80000-100";
                        break;
                }
            }
        }
        #endregion

        MaskedTextBox TextBox { get { return txtMain; } }
        public new string Text { get { return TextBox.Text; } set { TextBox.Text = value; } }

        public enum eTextAlign { Left, Right, Center }
        eTextAlign _TextAlign;
        public eTextAlign TextAlign
        {
            get { return _TextAlign; }
            set
            {
                _TextAlign = value;
                switch (_TextAlign)
                {
                    case eTextAlign.Left:
                        lblPlaceholder.TextAlign = ContentAlignment.MiddleLeft;
                        txtMain.TextAlign = HorizontalAlignment.Left;
                        break;
                    case eTextAlign.Right:
                        lblPlaceholder.TextAlign = ContentAlignment.MiddleRight;
                        txtMain.TextAlign = HorizontalAlignment.Right;
                        break;
                    case eTextAlign.Center:
                        lblPlaceholder.TextAlign = ContentAlignment.MiddleCenter;
                        txtMain.TextAlign = HorizontalAlignment.Center;
                        break;
                }
            }
        }

        public FlatMaskedTextBox()
        {
            InitializeComponent();

            TextBox.Culture = System.Globalization.CultureInfo.InvariantCulture;

            lblPlaceholder.MouseEnter += lblPlaceholder_MouseEnter;

            pnlBg.Click += pnlBg_Click;
            lblSubtitle.Click += lblSubtitle_Click;
            lblPlaceholder.Click += lblPlaceholder_Click;

            TextBox.KeyPress += TextBox_KeyPress;
            TextBox.KeyDown += TextBox_KeyDown;

            TextBox.GotFocus += TextBox_GotFocus;
            TextBox.LostFocus += TextBox_LostFocus;
            TextBox.TextChanged += TextBox_TextChanged;

            Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
            Size = new Size(206, 34);
            MaximumSize = new Size(800, 34);
            MinimumSize = new Size(100, 34);
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

        void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnKeyPress(e);
        }

        void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            OnKeyDown(e);
        }

        void TextBox_GotFocus(object sender, EventArgs e)
        {
            pnlBorder.BackColor = BorderColorFocus;
            pnlBg.BackColor = BackgroundColorFocus;
            lblSubtitle.BackColor = BackgroundColorFocus;

            TextBox.BackColor = BackgroundColorFocus;
            TextBox.ForeColor = TextColorFocus;

            TextBox_TextChanged(null, null);
        }

        void TextBox_LostFocus(object sender, EventArgs e)
        {
            pnlBorder.BackColor = BorderColor;
            pnlBg.BackColor = BackgroundColor;
            lblSubtitle.BackColor = BackgroundColor;

            TextBox.BackColor = BackgroundColor;
            TextBox.ForeColor = TextColor;

            TextBox_TextChanged(null, null);
        }

        protected void TextBox_TextChanged(object sender, EventArgs e)
        {
            string txt = txtMain.Text;

            if (_Mask == TextMask.DATA)
            {
                txt = txt.Replace("/", "").Trim();
            }
            else if (_Mask_ == TextMask.NUMERO)
            {
                string TextNew = "";
                int SelStart = txtMain.SelectionStart;

                foreach (char c in txtMain.Text)
                {
                    int result;
                    if (int.TryParse(c.ToString(), out result))
                    {
                        TextNew = TextNew.Insert(TextNew.Length, c.ToString());
                    }
                }

                if (TextNew.Length > MaxLength)
                {
                    TextNew = TextNew.Substring(0, MaxLength);
                }

                txtMain.Text = TextNew;
                txtMain.SelectionStart = SelStart;
            }

            lblPlaceholder.Visible = !TextBox.Focused && (TextBox.Text.Length == 0 || txt.Length == 0);
        }
    }
}