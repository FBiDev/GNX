using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

namespace GNX
{
    public static class ContainersExtension
    {
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

        public static bool RowHeader(this DataGridViewCellEventArgs e)
        {
            return e.RowIndex == -1;
        }
    }
}
