using System;

namespace GNX.Web
{
    public static class ExceptionManager
    {
        public static string Resolve(Exception ex)
        {
            var exProc = GNX.ExceptionManager.Process(ex);

            return exProc.Message;
        }
    }
}