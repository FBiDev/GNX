using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace GNX
{
    public static class EnumExtension
    {
        public static string ToSQL(this SortDirection s)
        {
            return s == SortDirection.Ascending ? " ASC " : " DESC ";
        }
    }
}
