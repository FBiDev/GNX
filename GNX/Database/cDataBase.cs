using System;
using System.Collections;
using System.Collections.Generic;
//
using System.Data;

namespace GNX
{
    public class cDataBase
    {
        public ListBind<cLogSQL> Log = new ListBind<cLogSQL>();

        public DbSystem DatabaseSystem;

        public string ServerAddress { get; set; }
        public string DatabaseName { get; set; }
        public string DataBaseFile { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }

        public string ConnectionString { get; set; }

        public IDbConnection Connection;
        //private IDbConnection conn { get; set; }
        //private IDbCommand cmd { get; set; }

        public List<IDbConnection> connList = new List<IDbConnection>();
        public List<IDbCommand> cmdList = new List<IDbCommand>();

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

        public void AddLog(IDbCommand cmd, DbAction action = DbAction.Null, string method = default(string))
        {
            Log.Insert(0, new cLogSQL(Log.Count, cmd, action, cObject.GetDaoClassAndMethod(5)));
        }

        public DateTime DateTimeServer()
        {
            string sql = "SELECT GETDATE() AS DataServ;";
            if (DatabaseSystem == DbSystem.SQLite || DatabaseSystem == DbSystem.SQLiteODBC)
            {
                sql = "SELECT strftime('%Y-%m-%d %H:%M:%f','now', 'localtime') AS DataServ;";
            }

            int connIndex = newConnection();
            Open(connIndex);

            string select = ExecuteScalar(connIndex, sql);
            return Convert.ToDateTime(select);
        }

        public int GetLastID(int connIndex = -1)
        {
            string sql = "SELECT SCOPE_IDENTITY() AS LastID;";
            if (DatabaseSystem == DbSystem.SQLite || DatabaseSystem == DbSystem.SQLiteODBC)
            {
                sql = "SELECT LAST_INSERT_ROWID() AS LastID;";
            }

            if (connIndex == -1)
                connIndex = newConnection();
            Open(connIndex);

            string select = ExecuteScalar(connIndex, sql);
            return Convert.ToInt32(0 + select);
        }

        private void CreateConnection(IDbConnection conn)
        {
            //conn = Connection;
            if (conn != null && conn.ConnectionString.Empty())
            {
                if (ConnectionString.Empty())
                {
                    conn.ConnectionString = DefaultConnectionString();
                }
                else
                {
                    conn.ConnectionString = ConnectionString;
                }
            }
        }

        private void OpenConnection(IDbConnection conn)
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

        int newConnection()
        {
            IDbConnection conn = (IDbConnection)Connection.Clone();
            connList.Add(conn);
            cmdList.Add(conn.CreateCommand());

            return connList.Count - 1;
        }

        private void Open(int connIndex)
        {
            try
            {
                var conn = connList[connIndex];
                var cmd = cmdList[connIndex];

                CreateConnection(conn);

                OpenConnection(conn);

                if (cmd == null)
                    cmd = conn.CreateCommand();

                cmd.Connection = conn;
            }
            catch (Exception ex)
            {
                cException.ShowBox(ex);
            }
        }

        private void Close(int connIndex)
        {
            var conn = connList[connIndex];
            var cmd = cmdList[connIndex];

            if (cmd != null && cmd.Connection != null && cmd.Connection.State == ConnectionState.Open)
            {
                cmd.Connection.Close();
                cmd.Parameters.Clear();
                conn.Close();
            }
        }

        //private IDbDataParameter AddSQLParameter(string parameterName, DbType dbType, object value, int size = 0, byte precision = 0, byte scale = 0)
        //{
        //    if (cmd != null)
        //    {
        //        IDbDataParameter p = cmd.CreateParameter();
        //        p.ParameterName = parameterName;
        //        p.DbType = dbType;
        //        p.Value = value;
        //        p.Size = size;
        //        p.Precision = precision;
        //        p.Scale = scale;
        //        cmd.Parameters.Add(p);

        //        return p;
        //    }

        //    return null;
        //}

        private IDbDataParameter AddSQLParameter(int connIndex, cSqlParameter parameter)
        {
            var cmd = cmdList[connIndex];

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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2100:Review SQL queries for security vulnerabilities")]
        private DataTable ExecuteReader(int connIndex, string sql, string storedProcedure)
        {
            DataTable data = new DataTable();
            DataSet ds = new DataSet();

            var cmd = cmdList[connIndex];

            if (cmd != null && cmd.Connection != null && cmd.Connection.State == ConnectionState.Open)
            {
                try
                {
                    cmd.CommandText = sql;

                    if (!string.IsNullOrWhiteSpace(storedProcedure))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = storedProcedure;
                    }
                    else
                    {
                        if (DatabaseSystem == DbSystem.SQLite || DatabaseSystem == DbSystem.SQLiteODBC)
                        {
                            //Concat in SQLite = ||
                            cmd.CommandText = cmd.CommandText.Replace("'%'+", "'%'||");
                            cmd.CommandText = cmd.CommandText.Replace("+'%'", "||'%'");

                            cmd.CommandText = cmd.CommandText.Replace("'%' +", "'%' ||");
                            cmd.CommandText = cmd.CommandText.Replace("+ '%'", "|| '%'");
                        }
                    }

                    if (cmd.Parameters.Count > 0)
                    {
                        cmd.Prepare();
                    }

                    AddLog(cmd, DbAction.Select);
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
        private int ExecuteNonQuery(int connIndex, string sql, DbAction action = DbAction.Null)
        {
            var cmd = cmdList[connIndex];

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

                    AddLog(cmd, action);
                    affectedRows = cmd.ExecuteNonQuery();

                    cmdList[connIndex] = cmd;
                }
                catch (Exception ex)
                {
                    cException.ShowBox(ex, cmd.CommandText);
                }
            }
            return affectedRows;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2100:Review SQL queries for security vulnerabilities")]
        private string ExecuteScalar(int connIndex, string sql)
        {
            var cmd = cmdList[connIndex];

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

                    AddLog(cmd);
                    select = cmd.ExecuteScalar();

                    cmdList[connIndex] = cmd;
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

        public DataTable ExecuteSelect(string sql, List<cSqlParameter> parameters = null, string storedProcedure = default(string))
        {
            int connIndex = newConnection();
            Open(connIndex);

            if (parameters != null)
            {
                foreach (cSqlParameter p in parameters)
                {
                    AddSQLParameter(connIndex, p);
                }
            }

            DataTable table = ExecuteReader(connIndex, sql, storedProcedure);

            Close(connIndex);

            return table;
        }

        public cSqlResult Execute(string sql, DbAction action, List<cSqlParameter> parameters)
        {
            int connIndex = newConnection();
            Open(connIndex);

            if (parameters != null)
            {
                foreach (cSqlParameter p in parameters)
                {
                    AddSQLParameter(connIndex, p);
                }
            }

            cSqlResult result = new cSqlResult();
            result.AffectedRows = ExecuteNonQuery(connIndex, sql, action);

            if (action == DbAction.Insert)
            {
                if (result.AffectedRows > 0)
                {
                    result.LastId = GetLastID(connIndex);
                }
            }

            Close(connIndex);

            return result;
        }
    }
}
