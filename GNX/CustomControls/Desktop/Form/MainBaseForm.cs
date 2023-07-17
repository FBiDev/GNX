using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GNX
{
    public partial class MainBaseForm : Form
    {
        [DefaultValue(typeof(AutoScaleMode), "None")]
        public new AutoScaleMode AutoScaleMode
        {
            get { return base.AutoScaleMode; }
            set { base.AutoScaleMode = value; }
        }

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
                    Bottom = value == false ? pnlHead.Padding.Left : 8
                };
            }
        }

        public static Icon ico { get; set; }

        public MainBaseForm()
        {
            InitializeComponent();
            HandleCreated += (sender, e) =>
            {
                Init();
                Theme.CheckTheme(this);
            };

            Shown += (sender, e) =>
            {
                Theme.CheckTheme(this);
            };

            ResizeRedraw = true;
            StatusBar = true;
            DoubleBuffered = true;
        }

        void Init()
        {
            if (ico is Icon)
                Icon = ico;

            this.GetControls<FlatPanel>().ForEach(x => x.OriginalBackColor = x.BackColor);
        }

        public void SetMainFormContent(Form frm)
        {
            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(frm);

            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

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