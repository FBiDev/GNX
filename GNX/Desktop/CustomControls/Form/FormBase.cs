using System;
using System.Drawing;
using System.Windows.Forms;

namespace GNX.Desktop
{
    public partial class FormBase : Form
    {
        protected bool _statusBar;

        public bool StatusBar
        {
            get { return _statusBar; }

            set
            {
                _statusBar = value;
                pnlFoot.Visible = value;
                pnlHead.Padding = new Padding
                {
                    All = pnlHead.Padding.Left,
                    Bottom = value == false ? pnlHead.Padding.Left : 32
                };
            }
        }

        public FormBase()
        {
            InitializeComponent();
            ResizeRedraw = true;
            StatusBar = true;

            DoubleBuffered = true;
        }

        public void Init(Form frm)
        {
            if (ico is Icon)
                Icon = ico;

            ThemeBase.CheckTheme(frm);
        }

        public static Icon ico { get; set; }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            AutoScaleDimensions = new SizeF(0F, 0F);
            AutoScaleMode = AutoScaleMode.None;
        }

        Point CenterOfMenuPanel<T>(T control, int height = 0) where T : Control
        {
            var center = new Point(
                (pnlBody.Size.Width / 2) - (control.Width / 2),
                height != 0 ? height : pnlBody.Size.Height / 2 - control.Height / 2);

            return center;
        }
    }
}