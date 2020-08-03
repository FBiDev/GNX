using System;
using System.Globalization;
using System.Windows.Forms;
//

namespace GNX
{
    public class cApp
    {
        private static CultureInfo Language;
        private static RegionInfo Country;

        public static void SetLanguage(CultureID name)
        {
            int CultureName = Convert.ToInt32(name);
            Language = CultureInfo.GetCultureInfo(CultureName);

            //Culture for any thread
            CultureInfo.DefaultThreadCurrentCulture = Language;

            //Culture for UI in any thread
            CultureInfo.DefaultThreadCurrentUICulture = Language;

            Country = new RegionInfo(System.Threading.Thread.CurrentThread.CurrentUICulture.LCID);
        }

        public static string CurrencySymbol
        {
            get { return Language.NumberFormat.CurrencySymbol; }
        }

        public static string CurrencyDecimalSeparator
        {
            get { return Language.NumberFormat.CurrencyDecimalSeparator; }
        }

        public static string CurrencyGroupSeparator
        {
            get { return Language.NumberFormat.CurrencyGroupSeparator; }
        }

        public static void Exit()
        {
            Application.Exit();
        }
    }
}
