using System.Text;
using System.Web.UI.WebControls;

namespace System
{
    public static class EnumExtension
    {
        public static string ToSQL(this SortDirection s)
        {
            return s == SortDirection.Ascending ? " ASC " : " DESC ";
        }

        public static string ToStringHex(this Enum e)
        {
            var value = ((int)(object)e).ToString("X");
            var data = FromHex(value);
            var s = Encoding.UTF8.GetString(data);
            return s;
        }

        static byte[] FromHex(string hex)
        {
            hex = hex.Replace("-", "");
            byte[] raw = new byte[hex.Length / 2];

            for (int i = 0; i < raw.Length; i++)
            {
                raw[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
            }
            return raw;
        }
    }
}