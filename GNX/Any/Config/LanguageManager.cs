﻿using System;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace GNX
{
    public static class LanguageManager
    {
        #region Language
        static CultureInfo Language;
        static RegionInfo Country;

        public static CultureInfo LanguageNumbers;

        public static void SetLanguageNumbers(CultureID name)
        {
            LanguageNumbers = new CultureInfo(Convert.ToInt32(name));
        }

        public static void SetLanguage(CultureID name)
        {
            var CultureName = Convert.ToInt32(name);
            Language = new CultureInfo(CultureName);

            //Change Culture Info Month names.
            Language.DateTimeFormat.MonthNames = Language.DateTimeFormat.MonthNames.Select(m => Language.TextInfo.ToTitleCase(m)).ToArray();
            Language.DateTimeFormat.MonthGenitiveNames = Language.DateTimeFormat.MonthGenitiveNames.Select(m => Language.TextInfo.ToTitleCase(m)).ToArray();
            Language.DateTimeFormat.AbbreviatedMonthNames = Language.DateTimeFormat.AbbreviatedMonthNames.Select(m => Language.TextInfo.ToTitleCase(m)).ToArray();

            Language.DateTimeFormat.DayNames = Language.DateTimeFormat.DayNames.Select(d => Language.TextInfo.ToTitleCase(d)).ToArray();
            Language.DateTimeFormat.DayNames = Language.DateTimeFormat.DayNames.Select(d => d.Replace("-Feira", "")).ToArray();

            //Culture for any thread
            CultureInfo.DefaultThreadCurrentCulture = Language;

            //Culture for UI in any thread
            CultureInfo.DefaultThreadCurrentUICulture = Language;

            Country = new RegionInfo(Thread.CurrentThread.CurrentUICulture.LCID);
        }

        public static string CurrencySymbol
        {
            get { return Language.NumberFormat.CurrencySymbol; }
        }

        public static string CurrencyGroupSeparator
        {
            get { return Language.NumberFormat.CurrencyGroupSeparator; }
        }

        public static string CurrencyDecimalSeparator
        {
            get { return Language.NumberFormat.CurrencyDecimalSeparator; }
        }

        public static string NumberDecimalSeparator
        {
            get { return Language.NumberFormat.NumberDecimalSeparator; }
        }
        #endregion
    }
}