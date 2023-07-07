using System.ComponentModel;
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

        bool firstInit = true;

        public ContentBaseForm()
        {
            InitializeComponent();
            HandleCreated += (sender, e) => Init();
            Shown += (sender, e) => Init();

            TopLevel = false;
        }

        public void Init()
        {
            if (firstInit)
            {
                foreach (var control in this.GetControls<FlatLabel>())
                {
                    control.OriginalForeColor = control.ForeColor;
                }

                foreach (var control in this.GetControls<FlatPanel>())
                {
                    control.OriginalBackColor = control.BackColor;
                }
            }

            firstInit = false;
            Theme.CheckTheme(this);
        }
    }
}