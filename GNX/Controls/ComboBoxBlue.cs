using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
//

namespace GNX
{
    public partial class ComboBoxBlue : UserControl
    {
        public ComboBoxNew ComboBox { get { return cboBlue; } }

        [Category("_Data")]
        public string _Legend { get { return lblLegend.Text; } set { lblLegend.Text = value; } }

        private BindingList<ListItem> lstItem = new BindingList<ListItem>();

        //[Category("_Data")]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        //public BindingList<ListItem> Items
        //{
        //    get { return lstItem; }
        //    set
        //    {
        //        lstItem.Clear();
        //        lstItem = (BindingList<ListItem>)value;
        //    }
        //}

        public ComboBoxBlue()
        {
            InitializeComponent();

            //ComboBox.DataSourceChanged += ComboBox_DataSourceChanged;

            //BindingSource bindingSource = new BindingSource();
            //bindingSource.DataSource = Items;

            //cboBlue.DataSource = bindingSource;
            //cboBlue.DisplayMember = "Text";
            //cboBlue.ValueMember = "ID";
        }

        //public void SetValueId(int Id)
        //{
        //    ComboBox.SelectedValue = Id;
        //    //if (Id > 0)
        //    //{
        //    //    ComboBox.SelectedValue = Id;
        //    //}
        //    //else if (ComboBox.Items.Count > 0)
        //    //{
        //    //    ComboBox.SelectedIndex = -1;
        //    //}
        //}

        //public void SetValueIdNull(int? Id)
        //{
        //    if (Id > 0)
        //    {
        //        ComboBox.SelectedValue = Id;

        //        if (ComboBox.SelectedValue == null && ComboBox.Items.Count > 0)
        //        {
        //            //ComboBox.SelectedIndex = 0;
        //        }
        //        else if (ComboBox.SelectedValue == null)
        //        {
        //            //ComboBox.SelectedIndex = -1;
        //        }
        //    }
        //}

        public void Add(string _key, string _value)
        {
            //Items.Add(new ListItem { ID = _key, Text = _value });
        }

        public void AddRange(List<ListItem> newList)
        {
            //Items.AddRange(newList);
        }

        private void cboBlue_Enter(object sender, EventArgs e)
        {
            pnlBg.BackColor = Color.FromArgb(108, 132, 199);
        }

        private void cboBlue_Leave(object sender, EventArgs e)
        {
            pnlBg.BackColor = Color.FromArgb(213, 223, 229);
        }

        private void pnlBgWhite_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void pnlBgWhite_Click(object sender, EventArgs e)
        {
            cboBlue.Focus();
            cboBlue.DroppedDown = true;
        }

        private void lblLegend_Click(object sender, EventArgs e)
        {
            pnlBgWhite_Click(null, null);
        }

        private void cboBlue_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index == -1)
            {
                return;
            }

            SolidBrush brushItem = new SolidBrush(Color.FromArgb(87, 87, 85));
            SolidBrush brushItemSelected = new SolidBrush(Color.White);

            SolidBrush brush = brushItem;

            if (cboBlue.DroppedDown)
            {
                e.DrawBackground();

                //user mouse is hovering over this drop-down item
                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                {
                    //ItemSelected
                    brush = brushItemSelected;
                }
                else
                {
                    //ItemNotSelected
                }
            }
            else
            {
                //DropDownClosed
            }

            // draw text strings
            e.Graphics.DrawString(
                ComboBox.GetItemText(ComboBox.Items[e.Index]),
                //((ListItem)cboBlue.Items[e.Index]).Text,
                e.Font, brush, new Point(e.Bounds.X, e.Bounds.Y));
        }

        private void cboBlue_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string a = "";
        }
    }
}
