using System;
using System.Windows.Forms;
//
using System.ComponentModel;

namespace GNX
{
    public partial class TextBoxBlue : TextBoxBaseBlue
    {
        [Category("_Data")]
        public string _Text { get { return txtBlue.Text; } set { txtBlue.Text = value; } }

        public TextBox TextBox
        {
            get { return txtBlue; }
        }

        public TextBoxBlue()
        {
            InitializeComponent();
        }

        protected void pnlBgWhite_MouseLeave(object sender, EventArgs e)
        {
            if (!txtBlue.Focused)
            {
                _MouseLeave();
            }
        }

        protected void pnlBgWhite_Click(object sender, EventArgs e)
        {
            txtBlue.Focus();
        }

        protected void lblLegend_Click(object sender, EventArgs e)
        {
            txtBlue.Focus();
        }

        protected void lblPlaceholder_Click(object sender, EventArgs e)
        {
            txtBlue.Focus();
        }

        protected void txtBlue_Enter(object sender, EventArgs e)
        {
            _MouseHover();
            lblPlaceholder.Visible = false;
        }

        protected void txtBlue_Leave(object sender, EventArgs e)
        {
            _MouseLeave();
            if (txtBlue.Text.Length == 0)
            {
                lblPlaceholder.Visible = true;
            }
        }

        protected void txtBlue_TextChanged(object sender, EventArgs e)
        {
            lblPlaceholder.Visible = !(txtBlue.Text.Length > 0);
        }
    }
}
