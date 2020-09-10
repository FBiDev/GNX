﻿using System;
using System.Collections.Generic;
using System.Data;
//

namespace GNX
{
    public class cLog
    {
        public int Line { get; set; }
        public DateTime Date { get; set; }
        public string Method { get; set; }
        public string Movement { get; set; }

        public string Command { get; set; }

        public cLog(IDbCommand cmd, DbMovement Mov = DbMovement.Null, string Method = default(string))
        {
            Line = cDataBase.Log.Count;
            Date = DateTime.Now;
            this.Method = Method;
            Movement = Mov != DbMovement.Null ? Mov.ToString() : default(string);

            string query = cmd.CommandText;

            foreach (IDbDataParameter p in cmd.Parameters)
            {
                string val = p.Value == null ? "NULL" : p.Value.ToString();
                query = query.Replace(p.ParameterName, val);
            }

            Command = query;
        }
    }
}
