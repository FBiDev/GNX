﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace GNX
{
    public static class DateTimeExtension
    {
        public static string ToString(this DateTime? dt, string format)
        {
            return dt == null ? null : ((DateTime)dt).ToString(format);
        }

        public static string ToDMY(this DateTime dt)
        {
            return dt.ToString("dd/MM/yyyy");
        }

        public static string ToDMY_TimeShort(this DateTime dt)
        {
            return dt.ToString("dd/MM/yyyy HH:mm");
        }

        public static string ToDMY_TimeLong(this DateTime dt)
        {
            return dt.ToString("dd/MM/yyyy HH:mm:ss");
        }

        public static string ToTimeLong(this DateTime dt)
        {
            return dt.ToString("HH:mm:ss");
        }

        public static string ToDB(this DateTime? dt)
        {
            if (dt != null && dt.HasValue)
            {
                return "'" + dt.Value.ToString("yyyy-MM-dd HH:mm:ss") + "'";
            }
            return "NULL";
        }

        public static float ElapsedSeconds(this Stopwatch sw)
        {
            return Convert.ToSingle(((float)sw.ElapsedMilliseconds / 1000).ToString("N2"));
        }
    }
}
