using System;
using System.Collections.Generic;
using System.Globalization;
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

        public static string ToNumber(this float value, int decimals = 2, bool customLanguage = false)
        {
            return string.Format(customLanguage ? cApp.LanguageNumbers : CultureInfo.CurrentCulture, "{0:N" + decimals + "}", value);
        }

        public static string ToNumber(this int? value, bool customLanguage = false)
        {
            return ToNumber((float)value, 0, customLanguage);
        }

        public static string ToNumber(this int value, bool customLanguage = false)
        {
            return ToNumber((float)value, 0, customLanguage);
        }
    }
}
