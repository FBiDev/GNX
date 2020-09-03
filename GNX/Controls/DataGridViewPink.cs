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

        public DataGridViewPink()
        {
            InitializeComponent();

            //MAIN
            Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));

            CausesValidation = false;

            AllowUserToAddRows = false;
            AllowUserToDeleteRows = false;

            BackgroundColor = System.Drawing.Color.White;
            BorderStyle = System.Windows.Forms.BorderStyle.None;
            GridColor = System.Drawing.Color.Silver;
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
            AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            AlternatingRowsDefaultCellStyle = AlternatingRowsStyle;

            //ROWS_HEADERS
            System.Windows.Forms.DataGridViewCellStyle RowHeadersStyle = new System.Windows.Forms.DataGridViewCellStyle();
            RowHeadersStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            RowHeadersStyle.BackColor = System.Drawing.Color.White;
            RowHeadersStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            RowHeadersStyle.ForeColor = System.Drawing.Color.White;
            RowHeadersStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            RowHeadersStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            RowHeadersStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            RowHeadersDefaultCellStyle = RowHeadersStyle;

            RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            RowHeadersVisible = false;

            //CELLS
            System.Windows.Forms.DataGridViewCellStyle CellStyle = new System.Windows.Forms.DataGridViewCellStyle();
            CellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            CellStyle.BackColor = System.Drawing.Color.White;
            CellStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            CellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            CellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(226)))), ((int)(((byte)(244)))));
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
            ColumnHeadersStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(122)))), ((int)(((byte)(224)))));
            ColumnHeadersStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ColumnHeadersStyle.ForeColor = System.Drawing.Color.White;
            ColumnHeadersStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            ColumnHeadersStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            ColumnHeadersStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            ColumnHeadersDefaultCellStyle = ColumnHeadersStyle;

            //
            ColumnHeaderMouseClick += dgv_ColumnHeaderMouseClick;
            Sorted += dgv_OnSorted;
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

        public void RefreshForeColor(string ColumnName, bool Value, string CellValue)
        {
            foreach (DataGridViewRow Row in this.Rows)
            {
                if (Row.Cells[ColumnName].Value.ToString() == CellValue)
                {
                    ChangeForeColor(Value, Row.Cells[ColumnName]);
                }
            }
        }

        public void RefreshBooleanImage(string ColumnName, bool Value, string CellValue, string BooleanColumn)
        {
            foreach (DataGridViewRow Row in this.Rows)
            {
                if (Row.Cells[ColumnName].Value.ToString() == CellValue)
                {
                    Row.Cells[BooleanColumn + "Bol"].Value = (Value == true) ? Properties.Resources.img_true_ico : Properties.Resources.img_false_ico;
                }
            }
        }

        public void ChangeForeColor(bool Value, DataGridViewCell Cell)
        {
            if (!Value)
            {
                Cell.Style.SelectionForeColor = Color.Red;
                Cell.Style.ForeColor = Color.Red;
            }
            else
            {
                Cell.Style.SelectionForeColor = this.DefaultCellStyle.SelectionForeColor;
                Cell.Style.ForeColor = this.DefaultCellStyle.ForeColor;
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
