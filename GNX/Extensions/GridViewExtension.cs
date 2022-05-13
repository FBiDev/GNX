using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace GNX
{
    public static class GridViewExtension
    {
        public static bool HasRows(this GridView grd)
        {
            return grd.Rows.Count > 0;
        }
    }
}
