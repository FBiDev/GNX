using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;
//

namespace GNX
{
    public partial class TextBoxBlue : UserControl
    {
        #region Properties
        private int MaxLength = 50;

        private TextMask _Mask_;
        [Category("_Data")]
        public TextMask _Mask
        {
            get { return _Mask_; }
            set
            {
                _Mask_ = value;
                string dot = CultureInfo.DefaultThreadCurrentUICulture.NumberFormat.NumberDecimalSeparator;
                //string dot = ".";
                if (_Mask_ == TextMask.None)
                {
                    txtBlue.Mask = "";
                    txtBlue.PromptChar = '_';
                    lblPlaceholder.Text = "Placeholder";
                }
                else if (_Mask_ == TextMask.CPF)
                {
                    txtBlue.Mask = "000" + dot + "000" + dot + "000-00";
                    txtBlue.PromptChar = '_';
                    lblPlaceholder.Text = "000" + dot + "000" + dot + "000-00";
                }
                else if (_Mask_ == TextMask.CNPJ)
                {
                    txtBlue.Mask = "00" + dot + "000" + dot + "000/0000-00";
                    txtBlue.PromptChar = '_';
                    lblPlaceholder.Text = "00" + dot + "000" + dot + "000/0000-00";
                }
                else if (_Mask_ == TextMask.DATA)
                {
                    txtBlue.Mask = "00/00/0000";
                    txtBlue.PromptChar = '_';
                    lblPlaceholder.Text = "00/00/0000";
                    lblPlaceholder.Left += 10;
                    txtBlue.TextMaskFormat = MaskFormat.IncludeLiterals;
                    txtBlue.TextAlign = HorizontalAlignment.Center;
                }
                else if (_Mask_ == TextMask.HORA)
                {
                    txtBlue.Mask = "00:00";
                    txtBlue.PromptChar = '_';
                    lblPlaceholder.Text = "00:00";
                    lblPlaceholder.Left += 25;
                    txtBlue.TextAlign = HorizontalAlignment.Center;
                }
                else if (_Mask_ == TextMask.CELULAR)
                {
                    txtBlue.Mask = "(00) 00000-0009";
                    txtBlue.PromptChar = '_';
                    lblPlaceholder.Text = "(00) 00000-0000";
                }
                else if (_Mask_ == TextMask.NUMERO)
                {
                    txtBlue.Mask = "";
                    txtBlue.PromptChar = '_';
                    MaxLength = 10;
                    lblPlaceholder.Text = "999";
                    lblPlaceholder.Left += 30;
                    txtBlue.TextAlign = HorizontalAlignment.Center;
                }
                else if (_Mask_ == TextMask.DINHEIRO)
                {
                    txtBlue.Mask = "";
                    txtBlue.PromptChar = '_';
                    //MaxLength = 10;
                    lblPlaceholder.Text = "999,00";
                    lblPlaceholder.Left += 30;
                    txtBlue.TextAlign = HorizontalAlignment.Center;

                }
            }
        }

        [Category("_Data")]
        public string _Legend { get { return lblLegend.Text; } set { lblLegend.Text = value; } }
        [Category("_Data")]
        public string _Placeholder { get { return lblPlaceholder.Text; } set { lblPlaceholder.Text = value; } }
        [Category("_Data")]
        public string _Text { get { return txtBlue.Text; } set { txtBlue.Text = value; } }

        private Color _BorderColorVar;
        [Category("_Data")]
        private Color _BorderColor
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
        private Color _BorderColorFocus
        {
            get { return _BorderColorFocusVar; }
            set
            {
                _BorderColorFocusVar = value;
            }
        }
        #endregion

        public TextBoxBlue()
        {
            InitializeComponent();

            _Legend = "Legend";
            _Placeholder = "Placeholder";
            _BorderColor = Color.FromArgb(213, 223, 229);
            _BorderColorFocus = Color.FromArgb(108, 132, 199);
            //LegendColor
            //TextColor
            TabIndex = 0;

            TxtTextChanged += txtBlue_event;
        }

        public MaskedTextBox TextBox
        {
            get { return txtBlue; }
        }

        // Assuming you need a custom signature for your event. If not, use an existing standard event delegate
        public delegate void txtTextChangedDelegate(object sender, EventArgs e);

        // Expose the event off your component
        public event txtTextChangedDelegate TxtTextChanged;

        private void _MouseHover()
        {
            pnlBg.BackColor = _BorderColorFocus;
        }

        private void _MouseLeave()
        {
            pnlBg.BackColor = _BorderColor;
        }

        private void TextBoxBlue_Paint(object sender, PaintEventArgs e)
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

        private void txtBlue_Enter(object sender, EventArgs e)
        {
            _MouseHover();
            lblPlaceholder.Visible = false;
        }

        private void txtBlue_Leave(object sender, EventArgs e)
        {
            _MouseLeave();
            if (txtBlue.Text.Length == 0)
            {
                lblPlaceholder.Visible = true;
            }
        }

