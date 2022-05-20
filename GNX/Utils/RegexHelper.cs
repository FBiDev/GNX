using System;
using System.Collections.Generic;
using System.Linq;
//
using System.Text.RegularExpressions;

namespace GNX
{
    public static class RegexHelper
    {
        public static string Between(string start, string end, string text, bool singleLine = true)
        {
            RegexOptions opt = 0;
            if (singleLine) { opt = RegexOptions.Singleline; }
            Regex rg = new Regex(@"" + start + "(.*)" + end + "", opt);

            Match match = rg.Match(text);
            if (match.Success)
            {
                return match.Groups[1].Value;
            }
            return string.Empty;
        }
    }
}
