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

        public Color ColorBackground { get { return BackgroundColor; } set { BackgroundColor = value; } }
        public Color ColorGrid { get { return GridColor; } set { GridColor = value; } }
        public Color ColorRow { get { return DefaultCellStyle.BackColor; } set { DefaultCellStyle.BackColor = value; } }
        public Color ColorRowAlternate { get { return AlternatingRowsDefaultCellStyle.BackColor; } set { AlternatingRowsDefaultCellStyle.BackColor = value; } }
        public Color ColorRowSelection { get { return DefaultCellStyle.SelectionBackColor; } set { DefaultCellStyle.SelectionBackColor = value; } }
        public Color ColorRowMouseHover { get; set; }
        public Color ColorRowHeader { get { return RowHeadersDefaultCellStyle.BackColor; } set { RowHeadersDefaultCellStyle.BackColor = value; } }
        public Color ColorRowHeaderSelection { get { return RowHeadersDefaultCellStyle.SelectionBackColor; } set { RowHeadersDefaultCellStyle.SelectionBackColor = value; } }
        public Color ColorColumnHeader { get { return ColumnHeadersDefaultCellStyle.BackColor; } set { ColumnHeadersDefaultCellStyle.BackColor = value; } }
        public Color ColorColumnSelection { get { return ColumnHeadersDefaultCellStyle.SelectionBackColor; } set { ColumnHeadersDefaultCellStyle.SelectionBackColor = value; } }

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
            #endregion

            SetStyles();

            ColumnHeaderMouseClick += dgv_ColumnHeaderMouseClick;
            Sorted += dgv_OnSorted;
            //RowPostPaint += OnRowPostPaint;
        }

        private void SetStyles()
        {
            //MAIN
            DoubleBuffered = true;

            Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));

            CausesValidation = false;

            AllowUserToAddRows = false;
            AllowUserToDeleteRows = false;

            BackgroundColor = ColorBackground;
            BorderStyle = System.Windows.Forms.BorderStyle.None;
            GridColor = ColorGrid;
            Margin = new System.Windows.Forms.Padding(0);
            MultiSelect = false;
            SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ReadOnly = true;
            TabStop = false;

            //ROWS
            RowTemplate.Height = 30;
            RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;

            //Alternate Rows
            System.Windows.Forms.DataGridViewCellStyle AlternatingRowsStyle = new System.Windows.Forms.DataGridViewCellStyle();
            AlternatingRowsStyle.BackColor = ColorRowAlternate;
            AlternatingRowsDefaultCellStyle = AlternatingRowsStyle;

            //ROWS_HEADERS
            System.Windows.Forms.DataGridViewCellStyle RowHeadersStyle = new System.Windows.Forms.DataGridViewCellStyle();
            RowHeadersStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            RowHeadersStyle.BackColor = ColorRowHeader;
            RowHeadersStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            RowHeadersStyle.ForeColor = System.Drawing.Color.White;
            RowHeadersStyle.SelectionBackColor = ColorRowHeaderSelection;
            RowHeadersStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            RowHeadersStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            RowHeadersDefaultCellStyle = RowHeadersStyle;

            RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            RowHeadersVisible = false;

            //CELLS
            System.Windows.Forms.DataGridViewCellStyle CellStyle = new System.Windows.Forms.DataGridViewCellStyle();
            CellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            CellStyle.BackColor = ColorRow;
            CellStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            CellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            CellStyle.SelectionBackColor = ColorRowSelection;
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

            System.Windows.Forms.DataGridViewCellStyle ColumnHeadersStyle = new System.Windows.Forms.DataGridViewCellStyle();
            ColumnHeadersStyle.BackColor = ColorColumnHeader;
            ColumnHeadersStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ColumnHeadersStyle.ForeColor = System.Drawing.Color.White;
            ColumnHeadersStyle.SelectionBackColor = ColorColumnSelection;
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
