using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GNX.Desktop
{
    public partial class ContentBaseForm : Form
    {
        [DefaultValue(typeof(AutoScaleMode), "None")]
        public new AutoScaleMode AutoScaleMode
        {
            get { return base.AutoScaleMode; }
            set { base.AutoScaleMode = value; }
        }

        public Size SizeOriginal;
        public bool isDesignMode = true;

        public ContentBaseForm()
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
                foreach (Control control in Controls)
                    control.Enter += Control_Enter;

                isDesignMode = DesignMode;
                if (isDesignMode) return;

                ThemeBase.CheckTheme(this);
            };

            TopLevel = false;
        }

        void Init()
        {
            SizeOriginal = Size;

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