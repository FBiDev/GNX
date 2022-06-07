using System;
using System.Collections.Generic;
using System.Linq;

namespace GNX
{
    public static class IntExtension
    {
        public static string ToDB(this int? value)
        {
            if (value.HasValue)
            {
                return value.ToString();
            }
            return "NULL";
        }
    }
}
