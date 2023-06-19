using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;

namespace GNX
{
    public partial class FlatPanel : Panel
    {
        [DefaultValue(false)]
        public bool NoScrollOnFocus { get; set; }

        [Browsable(true)]
        [DefaultValue(typeof(Color), "0xA0A0A0")]
        public Color BorderColor { get; set; }

        [DefaultValue(1)]
        public int BorderSize { get; set; }

        [DefaultValue(true)]
        public bool BorderRound { get; set; }

        [DefaultValue(typeof(Padding), "0, 0, 0, 0")]
        public new Padding Padding
        {
            get { return base.Padding; }
            set { base.Padding = value; }
        }

        public FlatPanel()
        {
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            DoubleBuffered = true;

            BorderSize = 1;
            BorderColor = ColorTranslator.FromHtml("#A0A0A0");
            BorderRound = true;
        }

        protected override void OnControlAdded(ControlEventArgs e) { }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawRoundBorder(this, BorderColor, BorderSize, BorderRound);
        }

        protected override Point ScrollToControl(Control activeControl)
        {
            if (NoScrollOnFocus)
                return DisplayRectangle.Location;
            return base.ScrollToControl(activeControl);
        }
    }
}