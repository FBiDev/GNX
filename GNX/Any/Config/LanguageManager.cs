using System;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace GNX
{
    public static class LanguageManager
    {
        #region Language
        public static CultureInfo CultureBrazil = SetLanguageNames(CultureID.Brazil_Portuguese);
        public static CultureInfo CultureUSA = SetLanguageNames(CultureID.UnitedStates_English);

        static CultureInfo Language = SetLanguageNames(CultureID.UnitedStates_English);
        static RegionInfo Country;

        public static CultureInfo LanguageNumbers;

        public static bool LanguageIsUSA()
        {
            return Language.LCID == (int)CultureID.UnitedStates_English;
        }

        public static CultureInfo GetLanguage() { return Language; }

        public static void SetLanguage(CultureID cultureID)
        {
            var CultureName = Convert.ToInt32(cultureID);
            Language = new CultureInfo(CultureName);

            SetLanguageNames(Language);

            //Culture for any thread
            CultureInfo.DefaultThreadCurrentCulture = Language;

            //Culture for UI in any thread
            CultureInfo.DefaultThreadCurrentUICulture = Language;

            Country = new RegionInfo(Thread.CurrentThread.CurrentUICulture.LCID);
        }

        public static void SetLanguageNumbers(CultureID name)
        {
            LanguageNumbers = new CultureInfo(Convert.ToInt32(name));
        }

        public static CultureInfo SetLanguageNames(CultureID cultureID)
        {
            var cultureName = Convert.ToInt32(cultureID);
            var language = new CultureInfo(cultureName);
            SetLanguageNames(language);

            return language;
        }

        public static void SetLanguageNames(CultureInfo culture)
        {
            //Change Culture Info Month names.
            culture.DateTimeFormat.MonthNames = culture.DateTimeFormat.MonthNames.Select(m => culture.TextInfo.ToTitleCase(m)).ToArray();
            culture.DateTimeFormat.MonthGenitiveNames = culture.DateTimeFormat.MonthGenitiveNames.Select(m => culture.TextInfo.ToTitleCase(m)).ToArray();
            culture.DateTimeFormat.AbbreviatedMonthNames = culture.DateTimeFormat.AbbreviatedMonthNames.Select(m => culture.TextInfo.ToTitleCase(m)).ToArray();

            culture.DateTimeFormat.DayNames = culture.DateTimeFormat.DayNames.Select(d => culture.TextInfo.ToTitleCase(d)).ToArray();

            if (culture.LCID == (int)CultureID.Brazil_Portuguese)
            {
                culture.DateTimeFormat.DayNames = culture.DateTimeFormat.DayNames.Select(d => d.Replace("-Feira", "")).ToArray();
            }
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