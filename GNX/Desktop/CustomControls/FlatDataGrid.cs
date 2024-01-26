﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GNX.Desktop
{
    public partial class FlatDataGrid : DataGridBase
    {
        #region Defaults
        [DefaultValue(typeof(Color), "White")]
        public new Color BackgroundColor { get { return base.BackgroundColor; } set { base.BackgroundColor = value; } }
        [DefaultValue(typeof(Color), "Silver")]
        public new Color GridColor { get { return base.GridColor; } set { base.GridColor = value; } }
        #endregion

        public new object DataSource
        {
            get
            {
                return base.DataSource;
            }
            set
            {
                DisposeCells();
                base.DataSource = value;
            }
        }

        FlatStatusBar _Statusbar = new FlatStatusBar();
        public FlatStatusBar Statusbar { get { return _Statusbar; } set { _Statusbar = value; } }

        protected override bool ShowFocusCues
        {
            get { return false; }
        }

        public FlatDataGrid()
        {
            InitializeComponent();

            DataSourceChanged += Dg_DataSourceChanged;
        }

        public override string ToString()
        {
            return Name;
        }

        protected new void Dg_DataSourceChanged(object sender, EventArgs e)
        {
            base.Dg_DataSourceChanged(null, null);
            RefreshRows();

            if (AutoGenerateColumns)
            {
                //Visible = false;
                
                var type = ListBindingHelper.GetListItemType(DataSource);
                var properties = TypeDescriptor.GetProperties(type);

                foreach (DataGridViewColumn column in Columns)
                {
                    var p = properties[column.DataPropertyName];
                    if (p != null)
                    {
                        //DisplayStyle
                        var style = (StyleAttribute)p.Attributes[typeof(StyleAttribute)];
                        column.Width = style != null && style.Width >= 0 ? style.Width : column.Width;
                        column.MinimumWidth = 32;

                        column.AutoSizeMode = style != null ? (DataGridViewAutoSizeColumnMode)style.AutoSizeMode : column.AutoSizeMode;

                        if (style != null && style.Format != ColumnFormat.NotSet)
                            Columns.Format(style.Format, column.Index);

                        column.DefaultCellStyle.Alignment = style != null && style.Align != ColumnAlign.NotSet ? (DataGridViewContentAlignment)style.Align : column.DefaultCellStyle.Alignment;

                        //Display
                        column.ToolTipText = p.Description;

                        var display = (DisplayAttribute)p.Attributes[typeof(DisplayAttribute)];
                        column.HeaderText = display != null && display.Name != null ? display.Name : column.HeaderText;
                        column.ToolTipText = display != null && display.Description != null ? display.Description : column.ToolTipText;

                        column.Visible = display == null || display.AutoGenerateField;

                        if (display != null && display.Order > Columns.Count - 1) display.Order = Columns.Count - 1;
                        column.DisplayIndex = display != null && display.Order >= 0 ? display.Order : column.Index;

                        column.DefaultCellStyle.Format = display != null && display.Format != null ? display.Format : null;
                    }
                }
                
                //Visible = true;
            }
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

        public void DisposeCells()
        {
            foreach (DataGridViewColumn col in Columns)
                col.Dispose();

            foreach (DataGridViewRow row in Rows)
                foreach (DataGridViewCell cell in row.Cells)
                    cell.Dispose();
        }

        public new void RefreshRows()
        {
            base.RefreshRows();
            RefreshStatusBar();
        }

        public void RefreshStatusBar()
        {
            Statusbar.Registros = Rows.Count;
        }

        public void Clear()
        {
            if (DataSource == null) return;

            var gridType = DataSource.GetType();
            var bindlist = Activator.CreateInstance(gridType);
            DataSource = bindlist;
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

        public T GetCurrentRowObject<T>() where T : class
        {
            var dgv = this as DataGridView;
            if (dgv.CurrentRow.NotNull() && dgv.CurrentRow.Index != -1)
                return dgv.CurrentRow.DataBoundItem as T;
            return null;
        }

        public string GetCurrentRowValue(bool includeColumnName = false)
        {
            var dgv = this as DataGridView;

            if (dgv.CurrentRow.IsNull() || dgv.CurrentRow.Index == -1)
                return string.Empty;

            var rowValue = string.Empty;

            if (includeColumnName)
            {
                foreach (DataGridViewColumn column in dgv.Columns)
                {
                    if (column.Visible)
                        rowValue += column.HeaderText;
                    if (column.Index < dgv.ColumnCount - 1)
                        rowValue += "\t";
                    else
                        rowValue += Environment.NewLine;
                }
            }

            foreach (DataGridViewCell cell in dgv.CurrentRow.Cells)
            {
                if (dgv.Columns[cell.ColumnIndex].Visible)
                    rowValue += cell.Value;
                if (cell.ColumnIndex < dgv.CurrentRow.Cells.Count - 1)
                    rowValue += "\t";
                else
                    rowValue += Environment.NewLine;
            }
            return rowValue;
        }
    }
}