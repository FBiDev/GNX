using System.ComponentModel;
using System.Drawing;
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

        public Size OriginalSize { get; set; }

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
            };

            TopLevel = false;
        }

        void Init()
        {
            OriginalSize = Size;

            this.GetControls<FlatLabel>().ForEach(x => x.OriginalForeColor = x.ForeColor);
            this.GetControls<FlatPanel>().ForEach(x => x.OriginalBackColor = x.BackColor);
        }
    }
}