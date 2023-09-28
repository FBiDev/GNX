using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GNX.Desktop
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
        public bool isDesignMode = true;

        public MainBaseForm()
        {
            InitializeComponent();
            HandleCreated += (sender, e) =>
            {
                Init();
                if (isDesignMode) return;

                ThemeBase.CheckTheme(this);
            };

            Shown += (sender, e) =>
            {
                isDesignMode = DesignMode;
                if (isDesignMode) return;

                //ThemeBase.CheckTheme(this);
            };

            ResizeRedraw = true;
            StatusBar = true;
            DoubleBuffered = true;
        }

        void Init()
        {
            if (ico is Icon)
                Icon = ico;
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

        public void CenterWindow()
        {
            CenterToScreen();
        }

        public async Task ShowLayout()
        {
            await Task.Delay(50);
            Opacity = 1;
        }

        public void HideLayout()
        {
            Opacity = 0;
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