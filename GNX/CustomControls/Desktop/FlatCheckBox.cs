using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;

namespace GNX
{
    public partial class FlatCheckBox : UserControl
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

        public new Color BackColor
        {
            get { return pnlBgWhite.BackColor; }
            set { pnlBgWhite.BackColor = value; }
        }

        public Color BorderColor
        {
            get { return base.BackColor; }
            set { base.BackColor = value; }
        }

        public Color BorderColorFocus { get; set; }
        Color BorderColorLeave { get; set; }

        public FlatCheckBox()
        {
            InitializeComponent();

            CheckBox.CheckedChanged += chkBox_CheckedChanged;

            AlignControl();

            LightMode();
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            BorderColorLeave = BorderColor;
        }

        public void LightMode()
        {
            BorderColor = Color.FromArgb(213, 223, 229);
            BorderColorFocus = Color.FromArgb(108, 132, 199);
            BackColor = ColorTranslator.FromHtml("#FFFFFF");
        }

        public void DarkMode()
        {
            BorderColor = ColorTranslator.FromHtml("#424242");
            BorderColorFocus = Color.FromArgb(108, 132, 199);
            BackColor = ColorTranslator.FromHtml("#191919");
        }

        private CheckBox CheckBox
        {
            get { return chkBox; }
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

        private void lblLegend_DoubleClick(object sender, EventArgs e)
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
            base.BackColor = BorderColorFocus;
        }

        private void CheckBoxBlue_Leave(object sender, EventArgs e)
        {
            base.BackColor = BorderColorLeave;
        }

        private void pnlBgWhite_MouseDown(object sender, MouseEventArgs e)
        {
            chkBox_Enter(null, null);
        }

        private void pnlBgWhite_MouseUp(object sender, MouseEventArgs e)
        {
            CheckBoxBlue_Leave(null, null);
        }

        private void lblLegend_MouseDown(object sender, MouseEventArgs e)
        {
            chkBox_Enter(null, null);
        }

        private void lblLegend_MouseUp(object sender, MouseEventArgs e)
        {
            CheckBoxBlue_Leave(null, null);
        }
    }
}
