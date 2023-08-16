using System.Web.UI.WebControls;

namespace GNX.Web
{
    public static class GridViewExtension
    {
        public static bool HasRows(this GridView grd)
        {
            return grd.Rows.Count > 0;
        }
    }
}