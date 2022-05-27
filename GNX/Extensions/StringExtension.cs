using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web;

namespace GNX
{
    public static class StringExtension
    {
        public static string RemoveWhiteSpaces(this string s)
        {
            return string.Join(" ", s.Split(new char[] { ' ' },
                   StringSplitOptions.RemoveEmptyEntries));
        }

        public static string HtmlDecode(this string s)
        {
            return HttpUtility.HtmlDecode(s);
        }

        public static string HtmlRemoveTags(this string s)
        {
            return Regex.Replace(s, @"<[^>]+>|", "").Trim(); ;
        }

        public static short? ToShortNull(this string s)
        {
            return cConvert.ToShortNull(s);
        }

        public static float ToFloat(this string s)
        {
            return cConvert.ToFloat(s);
        }

        public static TimeSpan? ToTimeSpanNull(this string s)
        {
            return cConvert.ToTimeSpanNull(s);
        }

        public static DateTime? ToDateTimeNull(this string s)
        {
            return cConvert.ToDateTimeNull(s);
        }

        public static Decimal ToDecimal(this string s)
        {
            return cConvert.ToDecimal(s);
        }

        public static string ToCurrency(this string s)
        {
            return cConvert.ToCurrency(s);
        }

        public static bool ToBoolean(this string s)
        {
            return cConvert.ToBoolean(s);
        }

        public static int ToInt(this string s)
        {
            return cConvert.ToInt(s);
        }

        public static string GetBetween(this string s, string start, string end, bool inclusive = false, bool firstMatch = true, bool singleLine = true)
        {
            RegexOptions opt = 0;
            string first = "?";

            if (singleLine) { opt = RegexOptions.Singleline; }
            if (firstMatch) { first = ""; }

            Regex rg = new Regex(@"" + Regex.Escape(start) + "(.*" + first + ")" + Regex.Escape(end) + "", opt | RegexOptions.IgnoreCase);

            Match match = rg.Match(s);
            if (match.Success)
            {
                if (inclusive) { return match.Groups[0].Value; }

                return match.Groups[1].Value;
            }
            return string.Empty;
        }
    }
}