        private void pnlBgWhite_MouseLeave(object sender, EventArgs e)
        {
            if (!txtBlue.Focused)
            {
                _MouseLeave();
            }
        }

        private void pnlBgWhite_MouseEnter(object sender, EventArgs e)
        {
            //_MouseHover();
            Cursor = Cursors.IBeam;
        }

        private void lblLegend_MouseEnter(object sender, EventArgs e)
        {
            //_MouseHover();
            Cursor = Cursors.Default;
        }

        private void lblPlaceholder_MouseEnter(object sender, EventArgs e)
        {
            //_MouseHover();
            Cursor = Cursors.IBeam;
        }

        private void txtBlue_MouseEnter(object sender, EventArgs e)
        {
            //_MouseHover();
        }

        private void pnlBgWhite_Click(object sender, EventArgs e)
        {
            txtBlue.Focus();
        }

        private void lblPlaceholder_Click(object sender, EventArgs e)
        {
            txtBlue.Focus();
        }

        private void lblLegend_Click(object sender, EventArgs e)
        {
            txtBlue.Focus();
        }

        private void txtBlue_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtBlue.MaskCompleted && txtBlue.MaskedTextProvider != null)
            {
                //txtBlue.SelectionStart = txtBlue.MaskedTextProvider.LastAssignedPosition + 1;
            }
            //apply MASK
            //if (_Mask == TextMask.CPF)
            //{
            //    if (txtBlue.Text.Length >= 3)
            //    {
            //        if (txtBlue.Text.Length >= 4 && txtBlue.Text[3] != '.')
            //        {
            //            txtBlue.Text = txtBlue.Text.Insert(3, ".");
            //            txtBlue.SelectionStart = txtBlue.Text.Length;
            //        }
            //    }

            //    if (txtBlue.Text.Length >= 7)
            //    {
            //        if (txtBlue.Text.Length >= 8 && txtBlue.Text[7] != '.')
            //        {
            //            txtBlue.Text = txtBlue.Text.Insert(7, ".");
            //            txtBlue.SelectionStart = txtBlue.Text.Length;
            //        }
            //    }

            //    if (txtBlue.Text.Length >= 11)
            //    {
            //        if (txtBlue.Text.Length >= 12 && txtBlue.Text[11] != '-')
            //        {
            //            txtBlue.Text = txtBlue.Text.Insert(11, "-");
            //            txtBlue.SelectionStart = txtBlue.Text.Length;
            //        }
            //    }
            //}
        }

        private void txtBlue_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == 8 || e.KeyChar == 3 || e.KeyChar == 22 || e.KeyChar == 24 || e.KeyChar == 25 || e.KeyChar == 26)
            //{
            //    string clip = Clipboard.GetText();
            //    if (e.KeyChar == 22 && clip.Length > txtBlue.SelectionLength)
            //    {
            //        e.Handled = true;
            //        return;
            //    }

            //    e.Handled = false;
            //    return;
            //}

            //if (_Mask == TextMask.NUMERO)
            //{
            //    //check if a number pressed
            //    if (Char.IsDigit(e.KeyChar))
            //    {

            //    }
            //    else
            //    {
            //        e.Handled = true;
            //    }
            //}

            //if (e.KeyChar == 8 || e.KeyChar == 3 || e.KeyChar == 22 || e.KeyChar == 24 || e.KeyChar == 25 || e.KeyChar == 26)
            //{
            //    string clip = Clipboard.GetText();
            //    if (e.KeyChar == 22 && clip.Length > txtBlue.SelectionLength)
            //    {
            //        e.Handled = true;
            //        return;
            //    }

            //    e.Handled = false;
            //    return;
            //}

            ////check if a number pressed
            //if (Char.IsDigit(e.KeyChar))
            //{
            //    if (txtBlue.Text.Length >= 0 && txtBlue.Text.Length < 14)
            //    {
            //        if (txtBlue.Text.Length >= 11 && txtBlue.Text[3] != '.')
            //        {
            //            e.Handled = true;
            //        }

            //        if (txtBlue.Text.Length >= 12 && txtBlue.Text[7] != '.')
            //        {
            //            e.Handled = true;
            //        }

            //        if (txtBlue.Text.Length >= 13 && txtBlue.Text[11] != '-')
            //        {
            //            e.Handled = true;
            //        }

            //    }
            //    else
            //    {
            //        e.Handled = true;
            //    }
            //}
            //else
            //{
            //    e.Handled = true;
            //}
        }

        private void txtBlue_TextChanged(object sender, EventArgs e)
        {
            lblPlaceholder.Visible = !(txtBlue.Text.Length > 0);

            if (_Mask_ == TextMask.NUMERO)
            {
                string TextNew = "";
                int SelStart = txtBlue.SelectionStart;
                foreach (char c in txtBlue.Text)
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
                txtBlue.Text = TextNew;
                txtBlue.SelectionStart = SelStart;
            }

            TxtTextChanged(sender, e);
        }

        private void txtBlue_event(object sender, EventArgs e)
        {
        }
    }
}
