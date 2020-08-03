using System;
using System.Drawing;
using System.Windows.Forms;
//

namespace GNX
{
    public partial class MenuBar : UserControl
    {
        private MenuMode _Modo;
        public MenuMode Modo
        {
            get { return _Modo; }
            set
            {
                _Modo = value;
                lblModo.Text = _Modo.ToString();
            }
        }

        public MenuBar()
        {
            InitializeComponent();
            TabStop = false;
            Modo = MenuMode.Consulta;
        }

        private void pnlMenuBar_SizeChanged(object sender, EventArgs e)
        {
            int ctrs = pnlMenuBar.Controls.Count;
            int each = pnlMenuBar.Width / ctrs;
            int cItem = 0;

            foreach (Control c in pnlMenuBar.Controls)
            {
                Point newLocation = new Point((each / 2) - (c.Width / 2) + cItem * each, c.Location.Y);
                c.Location = newLocation;
                cItem++;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //lblModo.Text = Modo.ToString();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Modo = MenuMode.Inclusão;

            btnSave.Visible = true;
            btnDelete.Visible = true;
        }
    }
}
