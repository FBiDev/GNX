﻿using System;
using System.Windows.Forms;
//
using System.ComponentModel;
using System.Collections.Generic;
using System.Drawing;

namespace GNX
{
    public partial class DataGridBase : DataGridView
    {
        #region Defaults
        [DefaultValue(false)]
        public new bool AllowUserToAddRows { get { return base.AllowUserToAddRows; } set { base.AllowUserToAddRows = value; } }
        [DefaultValue(false)]
        public new bool AllowUserToDeleteRows { get { return base.AllowUserToDeleteRows; } set { base.AllowUserToDeleteRows = value; } }
        [DefaultValue(typeof(AnchorStyles), "Top, Bottom, Left, Right")]
        public new AnchorStyles Anchor { get { return base.Anchor; } set { base.Anchor = value; } }
        [DefaultValue(false)]
        public new bool CausesValidation { get { return base.CausesValidation; } set { base.CausesValidation = value; } }
        [DefaultValue(typeof(BorderStyle), "None")]
        public new BorderStyle BorderStyle { get { return base.BorderStyle; } set { base.BorderStyle = value; } }
        [DefaultValue(typeof(DataGridViewCellBorderStyle), "SingleHorizontal")]
        public new DataGridViewCellBorderStyle CellBorderStyle { get { return base.CellBorderStyle; } set { base.CellBorderStyle = value; } }
        [DefaultValue(typeof(DataGridViewHeaderBorderStyle), "Single")]
        public new DataGridViewHeaderBorderStyle ColumnHeadersBorderStyle { get { return base.ColumnHeadersBorderStyle; } set { base.ColumnHeadersBorderStyle = value; } }
        [DefaultValue(30)]
        public new int ColumnHeadersHeight { get { return base.ColumnHeadersHeight; } set { base.ColumnHeadersHeight = value; } }
        [DefaultValue(typeof(DataGridViewColumnHeadersHeightSizeMode), "DisableResizing")]
        public new DataGridViewColumnHeadersHeightSizeMode ColumnHeadersHeightSizeMode { get { return base.ColumnHeadersHeightSizeMode; } set { base.ColumnHeadersHeightSizeMode = value; } }
        [DefaultValue(false)]
        public new bool EnableHeadersVisualStyles { get { return base.EnableHeadersVisualStyles; } set { base.EnableHeadersVisualStyles = value; } }
        [DefaultValue(false)]
        public new bool MultiSelect { get { return base.MultiSelect; } set { base.MultiSelect = value; } }
        [DefaultValue(true)]
        public new bool ReadOnly { get { return base.ReadOnly; } set { base.ReadOnly = value; } }
        [DefaultValue(typeof(DataGridViewHeaderBorderStyle), "Single")]
        public new DataGridViewHeaderBorderStyle RowHeadersBorderStyle { get { return base.RowHeadersBorderStyle; } set { base.RowHeadersBorderStyle = value; } }
        [DefaultValue(false)]
        public new bool RowHeadersVisible { get { return base.RowHeadersVisible; } set { base.RowHeadersVisible = value; } }
        [DefaultValue(typeof(DataGridViewRowHeadersWidthSizeMode), "DisableResizing")]
        public new DataGridViewRowHeadersWidthSizeMode RowHeadersWidthSizeMode { get { return base.RowHeadersWidthSizeMode; } set { base.RowHeadersWidthSizeMode = value; } }
        [DefaultValue(typeof(DataGridViewSelectionMode), "FullRowSelect")]
        public new DataGridViewSelectionMode SelectionMode { get { return base.SelectionMode; } set { base.SelectionMode = value; } }
        [DefaultValue(false)]
        public new bool TabStop { get { return base.TabStop; } set { base.TabStop = value; } }
        #endregion

        private string DefaultColumn = string.Empty;
        private ListSortDirection DefaultColumnDirection;
        private List<string> ColumnsBooleanNames = new List<string>();

        private string LastSortedColumn;
        private ListSortDirection LastSortedColumnDirection;

