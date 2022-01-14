using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace GNX
{
    public class DB
    {
        public static ListBind<cLogSQL> Log { get { return Database.Log; } set { Database.Log = value; } }
        private static cDataBase Database { get; set; }
        public static bool ConfigLoaded { get; set; }

        public static void Load(string server, string database)
        {
            Database = new cDataBase
            {
                DatabaseSystem = DbSystem.SQLServer,
                Connection = new SqlConnection(),
                ServerAddress = server,
                DatabaseName = database,
                DataBaseFile = "",
                Username = "",
                Password = "",
                ConnectionString = ""
            };
        }

        public static DataTable ExecuteSelect(string sql, List<cSqlParameter> parameters = null)
        {
            if (ConfigLoaded) { return Database.ExecuteSelect(sql, parameters); }
            return new DataTable();
        }

        public static cSqlResult Execute(string sql, DbAction action, List<cSqlParameter> parameters)
        {
            if (ConfigLoaded) { return Database.Execute(sql, action, parameters); }
            return new cSqlResult();
        }

        public static int GetLastID()
        {
            if (ConfigLoaded) { return Database.GetLastID(); }
            return 0;
        }

        public static DateTime DataServidor()
        {
            if (ConfigLoaded) { return Database.DateTimeServer(); }
            return DateTime.MinValue;
        }
    }
}