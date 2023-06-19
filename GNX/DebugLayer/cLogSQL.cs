using System;
using System.Data;

namespace GNX
{
    public class cLogSQL
    {
        public int Line { get; set; }
        public DateTime Date { get; set; }
        public string Method { get; set; }
        public string Action { get; set; }

        public string CommandParameters { get; set; }
        public string Command { get; set; }

        public cLogSQL(int index, IDbCommand cmd, DbAction act = DbAction.Null, string method = default(string))
        {
            Line = index + 1;
            Date = DateTime.Now;
            Method = method;
            Action = act != DbAction.Null ? act.ToString() : default(string);

            string query = string.Empty;
            if (cmd.NotNull())
            {
                CommandParameters = cmd.CommandText;
                query = cmd.CommandText;

                query = cSqlParameter.Replace(query, cmd.Parameters);
            }

            //query = query.Replace("  ", "\t ");
            //query = query.Replace("\t", "\t ");
            //query = query.RemoveWhiteSpaces();

            Command = query;
        }
    }
}