using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace GNX.Desktop
{
    public static class DB
    {
        static DatabaseManager Database { get; set; }
        public static ListSynced<cLogSQL> Log { get { return Database.Log; } }
        public static bool Loaded { get; set; }

        public static void Load(string server, string database)
        {
            Database = new DatabaseManager { };
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
            if (Loaded)
            {
                try { return await Database.ExecuteSelect(sql, parameters, storedProcedure); }
                catch (Exception ex) { ExceptionManager.Resolve(ex, Database.LastCall); }
            }
            return new DataTable();
        }

        public async static Task<string> ExecuteSelectString(string sql, List<cSqlParameter> parameters = null)
        {
            if (Loaded)
            {
                try { return await Database.ExecuteSelectString(sql, parameters); }
                catch (Exception ex) { ExceptionManager.Resolve(ex, Database.LastCall); }
            }
            return string.Empty;
        }

        public async static Task<cSqlResult> Execute(string sql, DbAction action, List<cSqlParameter> parameters)
        {
            if (Loaded)
            {
                try { return await Database.Execute(sql, action, parameters); }
                catch (Exception ex) { ExceptionManager.Resolve(ex, Database.LastCall); }
            }
            return new cSqlResult();
        }

        public async static Task<DateTime> DateTimeServer()
        {
            if (Loaded)
            {
                try { return await Database.DateTimeServer(); }
                catch (Exception ex) { ExceptionManager.Resolve(ex, Database.LastCall); }
            }
            return DateTime.MinValue;
        }
    }
}