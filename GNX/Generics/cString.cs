using System;
using System.Collections.Generic;
using System.Linq;
//
using System.Text.RegularExpressions;

namespace GNX
{
    public static class cString
    {
        public static string GetBetween(string start, string end, string text, bool singleLine = true, bool inclusive = false)
        {
            RegexOptions opt = 0;
            if (singleLine) { opt = RegexOptions.Singleline; }
            Regex rg = new Regex(@"" + start + "(.*?)" + end + "", opt | RegexOptions.IgnoreCase);

            Match match = rg.Match(text);
            if (match.Success)
            {
                if (inclusive) { return match.Groups[0].Value; }

                return match.Groups[1].Value;
            }
            return string.Empty;
        }
    }
}
