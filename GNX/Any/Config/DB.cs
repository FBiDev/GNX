using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace GNX
{
    public static class DB
    {
        static DataBaseManager Database { get; set; }
        public static List<cLogSQL> Log { get { return Database.Log; } set { Database.Log = value; } }
        public static bool ConfigLoaded { get; set; }

        public static void Load(string server, string database)
        {
            Database = new DataBaseManager
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

        public async static Task<DataTable> ExecuteSelect(string sql, List<cSqlParameter> parameters = null)
        {
            if (ConfigLoaded) { return await Database.ExecuteSelect(sql, parameters); }
            return new DataTable();
        }

        public async static Task<cSqlResult> Execute(string sql, DbAction action, List<cSqlParameter> parameters)
        {
            if (ConfigLoaded) { return await Database.Execute(sql, action, parameters); }
            return new cSqlResult();
        }

        public async static Task<int> GetLastID()
        {
            if (ConfigLoaded) { return await Database.GetLastID(); }
            return 0;
        }

        public async static Task<DateTime> DataServidor()
        {
            if (ConfigLoaded) { return await Database.DateTimeServer(); }
            return DateTime.MinValue;
        }
    }
}