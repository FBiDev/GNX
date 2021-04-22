using System;
using System.Collections;
using System.Collections.Generic;
//
using System.Data;

namespace GNX
{
    public class cDataBase
    {
        public static SortableBindingList<cLog> Log = new SortableBindingList<cLog>();

        private static string error = String.Empty;

        protected static DbSystem DatabaseSystem;
        protected static IDbConnection Connection;

        protected static string ServerAddress { get; set; }
        protected static string DatabaseName { get; set; }
        protected static string DataBaseFile { get; set; }

        protected static string Username { get; set; }
        protected static string Password { get; set; }

        protected static string ConnectionString { get; set; }

        private static IDbCommand cmd { get; set; }
        private static IDbConnection conn { get; set; }

        protected static string DefaultConnectionString()
        {
            switch (DatabaseSystem)
            {
                case DbSystem.SQLServer: return "User ID=" + Username + ";Password=" + Password + ";Data Source=" + ServerAddress + ";Initial Catalog=" + DatabaseName + ";Persist Security Info=False;Packet Size=4096";
                case DbSystem.SQLite: return "Data Source=" + DataBaseFile + ";Version=3;";
                case DbSystem.SQLiteODBC: return "Driver = SQLite3 ODBC Driver; Datasource = " + DataBaseFile + ";Version = 3;New=True;Compress=True;";
            }
            return null;
        }

        public static string GetError()
        {
            string newError = error;
            error = string.Empty;
            return newError;
        }

        public static int GetLastID()
        {
            string aSQL = string.Empty;
            if (DatabaseSystem == DbSystem.SQLite || DatabaseSystem == DbSystem.SQLiteODBC)
            {
                aSQL = "SELECT LAST_INSERT_ROWID();";
            }

            SetCommand();

            string select = ExecuteScalar(aSQL);
            return Convert.ToInt32(0 + select);
        }

        private static IDbConnection CreateConnection()
        {
            conn = Connection;
            if (string.IsNullOrEmpty(ConnectionString))
            {
                conn.ConnectionString = DefaultConnectionString();
            }
            else
            {
                conn.ConnectionString = ConnectionString;
            }

            return conn;
        }

        private static void OpenConnection()
        {
            if (conn.State == ConnectionState.Closed)
            {
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    GNX.cException.ShowBox(ex);
                }
            }
        }

        public static IDbDataParameter AddSQLParameter(string ParameterName, DbType DbType, object Value, int Size = 0, byte Precision = 0, byte Scale = 0)
        {
            if (cmd != null)
            {
                IDbDataParameter p = cmd.CreateParameter();
                p.ParameterName = ParameterName;
                p.DbType = DbType;
                p.Value = Value;
                p.Size = Size;
                p.Precision = Precision;
                p.Scale = Scale;
                cmd.Parameters.Add(p);

                return p;
            }

            return null;
        }

        public static IDbDataParameter AddSQLParameter(cSqlParameter Param)
        {
            if (cmd != null)
            {
                IDbDataParameter p = cmd.CreateParameter();
                p.ParameterName = Param.ParameterName;
                p.DbType = Param.DbType;
                p.Value = Param.Value;
                p.Size = Param.Size;
                p.Precision = Param.Precision;
                p.Scale = Param.Scale;
                cmd.Parameters.Add(p);

                return p;
            }

            return null;
        }

        public static void Open()
        {
            SetCommand();
        }

        private static void SetCommand()
        {
            try
            {
                if (conn == null)
                {
                    conn = CreateConnection();
                }

                OpenConnection();

                cmd = conn.CreateCommand();
                cmd.Connection = conn;
            }
            catch (Exception ex)
            {
                GNX.cException.ShowBox(ex);
            }
        }

        public static void Close()
        {
            if (cmd != null && cmd.Connection != null && cmd.Connection.State == ConnectionState.Open)
            {
                cmd.Connection.Close();
                cmd.Parameters.Clear();
                conn.Close();
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2100:Review SQL queries for security vulnerabilities")]
        public static DataTable ExecuteReader(string aSQL)
        {
            DataTable data = new DataTable();
            DataSet ds = new DataSet();

            if (cmd != null && cmd.Connection != null && cmd.Connection.State == ConnectionState.Open)
            {
                try
                {
                    cmd.CommandText = aSQL;

                    if (cmd.Parameters.Count > 0)
                    {
                        cmd.Prepare();
                    }

                    Log.Add(new cLog(cmd, DbAction.Select, cObject.GetDaoClassAndMethod()));

                    using (IDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        DataTable schemaTabela = rdr.GetSchemaTable();

                        foreach (DataRow dataRow in schemaTabela.Rows)
                        {
                            DataColumn dataColumn = new DataColumn();
                            dataColumn.ColumnName = dataRow["ColumnName"].ToString();
                            dataColumn.DataType = Type.GetType(dataRow["DataType"].ToString());
                            dataColumn.ReadOnly = (bool)dataRow["IsReadOnly"];
                            dataColumn.AutoIncrement = (bool)dataRow["IsAutoIncrement"];
                            dataColumn.Unique = (bool)dataRow["IsUnique"];
                            data.Columns.Add(dataColumn);
                        }

                        DataRow dt;
                        while (rdr.FieldCount > 0 && rdr.Read())
                        {
                            dt = data.NewRow();
                            for (int i = 0; i < data.Columns.Count; i++)
                            {
                                dt[i] = rdr[i];
                            }
                            data.Rows.Add(dt);
                        }
                    }
                }
                catch (Exception ex)
                {
                    GNX.cException.ShowBox(ex, cmd.CommandText);
                }
            }

            return data;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2100:Review SQL queries for security vulnerabilities")]
        public static int ExecuteNonQuery(string aSQL, DbAction act = DbAction.Null)
        {
            int affectedRows = 0;

            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = aSQL;
                    if (cmd.Parameters.Count > 0)
                    {
                        cmd.Prepare();
                    }

                    Log.Add(new cLog(cmd, act, cObject.GetDaoClassAndMethod()));
                    affectedRows = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    GNX.cException.ShowBox(ex, cmd.CommandText);
                }
            }
            return affectedRows;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2100:Review SQL queries for security vulnerabilities")]
        public static string ExecuteScalar(string aSQL)
        {
            if (cmd != null)
            {
                object select = string.Empty;

                try
                {
                    cmd.CommandText = aSQL;
                    if (cmd.Parameters.Count > 0)
                    {
                        cmd.Prepare();
                    }

                    Log.Add(new cLog(cmd));
                    select = cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    GNX.cException.ShowBox(ex, cmd.CommandText);
                }

                if (select != null)
                {
                    return select.ToString();
                }
            }
            return string.Empty;
        }

        public static DataRowCollection ExecuteSelect(string Sql, List<cSqlParameter> Params = null)
        {
            Open();

            if (Params != null)
            {
                foreach (cSqlParameter P in Params)
                {
                    AddSQLParameter(P);
                }
            }

            DataTable Table = ExecuteReader(Sql);

            Close();

            return Table.Rows;
        }

        public static cSqlResult Execute(string sql, List<cSqlParameter> Params, DbAction act)
        {
            Open();

            if (Params != null)
            {
                foreach (cSqlParameter p in Params)
                {
                    AddSQLParameter(p);
                }
            }

            cSqlResult result = new cSqlResult();
            result.AffectedRows = ExecuteNonQuery(sql, act);

            if (act == DbAction.Insert)
            {
                if (result.AffectedRows > 0)
                {
                    result.LastId = GetLastID();
                }
            }

            Close();

            return result;
        }
    }
}
