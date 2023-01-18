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

        public static string ToNumber(this float value, bool languageNumber = false, int decimals = 2)
        {
            if (languageNumber)
                return string.Format(cApp.LanguageNumbers, "{0:N" + decimals + "}", value);
            else
                return string.Format("{0:N" + decimals + "}", value);
        }

        public static string ToNumber(this int? value, bool languageNumber = false)
        {
            return ToNumber((float)value, languageNumber, 0);
        }

        public static string ToNumber(this int value, bool languageNumber = false)
        {
            return ToNumber((float)value, languageNumber, 0);
        }
    }
}
