using System;
//
using System.Drawing;

namespace GNX
{
    public partial class DataGridViewPink : DataGridViewBase
    {
        public DataGridViewPink()
        {
            InitializeComponent();

            #region COLORS
            ColorBackground = Color.White;
            ColorGrid = Color.Silver;

            ColorRow = Color.White;
            ColorRowAlternate = Color.White;
            ColorRowSelection = Color.FromArgb(229, 226, 244);
            ColorRowMouseHover = Color.FromArgb(189, 237, 255);//189, 237, 255//163, 228, 196)

            ColorRowHeader = Color.White;
            ColorRowHeaderSelection = SystemColors.Highlight;

            ColorColumnHeader = Color.FromArgb(109, 122, 224);
            ColorColumnSelection = SystemColors.Highlight;

            ColorFontRowHeader = Color.White;
            ColorFontRowHeaderSelection = SystemColors.HighlightText;
            ColorFontRow = Color.FromArgb(64, 64, 64);
            ColorFontRowSelection = Color.FromArgb(64, 64, 64);
            ColorFontColumnHeader = Color.White;
            ColorFontColumnSelection = SystemColors.HighlightText;
            #endregion

            EnableHeadersVisualStyles = false;
            SetStyles();
        }
    }
}
