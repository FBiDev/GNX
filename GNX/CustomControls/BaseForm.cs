﻿using System;
using System.Drawing;
using System.Windows.Forms;
using GNX.Properties;

namespace GNX
{
    public partial class BaseForm : Form
    {
        public BaseForm()
        {
            InitializeComponent();
            ResizeRedraw = true;
            lblCenter.Enabled = false;

            //Icon = GNX.cConvert.ToIco(Resources.img_form, new System.Drawing.Size(16,16));
            //Icon = Resources.ico_app;

            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;

            Load += FormBase_Load;
            Resize += FormBase_Resize;
            lblStatus2.TextChanged += lblStatus2_TextChanged;
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            ResizeMargins();
        }

        private void FormBase_Load(object sender, EventArgs e)
        {
            lblStatus2_TextChanged(null, null);
        }

        private void FormBase_Resize(object sender, EventArgs e)
        {
            ResizeMargins();
        }

        private void lblStatus2_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblStatus2.Text.Trim()))
            {
                pnlStatus2.Visible = false;
                return;
            }
            pnlStatus2.Visible = true;
        }

        public void ResizeMargins()
        {
            pnlBorder1.Location = new Point(1, 1);
            pnlBorder1.Size = new Size(
                this.ClientSize.Width - (pnlBorder1.Location.X * 2),
                (this.ClientSize.Height) - (pnlBorder1.Location.Y * 2));

            pnlBorder2.Location = new Point(1, 1);
            pnlBorder2.Size = new Size(
                pnlBorder1.Width - (pnlBorder2.Location.X * 2),
                pnlBorder1.Height - (pnlBorder2.Location.Y * 2));

            pnlContent.Location = new Point(0, 0);
            pnlContent.Size = new Size(
                pnlBorder2.Width - (pnlContent.Location.X * 2),
                pnlBorder2.Height - (pnlContent.Location.Y * 2) - pnlStatus.Height - 1);

            pnlMargin.Location = new Point(11, 11);
            pnlMargin.Size = new Size(
                pnlContent.Width - (pnlMargin.Location.X * 2),
                pnlContent.Height - (pnlMargin.Location.Y * 2));

            lblCenter.Location = new Point(11, 0);
            lblCenter.Size = new Size(pnlContent.Width / 2 - 11, 11);

            pnlStatus.Location = new Point(0, pnlContent.Height + 1);
            pnlStatus.Size = new Size(
                pnlBorder2.Width - (pnlStatus.Location.X * 2),
                22);
        }

        //#region ResizeGrip
        //private FormWindowState _WindowState = FormWindowState.Normal;
        //protected bool _resizable = true;
        //private const int grab = 16;
        //private Rectangle sizeGripRectangle;

        //protected override void OnPaint(PaintEventArgs e)
        //{
        //    base.OnPaint(e);
        //    if (_WindowState == FormWindowState.Normal && _resizable)
        //    {
        //        var rc = new Rectangle(this.ClientSize.Width - grab - 2, this.ClientSize.Height - grab - 1, grab, grab);
        //        var rcPaintBack = new Rectangle(this.ClientSize.Width - grab - 1, this.ClientSize.Height - grab - 1, grab, grab);
        //        var rcPaint = new Rectangle(this.ClientSize.Width - grab - 2, this.ClientSize.Height - grab - 2, grab, grab);
        //        e.Graphics.FillRectangle(new SolidBrush(pnlBorder1.BackColor), rcPaintBack);
        //        e.Graphics.FillRectangle(new SolidBrush(pnlStatus.BackColor), rcPaint);
        //        ControlPaint.DrawSizeGrip(e.Graphics, Color.Transparent, rc);
        //    }
        //}

        //protected override void WndProc(ref Message m)
        //{
        //    base.WndProc(ref m);
        //    if (WindowState == FormWindowState.Normal && _resizable)
        //    {
        //        if (m.Msg == 0x84)
        //        {  // Trap WM_NCHITTEST
        //            var pos = this.PointToClient(new Point(m.LParam.ToInt32()));
        //            if (pos.X >= this.ClientSize.Width - grab && pos.Y >= this.ClientSize.Height - grab)
        //                m.Result = new IntPtr(17);  // HT_BOTTOMRIGHT
        //        }
        //    }
        //}

        //protected override void OnSizeChanged(EventArgs e)
        //{
        //    base.OnSizeChanged(e);
        //    var region = new Region(new Rectangle(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height));
        //    sizeGripRectangle = new Rectangle(this.ClientRectangle.Width - grab, this.ClientRectangle.Height - grab, grab, grab);
        //    region.Exclude(sizeGripRectangle);
        //    this.pnlBorder1.Region = region;
        //    this.Invalidate();
        //}
        //#endregion

        ////Fix Flickering in Controls
        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams cp = base.CreateParams;
        //        cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
        //        return cp;
        //    }
        //}
    }
}
