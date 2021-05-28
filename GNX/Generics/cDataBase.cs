using System;
using System.Collections;
using System.Collections.Generic;
//
using System.Data;

namespace GNX
{
    public class cDataBase
    {
        public ListBind<cLog> Log = new ListBind<cLog>();

        private string error = String.Empty;

        public DbSystem DatabaseSystem;
        public IDbConnection Connection;

        public string ServerAddress { get; set; }
        public string DatabaseName { get; set; }
        public string DataBaseFile { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }

        public string ConnectionString { get; set; }

        private IDbCommand cmd { get; set; }
        private IDbConnection conn { get; set; }

        private string DefaultConnectionString()
        {
            switch (DatabaseSystem)
            {
                case DbSystem.SQLServer: return "User ID=" + Username + ";Password=" + Password + ";Data Source=" + ServerAddress + ";Initial Catalog=" + DatabaseName + ";Persist Security Info=False;Packet Size=4096";
                case DbSystem.SQLite: return "Data Source=" + DataBaseFile + ";Version=3;";
                case DbSystem.SQLiteODBC: return "Driver = SQLite3 ODBC Driver; Datasource = " + DataBaseFile + ";Version = 3;New=True;Compress=True;";
            }
            return null;
        }

        public string GetError()
        {
            string newError = error;
            error = string.Empty;
            return newError;
        }

        public DateTime DataServidor()
        {
            string sql = "SELECT GETDATE() AS DataServ";
            SetCommand();

            string select = ExecuteScalar(sql);
            return Convert.ToDateTime(select);
        }

        public int GetLastID()
        {
            string sql = string.Empty;
            if (DatabaseSystem == DbSystem.SQLite || DatabaseSystem == DbSystem.SQLiteODBC)
            {
                sql = "SELECT LAST_INSERT_ROWID();";
            }

            SetCommand();

            string select = ExecuteScalar(sql);
            return Convert.ToInt32(0 + select);
        }

        private IDbConnection CreateConnection()
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

        private void OpenConnection()
        {
            if (conn.State == ConnectionState.Closed)
            {
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    cException.ShowBox(ex);
                }
            }
        }

        private IDbDataParameter AddSQLParameter(string parameterName, DbType dbType, object value, int size = 0, byte precision = 0, byte scale = 0)
        {
            if (cmd != null)
            {
                IDbDataParameter p = cmd.CreateParameter();
                p.ParameterName = parameterName;
                p.DbType = dbType;
                p.Value = value;
                p.Size = size;
                p.Precision = precision;
                p.Scale = scale;
                cmd.Parameters.Add(p);

                return p;
            }

            return null;
        }

        private IDbDataParameter AddSQLParameter(cSqlParameter parameter)
        {
            if (cmd != null)
            {
                IDbDataParameter p = cmd.CreateParameter();
                p.ParameterName = parameter.ParameterName;
                p.DbType = parameter.DbType;
                p.Value = parameter.Value;
                p.Size = parameter.Size;
                p.Precision = parameter.Precision;
                p.Scale = parameter.Scale;
                cmd.Parameters.Add(p);

                return p;
            }

            return null;
        }

        private void Open()
        {
            SetCommand();
        }

        private void SetCommand()
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
                cException.ShowBox(ex);
            }
        }

        private void Close()
        {
            if (cmd != null && cmd.Connection != null && cmd.Connection.State == ConnectionState.Open)
            {
                cmd.Connection.Close();
                cmd.Parameters.Clear();
                conn.Close();
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2100:Review SQL queries for security vulnerabilities")]
        private DataTable ExecuteReader(string sql)
        {
            DataTable data = new DataTable();
            DataSet ds = new DataSet();

            if (cmd != null && cmd.Connection != null && cmd.Connection.State == ConnectionState.Open)
            {
                try
                {
                    cmd.CommandText = sql;

                    if (cmd.Parameters.Count > 0)
                    {
                        cmd.Prepare();
                    }

                    Log.Add(new cLog(Log.Count, cmd, DbAction.Select, cObject.GetDaoClassAndMethod()));

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
                    cException.ShowBox(ex, cmd.CommandText);
                }
            }

            return data;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2100:Review SQL queries for security vulnerabilities")]
        private int ExecuteNonQuery(string sql, DbAction action = DbAction.Null)
        {
            int affectedRows = 0;

            if (cmd != null)
            {
                try
                {
                    cmd.CommandText = sql;
                    if (cmd.Parameters.Count > 0)
                    {
                        cmd.Prepare();
                    }

                    Log.Add(new cLog(Log.Count, cmd, action, cObject.GetDaoClassAndMethod()));
                    affectedRows = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    cException.ShowBox(ex, cmd.CommandText);
                }
            }
            return affectedRows;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2100:Review SQL queries for security vulnerabilities")]
        private string ExecuteScalar(string sql)
        {
            if (cmd != null)
            {
                object select = string.Empty;

                try
                {
                    cmd.CommandText = sql;
                    if (cmd.Parameters.Count > 0)
                    {
                        cmd.Prepare();
                    }

                    Log.Add(new cLog(Log.Count, cmd));
                    select = cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    cException.ShowBox(ex, cmd.CommandText);
                }

                if (select != null)
                {
                    return select.ToString();
                }
            }
            return string.Empty;
        }

        public DataTable ExecuteSelect(string sql, List<cSqlParameter> parameters = null)
        {
            Open();

            if (parameters != null)
            {
                foreach (cSqlParameter p in parameters)
                {
                    AddSQLParameter(p);
                }
            }

            DataTable table = ExecuteReader(sql);

            Close();

            return table;
        }

        public cSqlResult Execute(string sql, List<cSqlParameter> parameters, DbAction action)
        {
            Open();

            if (parameters != null)
            {
                foreach (cSqlParameter p in parameters)
                {
                    AddSQLParameter(p);
                }
            }

            cSqlResult result = new cSqlResult();
            result.AffectedRows = ExecuteNonQuery(sql, action);

            if (action == DbAction.Insert)
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