        protected Color ColorBackground { get { return BackgroundColor; } set { BackgroundColor = value; } }
        protected Color ColorGrid { get { return GridColor; } set { GridColor = value; } }
        protected Color ColorRow { get { return DefaultCellStyle.BackColor; } set { DefaultCellStyle.BackColor = value; } }
        protected Color ColorRowSelection { get { return DefaultCellStyle.SelectionBackColor; } set { DefaultCellStyle.SelectionBackColor = value; } }
        protected Color ColorRowAlternate { get { return AlternatingRowsDefaultCellStyle.BackColor; } set { AlternatingRowsDefaultCellStyle.BackColor = value; } }
        protected Color ColorRowMouseHover { get; set; }
        protected Color ColorRowHeader { get { return RowHeadersDefaultCellStyle.BackColor; } set { RowHeadersDefaultCellStyle.BackColor = value; } }
        protected Color ColorRowHeaderSelection { get { return RowHeadersDefaultCellStyle.SelectionBackColor; } set { RowHeadersDefaultCellStyle.SelectionBackColor = value; } }
        protected Color ColorColumnHeader { get { return ColumnHeadersDefaultCellStyle.BackColor; } set { ColumnHeadersDefaultCellStyle.BackColor = value; } }
        protected Color ColorColumnSelection { get { return ColumnHeadersDefaultCellStyle.SelectionBackColor; } set { ColumnHeadersDefaultCellStyle.SelectionBackColor = value; } }

        protected Color ColorFontRowHeader { get { return RowHeadersDefaultCellStyle.ForeColor; } set { RowHeadersDefaultCellStyle.ForeColor = value; } }
        protected Color ColorFontRowHeaderSelection { get { return RowHeadersDefaultCellStyle.SelectionForeColor; } set { RowHeadersDefaultCellStyle.SelectionForeColor = value; } }
        protected Color ColorFontRow { get { return DefaultCellStyle.ForeColor; } set { DefaultCellStyle.ForeColor = value; } }
        protected Color ColorFontRowSelection { get { return DefaultCellStyle.SelectionForeColor; } set { DefaultCellStyle.SelectionForeColor = value; } }
        protected Color ColorFontColumnHeader { get { return ColumnHeadersDefaultCellStyle.ForeColor; } set { ColumnHeadersDefaultCellStyle.ForeColor = value; } }
        protected Color ColorFontColumnSelection { get { return ColumnHeadersDefaultCellStyle.SelectionForeColor; } set { ColumnHeadersDefaultCellStyle.SelectionForeColor = value; } }

        public DataGridBase()
        {
            InitializeComponent();

            SetStyles();

            ColumnHeaderMouseClick += Dg_ColumnHeaderMouseClick;
            ColumnHeadersHeightSizeModeChanged += Dg_ColumnHeadersHeightSizeModeChanged;
            Sorted += Dg_OnSorted;
            DataSourceChanged += Dg_DataSourceChanged;

            DoubleBuffered = true;
        }

        protected void SetStyles()
        {
            //MAIN
            Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));

            CausesValidation = false;

            AllowUserToAddRows = false;
            AllowUserToDeleteRows = false;

            BackgroundColor = ColorBackground;
            BorderStyle = System.Windows.Forms.BorderStyle.None;
            GridColor = ColorGrid;
            //Margin = new System.Windows.Forms.Padding(0);
            MultiSelect = false;
            SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ReadOnly = true;
            TabStop = false;
            EnableHeadersVisualStyles = false;

            //ROWS
            RowTemplate.Height = 30;
            RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;

            //Alternate Rows
            System.Windows.Forms.DataGridViewCellStyle AlternatingRowsStyle = new System.Windows.Forms.DataGridViewCellStyle()
            {
                BackColor = ColorRowAlternate,
            };
            AlternatingRowsDefaultCellStyle = AlternatingRowsStyle;

