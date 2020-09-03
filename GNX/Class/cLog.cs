using System;
using System.Collections.Generic;
using System.Data;
//

namespace GNX
{
    public class cLog
    {
        public int Line { get; set; }
        public string Command { get; set; }

        public cLog(IDbCommand cmd)
        {
            string query = cmd.CommandText;

            foreach (IDbDataParameter p in cmd.Parameters)
            {
                query = query.Replace(p.ParameterName, p.Value.ToString());
            }

            Command = query;

            Line = cDataBase.Log.Count;
        }
    }
}
