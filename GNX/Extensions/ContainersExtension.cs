using System;
using System.Collections.Generic;
using System.Linq;
//
using System.Windows.Forms;

namespace GNX
{
    public static class ContainersExtension
    {
        //Columns
        public static void StyleCenter(this DataGridViewColumnCollection source, params int[] cols)
        {
            var style = new DataGridViewCellStyle()
            {
                Alignment = DataGridViewContentAlignment.MiddleCenter
            };

            foreach (var c in cols)
                source[c].DefaultCellStyle = style;
        }

        public static void StyleNumber(this DataGridViewColumnCollection source, params int[] cols)
        {
            var style = new DataGridViewCellStyle()
            {
                Alignment = DataGridViewContentAlignment.MiddleRight,
                Format = "N0",
                NullValue = null
            };

            foreach (var c in cols)
            {
                //source[c].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                source[c].DefaultCellStyle = style;
            }
        }

        public static void StyleNumberCenter(this DataGridViewColumnCollection source, params int[] cols)
        {
            foreach (var c in cols)
            {
                StyleNumber(source, c);
                StyleCenter(source, c);
            }
        }

        public static void StyleImage(this DataGridViewColumnCollection source, params int[] cols)
        {
            var style = new DataGridViewCellStyle()
            {
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                Padding = new System.Windows.Forms.Padding(2)
            };

            foreach (var c in cols)
            {
                if (source[c] is DataGridViewImageColumn)
                {
                    source[c].DefaultCellStyle = style;
                    source[c].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    ((DataGridViewImageColumn)source[c]).ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
                }
            }
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
