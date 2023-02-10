using System;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;

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

        public StatusStrip _Statusbar = new StatusStrip();
        public StatusStrip Statusbar { get { return _Statusbar; } set { _Statusbar = value; } }

        protected override bool ShowFocusCues
        {
            get { return false; }
        }

        public FlatDataGrid()
        {
            InitializeComponent();

            DataSourceChanged += Dg_DataSourceChanged;
        }

        protected new void Dg_DataSourceChanged(object sender, EventArgs e)
        {
            base.Dg_DataSourceChanged(null, null);
            RefreshRows();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            //e.Handled = (e.KeyData == Keys.Tab);
            base.OnKeyDown(e);
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

            ColorColumnSelection = ColorColumnHeader;

            ColorFontRowHeader = Color.White;
            ColorFontRowHeaderSelection = SystemColors.HighlightText;
            ColorFontRow = Color.FromArgb(64, 64, 64);
            ColorFontRowSelection = Color.FromArgb(64, 64, 64);
            ColorFontColumnHeader = Color.White;
            ColorFontColumnSelection = SystemColors.HighlightText;
            #endregion

            SetStyles();
        }

        public new void RefreshRows()
        {
            base.RefreshRows();
            RefreshStatusBar();
        }

        public void RefreshStatusBar()
        {
            if (Statusbar.Items.Count > 0)
            {
                Statusbar.Items[0].Text = (Rows.Count + " Registro(s)");
            }
        }

        bool HandleRightClick(MouseEventArgs e)
        {
            int clickedRowIndex = HitTest(e.X, e.Y).RowIndex;

            if (clickedRowIndex != -1 && e.Button == MouseButtons.Right)
            {
                ClearSelection();
                CurrentCell = Rows[clickedRowIndex].Cells[0];
                return true;
            }
            return false;
        }

        public void ShowContextMenu(MouseEventArgs e, ContextMenuStrip menu)
        {
            if (HandleRightClick(e))
                menu.Show(Cursor.Position);
        }
    }
}
