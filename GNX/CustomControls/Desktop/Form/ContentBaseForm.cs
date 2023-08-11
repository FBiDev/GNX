using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GNX
{
    public partial class ContentBaseForm : Form
    {
        [DefaultValue(typeof(AutoScaleMode), "None")]
        public new AutoScaleMode AutoScaleMode
        {
            get { return base.AutoScaleMode; }
            set { base.AutoScaleMode = value; }
        }

        public Size OriginalSize;

        public ContentBaseForm()
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

                foreach (Control control in Controls)
                    control.Enter += Control_Enter;
            };

            TopLevel = false;
        }

        void Init()
        {
            OriginalSize = Size;

            this.GetControls<FlatLabel>().ForEach(x => x.OriginalForeColor = x.ForeColor);
            this.GetControls<FlatPanel>().ForEach(x => x.OriginalBackColor = x.BackColor);

            var panels = Controls.OfType<FlatPanel>();

            int tabIndex = 0;

            panels = panels.Reverse();
            panels.ForEach(x =>
            {
                x.TabIndex = tabIndex;
                tabIndex++;
            });
        }

        void Control_Enter(object sender, EventArgs e)
        {
            ScrollControlIntoView((Control)sender);
        }
    }
}