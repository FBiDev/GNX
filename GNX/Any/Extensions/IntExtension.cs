using System.Globalization;

namespace GNX
{
    public static class IntExtension
    {
        public static string ToDB(this int? value)
        {
            if (value.HasValue)
                return value.ToString();
            return "NULL";
        }

        public static bool ToBool(this int value)
        {
            return Cast.ToBoolean(value.ToString());
        }

        public static string ToCurrency(this decimal d)
        {
            return Cast.ToCurrency(d.ToString());
        }

        public static string ToNumber(this decimal value, int decimals = 2, bool customLanguage = false)
        {
            return string.Format(customLanguage ? LanguageManager.LanguageNumbers : CultureInfo.CurrentCulture, "{0:N" + decimals + "}", value);
        }

        public static string ToNumber(this int? value, bool customLanguage = false)
        {
            return ToNumber((decimal)value, 0, customLanguage);
        }

        public static string ToNumber(this int value, bool customLanguage = false)
        {
            return ToNumber(value, 0, customLanguage);
        }

        public static string ToNumber(this float value, bool customLanguage = false)
        {
            return ToNumber((decimal)value, 0, customLanguage);
        }
    }
}