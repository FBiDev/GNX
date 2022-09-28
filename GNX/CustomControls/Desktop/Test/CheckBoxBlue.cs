using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
//

namespace GNX
{
    public partial class CheckBoxBlue : UserControl
    {
        [Category("_Data")]
        public string _Legend
        {
            get { return lblLegend.Text; }
            set
            {
                lblLegend.Text = value;
                AlignControl();
            }
        }

        public bool Checked { get { return CheckBox.Checked; } set { CheckBox.Checked = value; } }
        public event EventHandler CheckedChanged;

        public CheckBoxBlue()
        {
            InitializeComponent();

            CheckBox.CheckedChanged += chkBox_CheckedChanged;

            AlignControl();
        }

        private CheckBox CheckBox
        {
            get
            {
                return chkBox;
            }
        }

        private void AlignControl()
        {
            Point newLocation = new Point((pnlBgWhite.Width / 2) - (CheckBox.Width / 2), CheckBox.Location.Y);
            CheckBox.Location = newLocation;

            newLocation = new Point((pnlBgWhite.Width / 2) - (lblLegend.Width / 2), lblLegend.Location.Y);
            lblLegend.Location = newLocation;
        }

        private void CheckBoxBlue_SizeChanged(object sender, EventArgs e)
        {
            AlignControl();
        }

        private void pnlBgWhite_Click(object sender, EventArgs e)
        {
            CheckBox.Focus();
            Checked = !CheckBox.Checked;
        }

        private void pnlBgWhite_DoubleClick(object sender, EventArgs e)
        {
            pnlBgWhite_Click(null, null);
        }

        private void lblLegend_Click(object sender, EventArgs e)
        {
            pnlBgWhite_Click(null, null);
        }

        private void pnlBgWhite_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void chkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckedChanged.NotNull())
            {
                CheckedChanged(null, null);
            }

            if (CheckBox.Checked)
            {
                CheckBox.BackColor = Color.LightGreen;
            }
            else
            {
                CheckBox.BackColor = Color.LightCoral;
            }
        }

        private void chkBox_Enter(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(108, 132, 199);
        }

        private void CheckBoxBlue_Leave(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(213, 223, 229);
        }
    }
}
