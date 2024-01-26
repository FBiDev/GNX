using System.Collections;
using System.Data;

namespace GNX.Web
{
#pragma warning disable
    public class DatabaseDao
    {
#pragma warning restore
        #region " _Load "
        public static T Load<T>(DataTable table) where T : IList, new()
        {
            return GNX.DatabaseDao.Load<T>(table, typeof(DataRowExtension));
        }
        #endregion
    }
}