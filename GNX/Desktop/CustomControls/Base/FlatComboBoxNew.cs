﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace GNX.Desktop
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
            FlatStyle = FlatStyle.Standard;
            DrawMode = DrawMode.OwnerDrawFixed;
        }

        protected override void OnResize(EventArgs e)
        {
            Region = new Region(new Rectangle(1, 1, Width - 2, Height - 2));
        }

        public void ResetIndex()
        {
            SelectedIndex = -1;
            SelectedIndex = -1;
        }

        void InitializeComponent()
        {
            SuspendLayout();
            ResumeLayout(false);
        }

        #region Border color when disabled
        const int WM_PAINT = 0xF;
        readonly int buttonWidth = SystemInformation.HorizontalScrollBarArrowWidth;
        //Color borderColor = Color.Blue;
        //public Color BorderColor
        //{
        //    get { return borderColor; }
        //    set { borderColor = value; Invalidate(); }
        //}
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_PAINT && DropDownStyle != ComboBoxStyle.Simple)
            {
                using (var g = Graphics.FromHwnd(Handle))
                {
                    var adjustMent = 0;
                    if (FlatStyle == FlatStyle.Popup ||
                       (FlatStyle == FlatStyle.Flat &&
                       DropDownStyle == ComboBoxStyle.DropDownList))
                        adjustMent = 1;
                    var innerBorderWisth = 3;
                    var innerBorderColor = BackColor;
                    //if (DropDownStyle == ComboBoxStyle.DropDownList &&
                    //    (FlatStyle == FlatStyle.System || FlatStyle == FlatStyle.Standard))
                    //    innerBorderColor = Color.FromArgb(0xCCCCCC);
                    //if (DropDownStyle == ComboBoxStyle.DropDown && !Enabled)
                    //    innerBorderColor = SystemColors.Control;

                    if (DropDownStyle == ComboBoxStyle.DropDown || Enabled == false)
                    {
                        using (var p = new Pen(innerBorderColor, innerBorderWisth))
                        {
                            p.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                            g.DrawRectangle(p, 1, 1,
                                Width - buttonWidth - adjustMent - 1, Height - 1);
                        }
                    }
                    //using (var p = new Pen(BorderColor))
                    //{
                    //    g.DrawRectangle(p, 0, 0, Width - 1, Height - 1);
                    //    g.DrawLine(p, Width - buttonWidth - adjustMent,
                    //        0, Width - buttonWidth - adjustMent, Height);
                    //}
                }
            }
        }
        #endregion
    }
}