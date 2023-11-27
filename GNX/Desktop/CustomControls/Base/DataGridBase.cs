using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace GNX.Desktop
{
    public partial class DataGridBase : DataGridView
    {
        #region Defaults
        [DefaultValue(false)]
        public new bool AllowUserToAddRows
        {
            get { return base.AllowUserToAddRows; }
            set { base.AllowUserToAddRows = value; }
        }

        [DefaultValue(false)]
        public new bool AllowUserToDeleteRows
        {
            get { return base.AllowUserToDeleteRows; }
            set { base.AllowUserToDeleteRows = value; }
        }

        [DefaultValue(typeof(AnchorStyles), "Top, Bottom, Left, Right")]
        public new AnchorStyles Anchor
        {
            get { return base.Anchor; }
            set { base.Anchor = value; }
        }

        [DefaultValue(false)]
        public new bool CausesValidation
        {
            get { return base.CausesValidation; }
            set { base.CausesValidation = value; }
        }

        [DefaultValue(typeof(BorderStyle), "None")]
        public new BorderStyle BorderStyle
        {
            get { return base.BorderStyle; }
            set { base.BorderStyle = value; }
        }

        [DefaultValue(typeof(DataGridViewCellBorderStyle), "SingleHorizontal")]
        public new DataGridViewCellBorderStyle CellBorderStyle
        {
            get { return base.CellBorderStyle; }
            set { base.CellBorderStyle = value; }
        }

        [DefaultValue(typeof(DataGridViewHeaderBorderStyle), "Single")]
        public new DataGridViewHeaderBorderStyle ColumnHeadersBorderStyle
        {
            get { return base.ColumnHeadersBorderStyle; }
            set { base.ColumnHeadersBorderStyle = value; }
        }

        [DefaultValue(30)]
        public new int ColumnHeadersHeight
        {
            get { return base.ColumnHeadersHeight; }
            set { base.ColumnHeadersHeight = value; }
        }

        [DefaultValue(typeof(DataGridViewColumnHeadersHeightSizeMode), "DisableResizing")]
        public new DataGridViewColumnHeadersHeightSizeMode ColumnHeadersHeightSizeMode
        {
            get { return base.ColumnHeadersHeightSizeMode; }
            set { base.ColumnHeadersHeightSizeMode = value; }
        }

        [DefaultValue(false)]
        public new bool EnableHeadersVisualStyles
        {
            get { return base.EnableHeadersVisualStyles; }
            set { base.EnableHeadersVisualStyles = value; }
        }

        [DefaultValue(false)]
        public new bool MultiSelect
        {
            get { return base.MultiSelect; }
            set { base.MultiSelect = value; }
        }

        [DefaultValue(true)]
        public new bool ReadOnly
        {
            get { return base.ReadOnly; }
            set { base.ReadOnly = value; }
        }

        [DefaultValue(typeof(DataGridViewHeaderBorderStyle), "Single")]
        public new DataGridViewHeaderBorderStyle RowHeadersBorderStyle
        {
            get { return base.RowHeadersBorderStyle; }
            set { base.RowHeadersBorderStyle = value; }
        }

        [DefaultValue(false)]
        public new bool RowHeadersVisible
        {
            get { return base.RowHeadersVisible; }
            set { base.RowHeadersVisible = value; }
        }

        [DefaultValue(typeof(DataGridViewRowHeadersWidthSizeMode), "DisableResizing")]
        public new DataGridViewRowHeadersWidthSizeMode RowHeadersWidthSizeMode
        {
            get { return base.RowHeadersWidthSizeMode; }
            set { base.RowHeadersWidthSizeMode = value; }
        }

        [DefaultValue(typeof(DataGridViewSelectionMode), "FullRowSelect")]
        public new DataGridViewSelectionMode SelectionMode
        {
            get { return base.SelectionMode; }
            set { base.SelectionMode = value; }
        }

        [DefaultValue(false)]
        public new bool TabStop
        {
            get { return base.TabStop; }
            set { base.TabStop = value; }
        }
        #endregion

        string DefaultColumn = string.Empty;
        ListSortDirection DefaultColumnDirection;
        List<string> ColumnsBooleanNames = new List<string>();

        string LastSortedColumn;

        [Browsable(false)]
        public Color ColorBackground { get { return BackgroundColor; } set { BackgroundColor = value; } }
        [Browsable(false)]
        public Color ColorGrid { get { return GridColor; } set { GridColor = value; } }
        [Browsable(false)]
        public Color ColorRow { get { return DefaultCellStyle.BackColor; } set { DefaultCellStyle.BackColor = value; } }
        [Browsable(false)]
        public Color ColorRowAlternate { get { return AlternatingRowsDefaultCellStyle.BackColor; } set { AlternatingRowsDefaultCellStyle.BackColor = value; } }
        [Browsable(false)]
        public Color ColorRowSelection { get { return DefaultCellStyle.SelectionBackColor; } set { DefaultCellStyle.SelectionBackColor = value; } }
        [Browsable(false)]
        public Color ColorRowMouseHover { get; set; }
        [Browsable(false)]
        public Color ColorFontRow { get { return DefaultCellStyle.ForeColor; } set { DefaultCellStyle.ForeColor = value; } }
        [Browsable(false)]
        public Color ColorFontRowSelection { get { return DefaultCellStyle.SelectionForeColor; } set { DefaultCellStyle.SelectionForeColor = value; } }

        protected Color ColorRowHeader { get { return RowHeadersDefaultCellStyle.BackColor; } set { RowHeadersDefaultCellStyle.BackColor = value; } }
        protected Color ColorRowHeaderSelection { get { return RowHeadersDefaultCellStyle.SelectionBackColor; } set { RowHeadersDefaultCellStyle.SelectionBackColor = value; } }
        protected Color ColorFontRowHeader { get { return RowHeadersDefaultCellStyle.ForeColor; } set { RowHeadersDefaultCellStyle.ForeColor = value; } }
        protected Color ColorFontRowHeaderSelection { get { return RowHeadersDefaultCellStyle.SelectionForeColor; } set { RowHeadersDefaultCellStyle.SelectionForeColor = value; } }

        [Browsable(false)]
        public Color ColorColumnHeader { get { return ColumnHeadersDefaultCellStyle.BackColor; } set { ColumnHeadersDefaultCellStyle.BackColor = value; } }
        [Browsable(false)]
        public Color ColorColumnSelection { get { return ColumnHeadersDefaultCellStyle.SelectionBackColor; } set { ColumnHeadersDefaultCellStyle.SelectionBackColor = value; } }

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
            Anchor = (((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right);

            CausesValidation = false;

            AllowUserToAddRows = false;
            AllowUserToDeleteRows = false;

            BackgroundColor = ColorBackground;
            BorderStyle = BorderStyle.None;
            GridColor = ColorGrid;
            //Margin = new System.Windows.Forms.Padding(0);
            MultiSelect = false;
            SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ReadOnly = true;
            TabStop = false;
            EnableHeadersVisualStyles = false;

            AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            //ROWS
            RowTemplate.Height = 30;
            RowTemplate.Resizable = DataGridViewTriState.False;

            //Alternate Rows
            AlternatingRowsDefaultCellStyle.BackColor = ColorRowAlternate;

            //ROWS_HEADERS
            var RowHeadersStyle = new DataGridViewCellStyle
            {
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                BackColor = ColorRowHeader,
                Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0),
                ForeColor = ColorFontRowHeader,
                SelectionBackColor = ColorRowHeaderSelection,
                SelectionForeColor = ColorFontRowHeaderSelection,
                WrapMode = DataGridViewTriState.True
            };
            RowHeadersDefaultCellStyle = RowHeadersStyle;

            RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            RowHeadersVisible = false;

            //CELLS
            var CellStyle = new DataGridViewCellStyle
            {
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                BackColor = ColorRow,
                Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0),
                ForeColor = ColorFontRow,
                SelectionBackColor = ColorRowSelection,
                SelectionForeColor = ColorFontRowSelection,
                WrapMode = DataGridViewTriState.False
            };

            DefaultCellStyle = CellStyle;
            CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            //COLUMNS
            var ColumnHeadersStyle = new DataGridViewCellStyle
            {
                BackColor = ColorColumnHeader,
                Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0),
                ForeColor = ColorFontColumnHeader,
                SelectionBackColor = ColorColumnSelection,
                SelectionForeColor = ColorFontColumnSelection,
                WrapMode = DataGridViewTriState.True
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

        public void AddColumnInvisible<T>(string ColumnName, string ColumnHeaderText = "", string ColumnDataPropertyName = "")
        {
            AddColumn<T>(ColumnName, ColumnHeaderText, ColumnDataPropertyName, "", DataGridViewContentAlignment.NotSet, null, false);
        }

        public void AddColumn<T>(string ColumnName, string ColumnHeaderText = "", string ColumnDataPropertyName = "", string ColumnFormat = "", DataGridViewContentAlignment ColumnAlignment = 0, int? index = null, bool visible = true, int ColumnWidth = 100)
        {
            var c = new DataGridViewColumn();

            Type _Type = typeof(T);

            switch (_Type.Name)
            {
                case "String":
                    c = new DataGridViewTextBoxColumn { CellTemplate = new DataGridViewTextBoxCell() };
                    //c.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                    if (ColumnWidth != 0) { c.Width = ColumnWidth; }
                    //c.AutoSizeMode = ColumnAutoSizeMode;
                    c.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    c.DefaultCellStyle.Alignment = ColumnAlignment == 0 ? DataGridViewContentAlignment.MiddleLeft : ColumnAlignment;
                    c.DefaultCellStyle.Format = string.IsNullOrEmpty(ColumnFormat) ? "" : ColumnFormat;
                    break;
                case "Int32":
                    c = new DataGridViewTextBoxColumn { CellTemplate = new DataGridViewTextBoxCell() };
                    //c.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                    if (ColumnWidth != 0) { c.Width = ColumnWidth; }
                    c.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    c.DefaultCellStyle.Alignment = ColumnAlignment == 0 ? DataGridViewContentAlignment.MiddleRight : ColumnAlignment;
                    c.DefaultCellStyle.Format = string.IsNullOrEmpty(ColumnFormat) ? "" : ColumnFormat;
                    c.DefaultCellStyle.NullValue = null;
                    break;
                case "Single":
                    c = new DataGridViewTextBoxColumn { CellTemplate = new DataGridViewTextBoxCell() };
                    c.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    c.DefaultCellStyle.Format = string.IsNullOrEmpty(ColumnFormat) ? "N0" : ColumnFormat;
                    c.DefaultCellStyle.NullValue = null;
                    break;
                case "TimeSpan":
                    c = new DataGridViewTextBoxColumn { CellTemplate = new DataGridViewTextBoxCell() };
                    c.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    c.DefaultCellStyle.Format = "hh\\:mm";
                    c.DefaultCellStyle.NullValue = null;
                    break;
                case "Boolean":
                    c = new DataGridViewCheckBoxColumn
                    {
                        CellTemplate = new DataGridViewCheckBoxCell(),
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                    };
                    c.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    c.DefaultCellStyle.NullValue = false;
                    break;
                case "DateTime":
                    c = new DataGridViewTextBoxColumn { CellTemplate = new DataGridViewTextBoxCell() };
                    //c.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                    if (ColumnWidth != 100) { c.Width = ColumnWidth; } else { c.Width = 110; }
                    c.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    c.DefaultCellStyle.Format = "d";
                    c.DefaultCellStyle.NullValue = null;
                    break;
                case "Bitmap":
                    c = new DataGridViewImageColumn
                    {
                        CellTemplate = new DataGridViewImageCell(),
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                        Resizable = DataGridViewTriState.False
                    };
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
                    Columns.Insert(Cast.ToInt(index), c);
                }
            }
        }

        //Fix Default Values
        bool firstChange = true;
        protected void Dg_ColumnHeadersHeightSizeModeChanged(object sender, EventArgs e)
        {
            if (firstChange)
            {
                firstChange = false;
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                ColumnHeadersHeight = 30;
            }
        }

        protected override void OnScroll(ScrollEventArgs e)
        {
            base.OnScroll(e);
            Invalidate();
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            Invalidate();
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            Invalidate();
        }

        #region Paint
        //AdjustImageQuality
        protected override void OnCellPainting(DataGridViewCellPaintingEventArgs e)
        {
            base.OnCellPainting(e);

            e.Graphics.InterpolationMode = InterpolationMode.Bilinear;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.Default;

            if (e.RowHeader()) { return; }

            if (e.Value is Bitmap)
            {
                var image = e.Value as Bitmap;
                var cellSize = e.CellBounds;
                var padding = e.CellStyle.Padding.All;

                if (image.Width > cellSize.Width - padding || image.Height > cellSize.Height - padding)
                {
                    e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    //e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                }
                else
                {
                    e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
                    //e.Graphics.PixelOffsetMode = PixelOffsetMode.Half;
                }
            }
        }

        bool InColumnResize
        {
            get { return (MouseButtons == MouseButtons.Left) && (Cursor == Cursors.SizeWE); }
        }

        readonly Pen resizePen = new Pen(Colors.RGB(86, 86, 86), 1) { DashStyle = DashStyle.Dot };
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (InColumnResize)
            {
                var xPoint = PointToClient(new Point(Cursor.Position.X, Cursor.Position.Y)).X;
                var yStart = ColumnHeadersHeight;
                var yEnd = Size.Height;

                e.Graphics.DrawLine(resizePen, xPoint - 1, yStart, xPoint - 1, yEnd);
                e.Graphics.DrawLine(resizePen, xPoint, yStart + 1, xPoint, yEnd - 1);
                e.Graphics.DrawLine(resizePen, xPoint + 1, yStart, xPoint + 1, yEnd);
            }
        }

        //MouseMoveChangeRowColor
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (InColumnResize) { Invalidate(); }

            base.OnMouseMove(e);

            int index = HitTest(e.X, e.Y).RowIndex;

            if (index > -1)
            {
                var row = Rows[index];
                row.DefaultCellStyle.BackColor = ColorRowMouseHover;
                row.DefaultCellStyle.SelectionBackColor = ColorRowMouseHover;
            }
        }

        //ChangeRowColorBackToNormal
        protected override void OnRowPostPaint(DataGridViewRowPostPaintEventArgs e)
        {
            base.OnRowPostPaint(e);

            var row = Rows[e.RowIndex];

            if (RectangleToScreen(e.RowBounds).Contains(MousePosition))
            {
                //row.DefaultCellStyle.BackColor = ColorRowMouseHover;
                //row.DefaultCellStyle.SelectionBackColor = ColorRowMouseHover;

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
            foreach (DataGridViewRow Row in Rows)
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
                cell.Style.SelectionForeColor = DefaultCellStyle.SelectionForeColor;
                cell.Style.ForeColor = DefaultCellStyle.ForeColor;
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
            LastSortedColumn = Columns[e.ColumnIndex].Name;

            SortImageColumns(sender, e);
        }

        public void OrderBy(string columnName, bool ascending = true)
        {
            DefaultColumn = columnName;
            DefaultColumnDirection = ascending ? ListSortDirection.Ascending : ListSortDirection.Descending;

            LastSortedColumn = DefaultColumn;
        }

        public void SortDefaultColumn(bool lastSortedDirection = false)
        {
            if (Columns.Contains(DefaultColumn))
            {
                if (!lastSortedDirection)
                {
                    Sort(Columns[DefaultColumn], DefaultColumnDirection);
                }
                else
                {
                    //Maintain sort direction after refresh
                    if (Columns[LastSortedColumn] is DataGridViewImageColumn)
                    {
                        var a = new DataGridViewCellMouseEventArgs(Columns[LastSortedColumn].Index, 0, 0, 0, new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
                        SortImageColumns(null, a);
                        SortImageColumns(null, a);
                    }
                    else
                    {
                        if (SortOrder == SortOrder.Descending)
                        {
                            Sort(Columns[LastSortedColumn], ListSortDirection.Descending);
                        }
                        else
                        {
                            Sort(Columns[LastSortedColumn], ListSortDirection.Ascending);
                        }
                    }
                }
            }
        }

        public void SortImageColumns(object sender, DataGridViewCellMouseEventArgs e)
        {
            string clickedColumn = Columns[e.ColumnIndex].Name;
            string sortColumn = string.Empty;

            if (clickedColumn.Length > 2)
            {
                sortColumn = clickedColumn.Substring(0, clickedColumn.Length - 3);
            }

            var booleanColumns = GetBooleanColumns();

            if (booleanColumns != null && sortColumn != string.Empty && booleanColumns.Exists(s => s.EndsWith(sortColumn, StringComparison.OrdinalIgnoreCase)))
            {
                SortColumn(Columns[sortColumn], Columns[clickedColumn], e);
            }
        }

        void SortColumn(DataGridViewColumn sortColumn, DataGridViewColumn clickedColumn, DataGridViewCellMouseEventArgs e)
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
            SortDefaultColumn();
        }

        readonly string boolColumnSufix = "Bol";
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
                        AddColumn<Bitmap>(newColumn, ColumnsBooleanName, "", "", DataGridViewContentAlignment.NotSet, Columns[ColumnsBooleanName].Index);
                    }

                    Columns[ColumnsBooleanName].Visible = false;
                }
            }
        }

        public List<string> GetBooleanColumns()
        {
            return ColumnsBooleanNames;
        }

        readonly Bitmap imgtrue = Properties.Resources.img_true_ico;
        readonly Bitmap imgfalse = Properties.Resources.img_false_ico;

        public void LoadBooleanImages()
        {
            var BooleanColumns = GetBooleanColumns();

            if (BooleanColumns == null) { return; }

            var imgtruePerformatic = imgtrue.Clone32bpp();
            var imgfalsePerformatic = imgfalse.Clone32bpp();

            foreach (DataGridViewRow row in Rows)
            {
                foreach (string BooleanColumn in BooleanColumns)
                {
                    if (Columns.Contains(BooleanColumn) && Columns.Contains(BooleanColumn + boolColumnSufix))
                    {
                        string cellValue = row.Cells[BooleanColumn].Value != null ? row.Cells[BooleanColumn].Value.ToString() : string.Empty;
                        row.Cells[BooleanColumn + boolColumnSufix].Value = (cellValue == "True") ? imgtruePerformatic : imgfalsePerformatic;
                    }
                }
            }
        }

        public void RefreshRows()
        {
            //SortDefaultColumn(true);
            LoadBooleanImages();
            Refresh();
        }

        //public void RefreshBooleanImage(string column, string cellValue, string booleanColumn, bool value)
        //{
        //    foreach (DataGridViewRow Row in this.Rows)
        //    {
        //        if (Row.Cells[column].Value.ToString() == cellValue)
        //        {
        //            Row.Cells[booleanColumn + boolColumnSufix].Value = (value == true) ? imgtrue : imgfalse;
        //        }
        //    }
        //}
        #endregion
    }
}