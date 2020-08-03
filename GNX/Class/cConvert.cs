using System;
//

namespace GNX
{
    public class cConvert
    {
        public static decimal ToDecimal(string value)
        {
            decimal result = 0;
            if (value != string.Empty)
            {
                string cs = cApp.CurrencySymbol;
                string gs = cApp.CurrencyGroupSeparator;
                value = value.ToString().Replace(cs, "").Replace(gs, "").Trim();
                decimal.TryParse(value, out result);
                //result = Convert.ToDecimal(value);
            }
            return result;
        }

        public static string ToCurrency(string value)
        {
            decimal result = 0;
            if (value != string.Empty)
            {   
                if (decimal.TryParse(value, out result))
                {
                    //result = Convert.ToDecimal(value);
                    value = String.Format("{0:C2}", result);
                }
            }
            return value;
        }
    }
}
