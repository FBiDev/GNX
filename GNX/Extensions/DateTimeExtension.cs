using System;
using System.Collections.Generic;
using System.Linq;

namespace GNX
{
    public static class DateTimeExtension
    {
        public static string ToString(this DateTime? dt, string format)
        {
            return dt == null ? null : ((DateTime)dt).ToString(format);
        }

        public static string ToDB(this DateTime? dt)
        {
            if (dt != null && dt.HasValue)
            {
                return "'" + dt.Value.ToString("yyyy-MM-dd HH:mm:ss") + "'";
            }
            return "NULL";
        }
    }
}
