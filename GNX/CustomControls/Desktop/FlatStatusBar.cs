using System;
using System.Windows.Forms;

namespace GNX
{
    public partial class FlatStatusBar : UserControl
    {
        int? _registros;
        Movimento _movimento;
        bool _BorderEnable = true;

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

        public bool BorderEnable
        {
            get { return _BorderEnable; }
            set
            {
                _BorderEnable = value;
                pnlBorder.Visible = _BorderEnable;
            }
        }

        public FlatStatusBar()
        {
            InitializeComponent();

            Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            Load += FlatStatusBar_Load;
            lblStatus1.TextChanged += lblStatus1_TextChanged;
            lblStatus2.TextChanged += lblStatus2_TextChanged;
        }

        void FlatStatusBar_Load(object sender, EventArgs e)
        {
            lblStatus1_TextChanged(null, null);
            lblStatus2_TextChanged(null, null);
        }

        void lblStatus2_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblStatus2.Text.Trim()))
            {
                pnlStatus2.Visible = false;
                return;
            }
            pnlStatus2.Visible = true;
        }

        void lblStatus1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblStatus1.Text.Trim()))
            {
                pnlStatus1.Visible = false;
                if (BorderEnable)
                {
                    //pnlBorder.Visible = false;
                }
                return;
            }
            pnlStatus1.Visible = true;
            if (BorderEnable)
            {
                //pnlBorder.Visible = true;
            }
        }
    }
}