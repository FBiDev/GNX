using System;
using System.Collections.Generic;
using System.Linq;

namespace GNX
{
    public static class IntExtension
    {
        public static string ToDBFormat(this int? value)
        {
            if (value == null)
            {
                return "null";
            }
            return value.ToString();
        }
    }
}
