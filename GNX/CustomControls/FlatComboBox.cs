using System;
using System.Windows.Forms;
//
using System.Drawing;
using System.ComponentModel;
using GNX.Properties;

namespace GNX
{
    public partial class FlatComboBox : UserControl
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

        [DefaultValue(typeof(Cursor), "Hand")]
        public new Cursor Cursor
        {
            get { return base.Cursor; }
            set { base.Cursor = value; }
        }
        #endregion

        #region Properties
        [Category("_Properties")]
        public Color _BorderColor { get { return BorderColor; } }
        public Color BorderColor = Color.FromArgb(213, 223, 229);

        [Category("_Properties")]
        public Color _BorderColorFocus { get { return BorderColorFocus; } }
        protected Color BorderColorFocus = Color.FromArgb(108, 132, 199);

        [Category("_Properties")]
        public Color _BackgroundColor { get { return BackgroundColor; } }
        protected Color BackgroundColor = Color.White;

        [Category("_Properties")]
        public Color _ItemBackColorFocus { get { return ItemBackColorFocus; } }
        protected Color ItemBackColorFocus = Color.FromArgb(108, 132, 199);

        [Category("_Properties")]
        public Color _ItemTextColor { get { return ItemTextColor; } }
        protected Color ItemTextColor = Color.FromArgb(47, 47, 47);

        [Category("_Properties")]
        public Color _ItemTextColorFocus { get { return ItemTextColorFocus; } }
        protected Color ItemTextColorFocus = Color.White;

        [Category("_Properties")]
        public Color _LabelTextColor { get { return LabelTextColor; } }
        protected Color LabelTextColor = Color.FromArgb(108, 132, 199);

        [Category("_Properties")]
        public string LabelText { get { return lblSubtitle.Text; } set { lblSubtitle.Text = value; } }
        #endregion

        #region ComboBox
        public FlatComboBoxNew Combo { get { return cboFlat; } }
        public new string Text { get { return cboFlat.Text; } set { cboFlat.Text = value; } }

        private string _DisplayMember;
        [DefaultValue("")]
        public string DisplayMember
        {
            get { return cboFlat.DisplayMember; }
            set
            {
                cboFlat.DisplayMember = value;
                _DisplayMember = value;
            }
        }

        [DefaultValue("")]
        public string ValueMember
        {
            get { return cboFlat.ValueMember; }
            set { cboFlat.ValueMember = value; }
        }

        [DefaultValue(null)]
        public object DataSource
        {
            get { return cboFlat.DataSource; }
            set
            {
                cboFlat.DataSource = value;
                cboFlat.DisplayMember = _DisplayMember;
                SelectedIndexReset();
            }
        }

        public event System.EventHandler SelectedIndexChanged;
        private delegate void EventHandler(object sender, EventArgs e);

        [DefaultValue(-1)]
        public int SelectedIndex { get { return cboFlat.SelectedIndex; } set { cboFlat.SelectedIndex = value; } }

        [DefaultValue("")]
        public string SelectedValue { get { if (cboFlat.SelectedValue != null) { return cboFlat.SelectedValue.ToString(); } return string.Empty; } set { cboFlat.SelectedValue = value; } }

        [DefaultValue(null)]
        public object SelectedItem { get { return cboFlat.SelectedItem; } set { cboFlat.SelectedItem = value; } }
        #endregion

        public FlatComboBox()
        {
            InitializeComponent();

            pnlBg.Click += pnlBg_Click;
            lblSubtitle.Click += pnlBg_Click;
            picDrop.Click += pnlBg_Click;

            Combo.GotFocus += Combo_GotFocus;
            Combo.LostFocus += Combo_LostFocus;
            Combo.DrawItem += Combo_DrawItem;
            Combo.DropDown += Combo_DropDown;
            Combo.DropDownClosed += Combo_DropDownClosed;
            Combo.MouseWheel += new MouseEventHandler(Combo_MouseWheel);
            Combo.SelectedIndexChanged += Combo_SelectedIndexChanged;

            Cursor = Cursors.Hand;
            Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
            Size = new Size(206, 34);
            MaximumSize = new Size(800, 34);
            MinimumSize = new Size(100, 34);
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            pnlBorder.BackColor = BorderColor;

            pnlBg.BackColor = BackgroundColor;
            lblSubtitle.BackColor = BackgroundColor;
            lblSubtitle.ForeColor = LabelTextColor;
            Combo.BackColor = BackgroundColor;

            Combo.ForeColor = ItemTextColor;
        }

        private void pnlBg_Click(object sender, EventArgs e)
        {
            Combo.Focus();
            Combo.DroppedDown = true;
        }

        public void SelectedIndexReset()
        {
            Combo.SelectedIndexReset();
        }

        private void Combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedIndexChanged(sender, e);
        }

        private void Combo_GotFocus(object sender, EventArgs e)
        {
            pnlBorder.BackColor = BorderColorFocus;
            picDrop.BackgroundImage = Resources.img_drop_arrow_focus;
        }

        private void Combo_LostFocus(object sender, EventArgs e)
        {
            pnlBorder.BackColor = BorderColor;
            picDrop.BackgroundImage = Resources.img_drop_arrow;
        }

        private void Combo_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = false;
        }

        private void Combo_DropDown(object sender, EventArgs e) { }

        private void Combo_DropDownClosed(object sender, EventArgs e) { }

        private void Combo_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index == -1) { return; }

            //BackgroundColor
            //var combo = sender as ComboBox;
            //combo.BackColor = Color.BlanchedAlmond;

            SolidBrush textColorNormal = new SolidBrush(ItemTextColor);
            SolidBrush textColorFocus = new SolidBrush(ItemTextColorFocus);

            SolidBrush fontColor = textColorNormal;

            SolidBrush backColorNormal = new SolidBrush(BackgroundColor);
            SolidBrush backColorFocus = new SolidBrush(ItemBackColorFocus);
            //Color.BlueViolet

            //int DrawYCenter = (int)Math.Floor((double)((((Combo.ItemHeight - 1) - (int)Combo.Font.Size) / 2) - 3));
            //int DrawY = DrawYCenter;

            e.Graphics.FillRectangle(backColorFocus, e.Bounds);

            if (Combo.DroppedDown)
            {
                //e.DrawBackground();

                //user mouse is hovering over this drop-down item
                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                {
                    //ItemSelected
                    fontColor = textColorFocus;
                    //BackColorSelected
                    e.Graphics.FillRectangle(backColorFocus, e.Bounds);
                }
                else
                {
                    //ItemNotSelected
                    //BackgroundColor
                    e.Graphics.FillRectangle(backColorNormal, e.Bounds);
                }
            }
            else
            {
                //DropDownClosed
                e.Graphics.FillRectangle(backColorNormal, e.Bounds);
            }

            // draw text strings
            e.Graphics.DrawString(
                Combo.GetItemText(Combo.Items[e.Index]),
                e.Font, fontColor, new Point(e.Bounds.X, e.Bounds.Y));
        }
    }
}