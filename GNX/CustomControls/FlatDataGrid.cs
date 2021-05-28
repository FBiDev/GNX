using System;
using System.Drawing;
using System.ComponentModel;

namespace GNX
{
    public partial class FlatDataGrid : DataGridBase
    {
        #region Defaults
        [DefaultValue(typeof(Color), "White")]
        public new Color BackgroundColor { get { return base.BackgroundColor; } set { base.BackgroundColor = value; } }
        [DefaultValue(typeof(Color), "Silver")]
        public new Color GridColor { get { return base.GridColor; } set { base.GridColor = value; } }
        #endregion

        public FlatDataGrid()
        {
            InitializeComponent();
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            #region COLORS
            ColorBackground = Color.White;
            ColorGrid = Color.Silver;

            ColorRow = Color.White;
            ColorRowAlternate = Color.White;
            ColorRowSelection = Color.FromArgb(229, 226, 244);
            ColorRowMouseHover = Color.FromArgb(189, 237, 255);//189, 237, 255//163, 228, 196)

            ColorRowHeader = Color.White;
            ColorRowHeaderSelection = SystemColors.Highlight;

            ColorColumnHeader = Color.FromArgb(108, 132, 199);////109, 122, 224

            ColorColumnSelection = SystemColors.Highlight;

            ColorFontRowHeader = Color.White;
            ColorFontRowHeaderSelection = SystemColors.HighlightText;
            ColorFontRow = Color.FromArgb(64, 64, 64);
            ColorFontRowSelection = Color.FromArgb(64, 64, 64);
            ColorFontColumnHeader = Color.White;
            ColorFontColumnSelection = SystemColors.HighlightText;
            #endregion

            SetStyles();
        }
    }
}