            //ROWS_HEADERS
            System.Windows.Forms.DataGridViewCellStyle RowHeadersStyle = new System.Windows.Forms.DataGridViewCellStyle()
            {
                Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft,
                BackColor = ColorRowHeader,
                Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                ForeColor = ColorFontRowHeader,
                SelectionBackColor = ColorRowHeaderSelection,
                SelectionForeColor = ColorFontRowHeaderSelection,
                WrapMode = System.Windows.Forms.DataGridViewTriState.True,
            };
            RowHeadersDefaultCellStyle = RowHeadersStyle;

            RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            RowHeadersVisible = false;

            //CELLS
            System.Windows.Forms.DataGridViewCellStyle CellStyle = new System.Windows.Forms.DataGridViewCellStyle()
            {
                Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft,
                BackColor = ColorRow,
                Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                ForeColor = ColorFontRow,
                SelectionBackColor = ColorRowSelection,
                SelectionForeColor = ColorFontRowSelection,
                WrapMode = System.Windows.Forms.DataGridViewTriState.False,
            };
            DefaultCellStyle = CellStyle;

            CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            //COLUMNS
            System.Windows.Forms.DataGridViewCellStyle ColumnHeadersStyle = new System.Windows.Forms.DataGridViewCellStyle()
            {
                BackColor = ColorColumnHeader,
                Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                ForeColor = ColorFontColumnHeader,
                SelectionBackColor = ColorColumnSelection,
                SelectionForeColor = ColorFontColumnSelection,
                WrapMode = System.Windows.Forms.DataGridViewTriState.True,
            };
            ColumnHeadersDefaultCellStyle = ColumnHeadersStyle;

            ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            ColumnHeadersHeight = 30;
        }

        //public void Reload()
        //{
        //    Refresh();
        //    SortDefaultColumn();
        //}

        public void AddColumn<T>(string ColumnName, string ColumnHeaderText = "", string ColumnDataPropertyName = "", int? index = null, bool visible = true, int ColumnWidth = 100)
        {
            DataGridViewColumn c = new DataGridViewColumn();

            Type _Type = typeof(T);

            switch (_Type.Name)
            {
                case "String":
                    c = new DataGridViewTextBoxColumn();
                    c.CellTemplate = new DataGridViewTextBoxCell();
                    //c.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                    c.Width = ColumnWidth;
                    //c.AutoSizeMode = ColumnAutoSizeMode;
                    c.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    break;
                case "Int32":
                    c = new DataGridViewTextBoxColumn();
                    c.CellTemplate = new DataGridViewTextBoxCell();
                    c.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                    c.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    c.DefaultCellStyle.Format = "N0";
                    c.DefaultCellStyle.NullValue = null;
                    break;
                case "Boolean":
                    c = new DataGridViewCheckBoxColumn();
                    c.CellTemplate = new DataGridViewCheckBoxCell();
                    c.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                    c.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    c.DefaultCellStyle.NullValue = false;
                    break;
                case "DateTime":
                    c = new DataGridViewTextBoxColumn();
                    c.CellTemplate = new DataGridViewTextBoxCell();
                    c.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                    c.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    c.DefaultCellStyle.Format = "G";
                    c.DefaultCellStyle.NullValue = null;
                    break;
                case "Bitmap":
                    c = new DataGridViewImageColumn();
                    c.CellTemplate = new DataGridViewImageCell();
                    c.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                    c.Resizable = DataGridViewTriState.False;
                    c.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    break;
            }

            //c.ValueType = _Type;
            c.Name = ColumnName;
            c.HeaderText = string.IsNullOrEmpty(ColumnHeaderText) ? ColumnName : ColumnHeaderText;
            c.DataPropertyName = string.IsNullOrEmpty(ColumnDataPropertyName) ? ColumnName : ColumnDataPropertyName;

            //AutoSizeMode All Cells in Bitmap have poor performance
            //c.AutoSizeMode = ColumnAutoSizeMode;

            c.Visible = visible;
            c.SortMode = DataGridViewColumnSortMode.Automatic;

            if (Columns.Count == 0 || index == null)
            {
                Columns.Add(c);
            }
            else
            {
                if (index > Columns.Count)
                {
                    Columns.Insert(Columns.Count, c);
                }
                else
                {
                    Columns.Insert(cConvert.ToInt(index), c);
                }
            }
        }

        //Fix Default Values
        private bool firstChange = true;
        protected void Dg_ColumnHeadersHeightSizeModeChanged(object sender, EventArgs e)
        {
            if (firstChange)
            {
                firstChange = false;
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                ColumnHeadersHeight = 30;
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e); this.Invalidate();
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e); this.Invalidate();
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e); this.Invalidate();
        }
        protected override void OnScroll(ScrollEventArgs e)
        {
            base.OnScroll(e); this.Invalidate();
        }

        #region Paint
        //MouseHoverChangeRowColor
        protected override void OnRowPostPaint(DataGridViewRowPostPaintEventArgs e)
        {
            base.OnRowPostPaint(e);

            DataGridViewRow row = ((DataGridView)this).Rows[e.RowIndex];

            if (this.RectangleToScreen(e.RowBounds).Contains(MousePosition))
            {
                row.DefaultCellStyle.BackColor = ColorRowMouseHover;
                row.DefaultCellStyle.SelectionBackColor = ColorRowMouseHover;

                //Color c = Color.FromArgb(50, Color.Blue);
                //using (var b = new SolidBrush(RowMouseHoverColor))
                //using (var p = new Pen(RowMouseHoverColor))
                //{
                //    var r = e.RowBounds;
                //    r.Width -= 1;
                //    r.Height -= 1;
                //    e.Graphics.FillRectangle(b, r);
                //    e.Graphics.DrawRectangle(p, r);
                //}
            }
            else
            {
                row.DefaultCellStyle.SelectionBackColor = ColorRowSelection;

                if (e.RowIndex % 2 == 0)
                {
                    row.DefaultCellStyle.BackColor = ColorRow;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = ColorRowAlternate;
                }
            }
        }

        public void RefreshCellsForeColor(string columnId, string valueId, string columnName, bool change, Color? c = null)
        {
            foreach (DataGridViewRow Row in this.Rows)
            {
                if (Row.Cells[columnId].Value.ToString() == valueId)
                {
                    ChangeCellForeColor(Row.Cells[columnName], change, c);
                }
            }
        }

        public void ChangeCellForeColor(DataGridViewCell cell, bool change, Color? c = null)
        {
            Color color = Color.Red;

            if (c != null) { color = (Color)c; }

            if (!change)
            {
                cell.Style.SelectionForeColor = color;
                cell.Style.ForeColor = color;
            }
            else
            {
                cell.Style.SelectionForeColor = this.DefaultCellStyle.SelectionForeColor;
                cell.Style.ForeColor = this.DefaultCellStyle.ForeColor;
            }
        }
        #endregion

        #region SortColumns
        //public void ReSort()
        //{
        //    this.Sort(this.Columns[LastSortedColumn], LastSortedColumnDirection);
        //    this.Refresh();
        //}

        protected void Dg_OnSorted(object sender, EventArgs e)
        {
            LoadBooleanImages();
        }

        protected void Dg_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            LastSortedColumn = this.Columns[e.ColumnIndex].Name;

            if (this.SortOrder == SortOrder.Descending)
            {
                LastSortedColumnDirection = ListSortDirection.Ascending;
            }
            else
            {
                LastSortedColumnDirection = ListSortDirection.Descending;
            }

            SortImageColumns(sender, e);
        }

        public void SetDefaultColumn(string ColumnName, bool Ascending = true)
        {
            DefaultColumn = ColumnName;
            DefaultColumnDirection = Ascending ? ListSortDirection.Ascending : ListSortDirection.Descending;

            LastSortedColumn = DefaultColumn;
            LastSortedColumnDirection = DefaultColumnDirection;
        }

        public void SortDefaultColumn()
        {
            if (Columns.Contains(DefaultColumn))
            {
                this.Sort(this.Columns[DefaultColumn], DefaultColumnDirection);
            }
        }

        public void SortImageColumns(object sender, DataGridViewCellMouseEventArgs e)
        {
            string clickedColumn = this.Columns[e.ColumnIndex].Name;
            string sortColumn = string.Empty;

            if (clickedColumn.Length > 2)
            {
                sortColumn = clickedColumn.Substring(0, clickedColumn.Length - 3);
            }

            List<string> booleanColumns = GetBooleanColumns();

            if (booleanColumns != null && sortColumn != string.Empty && booleanColumns.Exists(s => s.EndsWith(sortColumn)))
            {
                SortColumn(this.Columns[sortColumn], this.Columns[clickedColumn], e);
            }
        }

        private void SortColumn(DataGridViewColumn sortColumn, DataGridViewColumn clickedColumn, DataGridViewCellMouseEventArgs e)
        {
            DataGridView dgv = clickedColumn.DataGridView;

            if (dgv.Columns[e.ColumnIndex].Name == clickedColumn.Name)
            {
                if (dgv.SortOrder == SortOrder.Descending)
                {
                    dgv.Sort(sortColumn, ListSortDirection.Ascending);
                    clickedColumn.HeaderCell.SortGlyphDirection = SortOrder.Ascending;
                }
                else
                {
                    dgv.Sort(sortColumn, ListSortDirection.Descending);
                    clickedColumn.HeaderCell.SortGlyphDirection = SortOrder.Descending;
                }
            }
        }
        #endregion

        #region ImageColumns
        protected void Dg_DataSourceChanged(object sender, EventArgs e)
        {
            SetBooleanColumns(GetBooleanColumns());
            LoadBooleanImages();
            SortDefaultColumn();
        }

        private string boolColumnSufix = "Bol";
        public void SetBooleanColumns(List<string> ColumnsBoolean)
        {
            ColumnsBooleanNames = ColumnsBoolean;

            foreach (string ColumnsBooleanName in ColumnsBooleanNames)
            {
                //Disable old Column
                if (Columns.Contains(ColumnsBooleanName))
                {
                    string newColumn = ColumnsBooleanName + boolColumnSufix;

                    //Add Image Columns
                    if (!Columns.Contains(newColumn))
                    {
                        AddColumn<Bitmap>(newColumn, ColumnsBooleanName, "", Columns[ColumnsBooleanName].Index);
                    }

                    Columns[ColumnsBooleanName].Visible = false;
                }
            }
        }

        public List<string> GetBooleanColumns()
        {
            return ColumnsBooleanNames;
        }

        Bitmap imgtrue = Properties.Resources.img_true_ico;
        Bitmap imgfalse = Properties.Resources.img_false_ico;
        public void LoadBooleanImages()
        {
            List<string> BooleanColumns = GetBooleanColumns();

            if (BooleanColumns == null) { return; }

            foreach (DataGridViewRow row in this.Rows)
            {
                foreach (string BooleanColumn in BooleanColumns)
                {
                    if (Columns.Contains(BooleanColumn) && Columns.Contains(BooleanColumn + boolColumnSufix))
                    {
                        string cellValue = row.Cells[BooleanColumn].Value != null ? row.Cells[BooleanColumn].Value.ToString() : string.Empty;
                        row.Cells[BooleanColumn + boolColumnSufix].Value = (cellValue == "True") ? imgtrue : imgfalse;
                    }
                }
            }
        }

        //public void RefreshBooleanImage(string columnName, string cellValue, string booleanColumn, bool value)
        //{
        //    foreach (DataGridViewRow Row in this.Rows)
        //    {
        //        if (Row.Cells[columnName].Value.ToString() == cellValue)
        //        {
        //            Row.Cells[booleanColumn + boolColumnSufix].Value = (value == true) ? imgtrue : imgfalse;
        //        }
        //    }
        //}
        #endregion
    }
}
