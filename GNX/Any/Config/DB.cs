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
        public static ListSynced<cLogSQL> Log { get { return Database.Log; } }
        public static bool Loaded { get; set; }

        public static void Load(string server, string database)
        {
            Database = new DataBaseManager { };
            Reload(server, database);
            Loaded = true;
        }

        public static void Reload(string server, string database)
        {
            Database.DatabaseSystem = DbSystem.SQLServer;
            Database.Connection = new SqlConnection();
            Database.ServerAddress = server;
            Database.DatabaseName = database;
            Database.DataBaseFile = "";
            Database.Username = "";
            Database.Password = "";
            Database.ConnectionString = "";
        }

        public async static Task<DataTable> ExecuteSelect(string sql, List<cSqlParameter> parameters = null, string storedProcedure = default(string))
        {
            if (Loaded) { return await Database.ExecuteSelect(sql, parameters, storedProcedure); }
            return new DataTable();
        }

        public async static Task<cSqlResult> Execute(string sql, DbAction action, List<cSqlParameter> parameters)
        {
            if (Loaded) { return await Database.Execute(sql, action, parameters); }
            return new cSqlResult();
        }

        public async static Task<int> GetLastID()
        {
            if (Loaded) { return await Database.GetLastID(); }
            return 0;
        }

        public async static Task<DateTime> DataServidor()
        {
            if (Loaded) { return await Database.DateTimeServer(); }
            return DateTime.MinValue;
        }
    }
}