using System;
using System.Collections.Generic;
using System.Linq;
//
using System.Windows.Forms;

namespace GNX
{
    public enum CellStyle
    {
        NotSet,
        StringCenter,
        Number,
        NumberCenter,
        DateCenter,
        Image
    }

    public static class ContainersExtension
    {
        //Columns
        private static void Format(this DataGridViewColumnCollection source, int colIndex, CellStyle format)
        {
            var style = new DataGridViewCellStyle() { };
            DataGridViewColumn col = source[colIndex];

            switch (format)
            {
                case CellStyle.NotSet:
                    break;
                case CellStyle.StringCenter:
                    style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    break;
                case CellStyle.Number:
                case CellStyle.NumberCenter:
                    if (format == CellStyle.Number)
                        style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    else
                        style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    style.Format = "N0";
                    style.NullValue = null;
                    break;
                case CellStyle.DateCenter:
                    style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
                    style.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    style.Format = "dd MMM, yyyy";
                    style.NullValue = null;
                    break;
                case CellStyle.Image:
                    if (col is DataGridViewImageColumn)
                    {
                        style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        style.Padding = new System.Windows.Forms.Padding(2);

                        col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                        ((DataGridViewImageColumn)col).ImageLayout = DataGridViewImageCellLayout.Zoom;
                    }
                    break;
                default:
                    break;
            }

            col.DefaultCellStyle = style;
        }

        public static void Format(this DataGridViewColumnCollection source, CellStyle format, params int[] cols)
        {
            foreach (var colIndex in cols)
                Format(source, colIndex, format);
        }

        public static void Format(this DataGridViewColumnCollection source, Dictionary<int, CellStyle> formats)
        {
            foreach (var f in formats)
                Format(source, f.Key, f.Value);
        }

        public static void Format(this DataGridViewColumnCollection source, params CellStyle[] formats)
        {
            for (var i = 0; i < formats.Count(); i++)
                Format(source, i, formats[i]);
        }

        //Rows
        public static bool Empty(this DataGridViewRowCollection source)
        {
            return source.Count == 0;
        }

        public static bool AnyRow(this DataGridViewRowCollection source)
        {
            return source.Count > 0;
        }

        public static bool AnyRow(this DataGridViewSelectedRowCollection source)
        {
            return source.Count > 0;
        }

        //Cells
        public static bool RowHeader(this DataGridViewCellEventArgs e)
        {
            return e.RowIndex == -1;
        }

        public static bool RowHeader(this DataGridViewCellPaintingEventArgs e)
        {
            return e.RowIndex == -1;
        }
    }
}
