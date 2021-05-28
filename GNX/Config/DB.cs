using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace GNX
{
    public class DB
    {
        private static cDataBase database { get; set; }

        public static void Load(string serverAddress, string databaseName)
        {
            database = new cDataBase
            {
                DatabaseSystem = DbSystem.SQLServer,
                Connection = new SqlConnection(),
                ServerAddress = serverAddress,
                DatabaseName = databaseName,
                DataBaseFile = "",
                Username = "",
                Password = "",
                ConnectionString = ""
            };
        }

        public static DataTable ExecuteSelect(string sql, List<cSqlParameter> parameters = null)
        {
            return database.ExecuteSelect(sql, parameters);
        }

        public static cSqlResult Execute(string sql, List<cSqlParameter> parameters, DbAction action)
        {
            return database.Execute(sql, parameters, action);
        }

        public static int GetLastID() { return database.GetLastID(); }
        public static DateTime DataServidor() { return database.DataServidor(); }
    }
}