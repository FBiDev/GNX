using System.Web;

namespace GNX.Web
{
    public static class StringExtensionWeb
    {
        public static string HtmlDecode(this string s)
        {
            return HttpUtility.HtmlDecode(s);
        }
    }
}