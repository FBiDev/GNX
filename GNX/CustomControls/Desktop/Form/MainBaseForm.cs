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
                    Bottom = value == false ? pnlHead.Padding.Left : 32
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
        }

        public void Init(Form frm)
        {
            if (ico is Icon)
                Icon = ico;

            Theme.CheckTheme(frm);
        }

        public virtual void DarkTheme()
        {
            BackColor = ColorTranslator.FromHtml("#242424");
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