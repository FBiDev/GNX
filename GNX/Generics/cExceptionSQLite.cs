using System;
using System.Windows.Forms;
//

namespace GNX
{
    public class cExceptionSQLite
    {
        public static bool ShowBox(Exception ex, string ArgumentString = null)
        {
            //string CustomMessage = "";
            //string errorLineBreak = "\r\n\r\n";

            //Exception Error = ex;
            //Type ExType = ex.GetType();

            //if (ExType == typeof(SQLiteException))
            //{
            //    Error = ((SQLiteException)ex);

            //    if (Error.TargetSite.Module.Name == "System.Data.SQLite.dll")
            //    {
            //        //SQL Syntax
            //        if (Error.TargetSite.Name == "Prepare")
            //        {
            //            CustomMessage = "Sintaxe do SQL errada:\r\n" + ArgumentString;
            //        }
            //    }

            //    MessageBox.Show(CustomMessage + errorLineBreak + Error.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return true;
            //}
            return false;
        }
    }
}
