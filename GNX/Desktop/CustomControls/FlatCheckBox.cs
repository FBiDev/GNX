using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GNX.Desktop
{
    public partial class FlatCheckBox : UserControl
    {
        #region Properties
        protected Color _BorderColor = Color.FromArgb(213, 223, 229);
        [Category("_Colors"), DefaultValue(typeof(Color), "213, 223, 229")]
        public Color BorderColor { get { return _BorderColor; } set { _BorderColor = value; } }

        protected Color _BorderColorFocus = Color.FromArgb(108, 132, 199);
        [Category("_Colors"), DefaultValue(typeof(Color), "108, 132, 199")]
        public Color BorderColorFocus { get { return _BorderColorFocus; } set { _BorderColorFocus = value; } }

        [Category("_Colors"), DefaultValue(typeof(Color), "213, 223, 229")]
        Color BorderColorLeave { get; set; }

        [Category("_Colors"), DefaultValue(typeof(Color), "White")]
        public new Color BackColor
        {
            get { return pnlBgWhite.BackColor; }
            set { pnlBgWhite.BackColor = value; }
        }
        #endregion

        [Category("_Data"), DefaultValue("")]
        public string TextLegend
        {
            get { return lblLegend.Text; }
            set
            {
                lblLegend.Text = value;
                AlignControl();
            }
        }

        CheckBox CheckBox { get { return chkBox; } }

        [DefaultValue(false)]
        public bool Checked { get { return CheckBox.Checked; } set { CheckBox.Checked = value; } }
        public event EventHandler CheckedChanged;

        public FlatCheckBox()
        {
            InitializeComponent();

            CheckBox.CheckedChanged += chkBox_CheckedChanged;
            Click += (sender, e) => pnlBgWhite_Click(null, null);

            AlignControl();
        }

        public void ResetColors()
        {
            base.BackColor = BorderColor;
            BorderColorFocus = _BorderColorFocus;
            BorderColorLeave = BorderColor;
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            ResetColors();
        }

        void AlignControl()
        {
            var newLocation = new Point((pnlBgWhite.Width / 2) - (CheckBox.Width / 2), CheckBox.Location.Y);
            CheckBox.Location = newLocation;

            newLocation = new Point((pnlBgWhite.Width / 2) - (lblLegend.Width / 2), lblLegend.Location.Y);
            lblLegend.Location = newLocation;
        }

        void CheckBoxBlue_SizeChanged(object sender, EventArgs e)
        {
            AlignControl();
        }

        void pnlBgWhite_Click(object sender, EventArgs e)
        {
            CheckBox.Focus();
            Checked = !CheckBox.Checked;
        }

        void pnlBgWhite_DoubleClick(object sender, EventArgs e)
        {
            pnlBgWhite_Click(null, null);
        }

        void lblLegend_Click(object sender, EventArgs e)
        {
            pnlBgWhite_Click(null, null);
        }

        void lblLegend_DoubleClick(object sender, EventArgs e)
        {
            pnlBgWhite_Click(null, null);
        }

        void pnlBgWhite_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        void chkBox_CheckedChanged(object sender, EventArgs e)
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

        void chkBox_Enter(object sender, EventArgs e)
        {
            base.BackColor = BorderColorFocus;
        }

        void CheckBoxBlue_Leave(object sender, EventArgs e)
        {
            base.BackColor = BorderColorLeave;
        }

        void pnlBgWhite_MouseDown(object sender, MouseEventArgs e)
        {
            chkBox_Enter(null, null);
        }

        void pnlBgWhite_MouseUp(object sender, MouseEventArgs e)
        {
            CheckBoxBlue_Leave(null, null);
        }

        void lblLegend_MouseDown(object sender, MouseEventArgs e)
        {
            chkBox_Enter(null, null);
        }

        void lblLegend_MouseUp(object sender, MouseEventArgs e)
        {
            CheckBoxBlue_Leave(null, null);
        }
    }
}