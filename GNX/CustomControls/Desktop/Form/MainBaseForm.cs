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
            ResizeRedraw = true;
            StatusBar = true;

            DoubleBuffered = true;

            Shown += Form_Shown;
        }

        private bool firstInit = true;
        public void Init()
        {
            if (firstInit)
            {
                foreach (var control in this.GetControls<FlatPanel>())
                {
                    control.OriginalBackColor = control.BackColor;
                }
            }

            firstInit = false;

            if (ico is Icon)
                Icon = ico;

            Theme.CheckTheme(this);
        }

        void Form_Shown(object sender, System.EventArgs e)
        {
            Init();
        }

        public void SetContentForm(Form frm)
        {
            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(frm);
            frm.Show();
            frm.Dock = DockStyle.Fill;
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