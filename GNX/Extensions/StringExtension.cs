﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Web;

namespace GNX
{
    public static class StringExtension
    {
        public static string NormalizePath(this string s)
        {
            return s.Replace('\\', '/');
        }

        public static string RemoveWhiteSpaces(this string s)
        {
            return string.Join(" ", s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
        }

        public static string HtmlDecode(this string s)
        {
            return HttpUtility.HtmlDecode(s);
        }

        public static string HtmlRemoveTags(this string s)
        {
            return Regex.Replace(s, @"<[^>]+>|", "").Trim();
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

        public static decimal ToDecimal(this string s)
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

        public static bool IsEmpty(this string source)
        {
            return source == null || string.IsNullOrWhiteSpace(source);
        }

        public static bool HasValue(this string source)
        {
            return source.IsEmpty() == false;
        }

        public static bool Contains(this string[] source, string toCheck, StringComparison comp)
        {
            if (source == null) return false;
            foreach (var item in source)
            {
                if (item.IndexOf(toCheck, comp) >= 0) return true;
            }
            return false;
        }

        public static bool ContainsExtend(this string source, string value)
        {
            string[] IgnoreSymbols = { ", The:", ",", ":", "'", "-", ".", "+", "/", " " };
            foreach (string symbol in IgnoreSymbols)
            {
                source = source.Replace(symbol, "");
                value = value.Replace(symbol, "");
            }

            var index = CultureInfo.InvariantCulture.CompareInfo.IndexOf(
                source, value, CompareOptions.IgnoreCase | CompareOptions.IgnoreNonSpace);
            //| CompareOptions.IgnoreSymbols

            return index != -1;
        }

        public static bool NotContains(this string source, string value)
        {
            return source.ContainsExtend(value) == false;
        }

        public static bool NotContains(this string source, string[] valueArray)
        {
            foreach (var value in valueArray)
            {
                if (source.ContainsExtend(value)) { return false; }
            }
            return true;
        }

        public static string GetBetween(this string s, string start, string end, bool inclusive = false, bool firstMatch = true, bool singleLine = true)
        {
            string first = firstMatch ? "?" : "";

            string pattern = @"" + Regex.Escape(start) + "(.*" + first + ")" + Regex.Escape(end);
            RegexOptions opt = singleLine ? RegexOptions.Singleline : 0;
            var rgx = new Regex(pattern, opt | RegexOptions.IgnoreCase);

            var match = rgx.Match(s);
            if (match.Success)
            {
                return match.Groups[inclusive ? 0 : 1].Value;
            }
            return string.Empty;
        }

        public static List<string> GetBetweenList(this string s, string start, string end, bool inclusive = false, bool firstMatch = true, bool singleLine = true)
        {
            string first = firstMatch ? "?" : "";

            string pattern = @"" + Regex.Escape(start) + "(.*" + first + ")" + Regex.Escape(end);
            RegexOptions opt = singleLine ? RegexOptions.Singleline : 0;
            var rgx = new Regex(pattern, opt | RegexOptions.IgnoreCase);

            var matchList = rgx.Matches(s);
            var list = matchList.Cast<Match>().Select(match => match.Groups[inclusive ? 0 : 1].Value).ToList();
            return list;
        }
    }
}