using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GNX.Desktop
{
    public static class cDebug
    {
        static List<KeyValuePair<string, int>> Errors = new List<KeyValuePair<string, int>>();
        static string Messages = string.Empty;

        public static ListBind<cLogSQL> LogSQLSistema = new ListBind<cLogSQL>();
        public static ListBind<cLogSQL> LogSQLBase = new ListBind<cLogSQL>();

        public static bool Enable;

        public static DebugForm Open()
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(DebugForm))
                {
                    ((DebugForm)f).WindowState = FormWindowState.Normal;
                    ((DebugForm)f).Focus();
                    return ((DebugForm)f);
                }
            }

            //else
            var output = new DebugForm();
            return output;
        }

        public static List<KeyValuePair<string, int>> GetErrors()
        {
            return Errors;
        }

        public static void AddError(string error)
        {
            error += Environment.NewLine;
            var item = new KeyValuePair<string, int>(error, 1);

            //Update Item
            if (Errors.Any(i => i.Key == error))
            {
                var index = Errors.FindIndex(i => i.Key == error);
                item = new KeyValuePair<string, int>(error, Errors[index].Value + 1);
                Errors[index] = item;
            }
            //Add new Item
            else
            {
                Errors.Insert(0, item);
            }

            var form = Open();
            form.UpdateErrors();
            form.TabSelectIndex(1);

            if (Enable)
                form.Show();
        }

        public static void AddMessage(string text)
        {
            Messages = Messages.Insert(0, text + Environment.NewLine);

            //if Form already open, update
            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(DebugForm))
                {
                    ((DebugForm)f).UpdateMessages();
                }
            }
        }

        public static string GetMessages()
        {
            return Messages;
        }
    }
}