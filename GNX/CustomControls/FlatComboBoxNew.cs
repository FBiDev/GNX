using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace GNX
{
    public class FlatComboBoxNew : ComboBox
    {
        public int previousIndex = -1;
        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            if (SelectedIndex != previousIndex)
            {
                base.OnSelectedIndexChanged(e);
                previousIndex = SelectedIndex;
            }
        }

        public FlatComboBoxNew()
        {
            Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom);
            AutoCompleteSource = AutoCompleteSource.ListItems;
            IntegralHeight = false;
            MaxDropDownItems = 10;
            ItemHeight = 18;

            Font = new Font("Segoe UI", 9);
            ForeColor = Color.FromArgb(47, 47, 47);
            BackColor = Color.White;

            DropDownStyle = ComboBoxStyle.DropDownList;
            FlatStyle = FlatStyle.Flat;
            DrawMode = DrawMode.OwnerDrawFixed;
        }

        protected override void OnResize(EventArgs e)
        {
            Region = new Region(new Rectangle(1, 1, Width - 2, Height - 2));
        }

        public void SelectedIndexReset()
        {
            SelectedIndex = -1;
            SelectedIndex = -1;
        }
    }
}
