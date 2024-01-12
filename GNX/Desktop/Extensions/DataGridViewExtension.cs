﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GNX.Desktop
{
    public static class DataGridViewExtension
    {
        //Columns
        static void Format(this DataGridViewColumnCollection source, int colIndex, ColumnFormat format)
        {
            DataGridViewColumn col = source[colIndex];

            var style = new DataGridViewCellStyle
            {
                //FormatProvider = LanguageManager.CultureBrazil,
                NullValue = null
            };

            switch (format)
            {
                case ColumnFormat.NotSet:
                    break;
                case ColumnFormat.StringCenter:
                    style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    break;
                case ColumnFormat.Number:
                case ColumnFormat.NumberCenter:
                    if (format == ColumnFormat.Number)
                        style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    else
                        style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    style.Format = "N0";
                    break;
                case ColumnFormat.Date:
                    style.FormatProvider = LanguageManager.CultureBrazil;
                    style.Format = "d";
                    break;
                case ColumnFormat.DateCenter:
                    style.FormatProvider = LanguageManager.CultureBrazil;
                    style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    style.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
                    style.Format = "dd MMM, yyyy";
                    break;
                case ColumnFormat.Image:
                    if (col is DataGridViewImageColumn)
                    {
                        style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        style.Padding = new Padding(2);

                        col.Resizable = DataGridViewTriState.False;
                        col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                        (col as DataGridViewImageColumn).ImageLayout = DataGridViewImageCellLayout.NotSet;
                    }
                    break;
            }

            col.DefaultCellStyle = style;
        }

        public static void Format(this DataGridViewColumnCollection source, ColumnFormat format, params int[] cols)
        {
            foreach (var colIndex in cols)
                Format(source, colIndex, format);
        }

        public static void Format(this DataGridViewColumnCollection source, Dictionary<int, ColumnFormat> formats)
        {
            foreach (var f in formats)
                Format(source, f.Key, f.Value);
        }

        public static void Format(this DataGridViewColumnCollection source, params ColumnFormat[] formats)
        {
            for (var i = 0; i < formats.Count(); i++)
                Format(source, i, formats[i]);
        }

        //Rows
        public static bool IsEmpty(this DataGridViewRowCollection source)
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