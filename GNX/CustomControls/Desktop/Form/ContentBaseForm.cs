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

        public ContentBaseForm()
        {
            InitializeComponent();
            TopLevel = false;
        }

        public void Init(Form frm)
        {
            Theme.CheckTheme(frm);
        }
    }
}