using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GNX
{
    public partial class FlatStatusBar : UserControl
    {
        private int? _registros;
        private Movimento _movimento;

        public int? Registros
        {
            get { return _registros; }
            set
            {
                _registros = value;

                if (value == null || value <= 0)
                {
                    lblStatus1.Text = string.Empty;
                }
                else
                {
                    lblStatus1.Text = value.ToString() + " registro";

                    if (cConvert.ToInt(value) > 1)
                    {
                        lblStatus1.Text += "s";
                    }
                }
            }
        }

        public Movimento Movimento
        {
            get { return _movimento; }
            set
            {
                _movimento = value;

                if (value == Movimento.Nenhum)
                {
                    lblStatus2.Text = string.Empty;
                }
                else
                {
                    lblStatus2.Text = value.ToString();
                }
            }
        }

        public FlatStatusBar()
        {
            InitializeComponent();

            Load += FlatStatusBar_Load;
            lblStatus2.TextChanged += lblStatus2_TextChanged;
        }

        private void FlatStatusBar_Load(object sender, EventArgs e)
        {
            lblStatus2_TextChanged(null, null);
        }

        private void lblStatus2_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblStatus2.Text.Trim()))
            {
                pnlStatus2.Visible = false;
                return;
            }
            pnlStatus2.Visible = true;
        }
    }
}
