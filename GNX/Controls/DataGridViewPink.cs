using System;
using System.Windows.Forms;
//
using System.ComponentModel;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace GNX
{
    public partial class DataGridViewPink : DataGridView
    {
        private string DefaultColumn;
        private ListSortDirection DefaultColumnDirection;
        private List<string> ColumnsBooleanNames;

        private string LastSortedColumn;
        private ListSortDirection LastSortedColumnDirection;

        private DataGridViewCellStyle AlternatingRowsStyle = new DataGridViewCellStyle();
        private DataGridViewCellStyle RowHeadersStyle = new DataGridViewCellStyle();
        private DataGridViewCellStyle CellStyle = new DataGridViewCellStyle();
        private DataGridViewCellStyle ColumnHeadersStyle = new DataGridViewCellStyle();

        private Color _DgvColor;
        public Color DgvColor { get { return _DgvColor; } set { _DgvColor = BackgroundColor = value; } }
        private Color _DgvGridColor;
        public Color DgvGridColor { get { return _DgvGridColor; } set { _DgvGridColor = GridColor = value; } }

        private Color _RowAlternateColor;
        public Color RowAlternateColor
        {
            get
            {   //return _RowAlternateColor; 
                return AlternatingRowsDefaultCellStyle.BackColor;
            }
            set
            {
                //_RowAlternateColor = AlternatingRowsDefaultCellStyle.BackColor = AlternatingRowsStyle.BackColor = value;
                AlternatingRowsDefaultCellStyle.BackColor = value;
            }
        }

        public Color RowMouseHoverColor { get; set; }

        private Color _RowHeaderColor;
        public Color RowHeaderColor
        {
            get { return _RowHeaderColor; }
            set
            {
                _RowHeaderColor = RowHeadersDefaultCellStyle.BackColor = RowHeadersStyle.BackColor = value;
            }
        }

        private Color _RowHeaderSelectionColor;
        public Color RowHeaderSelectionColor
        {
            get { return _RowHeaderSelectionColor; }
            set
            {
                _RowHeaderSelectionColor = RowHeadersDefaultCellStyle.SelectionBackColor = RowHeadersStyle.SelectionBackColor = value;
            }
        }

        private Color _CellColor;
        public Color CellColor
        {
            get { return _CellColor; }
            set
            {
                _CellColor = DefaultCellStyle.BackColor = CellStyle.BackColor = value;
            }
        }

        private Color _CellSelectionColor;
        public Color CellSelectionColor
        {
            get { return _CellSelectionColor; }
            set
            {
                _CellSelectionColor = DefaultCellStyle.SelectionBackColor = CellStyle.SelectionBackColor = value;
            }
        }

        private Color _ColumnHeaderColor;
        public Color ColumnHeaderColor
        {
            get { return _ColumnHeaderColor; }
            set
            {
                _ColumnHeaderColor = ColumnHeadersDefaultCellStyle.BackColor = ColumnHeadersStyle.BackColor = value;
            }
        }

        private Color _ColumnSelectionColor;
        public Color ColumnSelectionColor
        {
            get { return _ColumnSelectionColor; }
            set
            {
                _ColumnSelectionColor = ColumnHeadersDefaultCellStyle.SelectionBackColor = ColumnHeadersStyle.SelectionBackColor = value;

            }
        }

        public DataGridViewPink()
        {
            InitializeComponent();

            #region COLORS
            DoubleBuffered = true;

            DgvColor = Color.White;
            DgvGridColor = Color.Silver;

            RowAlternateColor = Color.White;
            RowMouseHoverColor = Color.FromArgb(163, 228, 196);

            RowHeaderColor = Color.White;
            RowHeaderSelectionColor = SystemColors.Highlight;

            CellColor = Color.White;
            CellSelectionColor = Color.FromArgb(229, 226, 244);

            ColumnHeaderColor = Color.FromArgb(109, 122, 224);
            ColumnSelectionColor = SystemColors.Highlight;
            #endregion

            SetStyles();

            ColumnHeaderMouseClick += dgv_ColumnHeaderMouseClick;
            Sorted += dgv_OnSorted;
            //RowPostPaint += OnRowPostPaint;
        }

        private void SetStyles()
        {
            //MAIN
            Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));

            CausesValidation = false;

            AllowUserToAddRows = false;
            AllowUserToDeleteRows = false;

            BackgroundColor = DgvColor;
            BorderStyle = System.Windows.Forms.BorderStyle.None;
            GridColor = DgvGridColor;
            Margin = new System.Windows.Forms.Padding(0);
            MultiSelect = false;
            SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ReadOnly = true;
            TabStop = false;

            //ROWS
            RowTemplate.Height = 30;
            RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;

            //Alternate Rows
            //System.Windows.Forms.DataGridViewCellStyle AlternatingRowsStyle = new System.Windows.Forms.DataGridViewCellStyle();
            AlternatingRowsStyle.BackColor = RowAlternateColor;
            AlternatingRowsDefaultCellStyle = AlternatingRowsStyle;

            //ROWS_HEADERS
            //System.Windows.Forms.DataGridViewCellStyle RowHeadersStyle = new System.Windows.Forms.DataGridViewCellStyle();
            RowHeadersStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            RowHeadersStyle.BackColor = RowHeaderColor;
            RowHeadersStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            RowHeadersStyle.ForeColor = System.Drawing.Color.White;
            RowHeadersStyle.SelectionBackColor = RowHeaderSelectionColor;
            RowHeadersStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            RowHeadersStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            RowHeadersDefaultCellStyle = RowHeadersStyle;

            RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            RowHeadersVisible = false;

            //CELLS
            //System.Windows.Forms.DataGridViewCellStyle CellStyle = new System.Windows.Forms.DataGridViewCellStyle();
            CellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            CellStyle.BackColor = CellColor;
            CellStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            CellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            CellStyle.SelectionBackColor = CellSelectionColor;
            CellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            CellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            DefaultCellStyle = CellStyle;

            CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            //COLUMNS

            ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            ColumnHeadersHeight = 30;

            EnableHeadersVisualStyles = false;

            //System.Windows.Forms.DataGridViewCellStyle ColumnHeadersStyle = new System.Windows.Forms.DataGridViewCellStyle();
            ColumnHeadersStyle.BackColor = ColumnHeaderColor;
            ColumnHeadersStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ColumnHeadersStyle.ForeColor = System.Drawing.Color.White;
            ColumnHeadersStyle.SelectionBackColor = ColumnSelectionColor;
            ColumnHeadersStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            ColumnHeadersStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            ColumnHeadersDefaultCellStyle = ColumnHeadersStyle;
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

        //MouseHoverChangeRowColor
        protected override void OnRowPostPaint(DataGridViewRowPostPaintEventArgs e)
        {
            base.OnRowPostPaint(e);

            DataGridViewRow row = ((DataGridView)this).Rows[e.RowIndex];

            if (this.RectangleToScreen(e.RowBounds).Contains(MousePosition))
            {
                row.DefaultCellStyle.BackColor = RowMouseHoverColor;
                row.DefaultCellStyle.SelectionBackColor = RowMouseHoverColor;

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
                row.DefaultCellStyle.SelectionBackColor = CellSelectionColor;

                if (e.RowIndex % 2 == 0)
                {
                    row.DefaultCellStyle.BackColor = CellColor;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = RowAlternateColor;
                }
            }
        }

        private void dgv_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
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

        private void DataGridViewPink_LocationChanged(object sender, EventArgs e)
        {
            ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            ColumnHeadersHeight = 30;
        }

        private void dgv_OnSorted(object sender, EventArgs e)
        {
            LoadBooleanImages();
        }

        public void ReSort()
        {
            this.Sort(this.Columns[LastSortedColumn], LastSortedColumnDirection);
            this.Refresh();
        }

        public void RefreshBooleanImage(string columnName, string cellValue, string booleanColumn, bool value)
        {
            foreach (DataGridViewRow Row in this.Rows)
            {
                if (Row.Cells[columnName].Value.ToString() == cellValue)
                {
                    Row.Cells[booleanColumn + "Bol"].Value = (value == true) ? Properties.Resources.img_true_ico : Properties.Resources.img_false_ico;
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

        public void Reload()
        {
            Refresh();
            SortDefaultColumn();
        }

        public void AddColumn<T>(string ColumnName, string ColumnHeaderText, string ColumnDataPropertyName, DataGridViewAutoSizeColumnMode ColumnAutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells, bool visible = true)
        {
            DataGridViewColumn c = new DataGridViewColumn();

            Type _Type = typeof(T);

            switch (_Type.Name)
            {
                case "String":
                    c = new DataGridViewTextBoxColumn();
                    c.CellTemplate = new DataGridViewTextBoxCell();
                    break;
                case "Int32":
                    c = new DataGridViewTextBoxColumn();
                    c.CellTemplate = new DataGridViewTextBoxCell();
                    c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    c.DefaultCellStyle.Format = "N0";
                    c.DefaultCellStyle.NullValue = null;
                    break;
                case "DateTime":
                    c = new DataGridViewTextBoxColumn();
                    c.CellTemplate = new DataGridViewTextBoxCell();
                    c.DefaultCellStyle.Format = "G";
                    c.DefaultCellStyle.NullValue = null;
                    break;
                case "Bitmap":
                    c = new DataGridViewImageColumn();
                    c.CellTemplate = new DataGridViewImageCell();
                    break;
            }

            //c.ValueType = _Type;
            c.Name = ColumnName;
            c.HeaderText = ColumnHeaderText;
            c.DataPropertyName = ColumnDataPropertyName;
            c.AutoSizeMode = ColumnAutoSizeMode;
            c.Visible = visible;
            c.SortMode = DataGridViewColumnSortMode.Automatic;

            Columns.Add(c);
        }

        #region SortColumns
        public void SetDefaultColumn(string ColumnName, bool Ascending)
        {
            DefaultColumn = ColumnName;
            DefaultColumnDirection = Ascending ? ListSortDirection.Ascending : ListSortDirection.Descending;

            LastSortedColumn = DefaultColumn;
            LastSortedColumnDirection = DefaultColumnDirection;
        }

        public void SortDefaultColumn()
        {
            if (DefaultColumn != null)
            {
                this.Sort(this.Columns[DefaultColumn], DefaultColumnDirection);
            }
        }

        public void SortImageColumns(object sender, DataGridViewCellMouseEventArgs e)
        {
            string HeaderText = this.Columns[e.ColumnIndex].Name;
            string HeaderTextSort = string.Empty;

            if (HeaderText.Length > 2)
            {
                HeaderTextSort = HeaderText.Substring(0, HeaderText.Length - 3);
            }

            List<string> BooleanColumns = GetBooleanColumns();

            if (BooleanColumns != null && HeaderTextSort != string.Empty && BooleanColumns.Exists(s => s.EndsWith(HeaderTextSort)))
            {
                SortColumn(this.Columns[HeaderTextSort], this.Columns[HeaderText], e);
            }
        }

        private void SortColumn(DataGridViewColumn ColumnSort, DataGridViewColumn ColumnClicked, DataGridViewCellMouseEventArgs e)
        {
            DataGridView dgv = ColumnClicked.DataGridView;

            if (dgv.Columns[e.ColumnIndex].Name == ColumnClicked.Name)
            {
                if (dgv.SortOrder == SortOrder.Descending)
                {
                    dgv.Sort(ColumnSort, ListSortDirection.Ascending);
                    ColumnClicked.HeaderCell.SortGlyphDirection = SortOrder.Ascending;
                }
                else
                {
                    dgv.Sort(ColumnSort, ListSortDirection.Descending);
                    ColumnClicked.HeaderCell.SortGlyphDirection = SortOrder.Descending;
                }
            }
        }
        #endregion

        #region ImageColumns
        public void SetBooleanColumns(List<string> ColumnsBoolean)
        {
            ColumnsBooleanNames = ColumnsBoolean;

            foreach (string ColumnsBooleanName in ColumnsBooleanNames)
            {
                Columns[ColumnsBooleanName].Visible = false;
            }
        }

        public List<string> GetBooleanColumns()
        {
            return ColumnsBooleanNames;
        }

        public void LoadBooleanImages()
        {
            List<string> BooleanColumns = GetBooleanColumns();

            if (BooleanColumns != null)
            {
                foreach (DataGridViewRow row in this.Rows)
                {
                    foreach (string BooleanColumn in BooleanColumns)
                    {
                        string CellValue = row.Cells[BooleanColumn].Value != null ? row.Cells[BooleanColumn].Value.ToString() : string.Empty;

                        row.Cells[BooleanColumn + "Bol"].Value = (CellValue == "True") ? Properties.Resources.img_true_ico : Properties.Resources.img_false_ico;
                    }
                }
            }
        }
        #endregion
    }
}
