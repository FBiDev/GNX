using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace GNX
{
    public class DatabaseManager
    {
        public ListSynced<cLogSQL> Log = new ListSynced<cLogSQL>();

        public DbSystem DatabaseSystem;

        public string ServerAddress { get; set; }
        public string DatabaseName { get; set; }
        public string DataBaseFile { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }

        public IDbConnection Connection;
        public string ConnectionString { get; set; }
        
        public int ConnectionTimeout { get; set; }
        public const int DefaultConnectionTimeout = 10;
        public const int DefaultCommandTimeout = 10;

        public List<IDbCommand> cmdList = new List<IDbCommand>();

        string DefaultConnectionString()
        {
            switch (DatabaseSystem)
            {
                case DbSystem.SQLServer: return "User ID=" + Username + ";Password=" + Password + ";Data Source=" + ServerAddress + ";Initial Catalog=" + DatabaseName + ";Connection Timeout=" + ConnectionTimeout + ";Persist Security Info=False;Packet Size=4096";
                case DbSystem.SQLite: return "Data Source=" + DataBaseFile + ";Version=3;";
                case DbSystem.SQLiteODBC: return "Driver=SQLite3 ODBC Driver; Datasource=" + DataBaseFile + ";Version=3;New=True;Compress=True;";
            }
            return null;
        }

        public void AddLog(IDbCommand cmd, DbAction action = DbAction.Null)
        {
            Log.Insert(0, new cLogSQL(Log.Count, cmd, action, ObjectManager.GetDaoClassAndMethod(13)));
        }

        public string LastCall
        {
            get
            {
                if (Log.Count == 0) return string.Empty;
                return Environment.NewLine + "Log: " + Environment.NewLine + Log[0].Method;
            }
        }

        public async Task<DateTime> DateTimeServer()
        {
            string sql = "SELECT GETDATE() AS DataServ;";
            if (DatabaseSystem == DbSystem.SQLite || DatabaseSystem == DbSystem.SQLiteODBC)
            {
                sql = "SELECT strftime('%Y-%m-%d %H:%M:%f','now', 'localtime') AS DataServ;";
            }

            List<cSqlParameter> parameters = null;
            var cmd = NewConnection(parameters);

            string select = await ExecuteScalar(cmd, sql);

            CloseConnection(cmd);

            return Convert.ToDateTime(select);
        }

        public async Task<int> GetLastID(IDbCommand cmd)
        {
            string sql = "SELECT SCOPE_IDENTITY() AS LastID;";
            if (DatabaseSystem == DbSystem.SQLite || DatabaseSystem == DbSystem.SQLiteODBC)
            {
                sql = "SELECT LAST_INSERT_ROWID() AS LastID;";
            }

            if (cmd != null && cmd.Connection != null && cmd.Connection.State == ConnectionState.Open)
            {
                string select = await ExecuteScalar(cmd, sql);
                return Cast.ToInt(0 + select);
            }

            return 0;
        }

        IDbCommand NewConnection(List<cSqlParameter> parameters)
        {
            var conn = (IDbConnection)Connection.Clone();

            if (ConnectionTimeout == 0)
            {
                ConnectionTimeout = DefaultConnectionTimeout;
            }

            var cmd = conn.CreateCommand();
            cmdList.Insert(0, cmd);

            OpenConnection(cmd);

            if (parameters != null)
                parameters.ForEach(x => AddSQLParameter(cmd, x));

            return cmd;
        }

        void SetConnectionString(IDbConnection conn)
        {
            if (conn == null || conn.ConnectionString.IsEmpty() == false)
                return;

            if (ConnectionString.IsEmpty())
                conn.ConnectionString = DefaultConnectionString();
            else
                conn.ConnectionString = ConnectionString;
        }

        void OpenConnection(IDbCommand cmd)
        {
            try
            {
                var conn = cmd.Connection;

                SetConnectionString(conn);

                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                if (cmd == null)
                    cmd = conn.CreateCommand();

                cmd.Connection = conn;
            }
            catch (Exception) { throw; }
        }

        void CloseConnection(IDbCommand cmd)
        {
            if (cmd == null || cmd.Connection == null) return;

            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.Connection.Close();
                cmd.Connection.Dispose();
                cmd.Dispose();
            }

            var timer = new StopwatchTimer(15);
            while (cmdList.Count > 10)
            {
                var lastcmd = cmdList.Last();

                if (timer.Stopped || lastcmd.Connection.State == ConnectionState.Closed)
                {
                    cmdList.Remove(lastcmd);
                    timer.Restart();
                }
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

        IDbDataParameter AddSQLParameter(IDbCommand cmd, cSqlParameter parameter)
        {
            if (cmd != null)
            {
                var p = cmd.CreateParameter();
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

        string ReplaceSQLCommands(string sql)
        {
            if (DatabaseSystem == DbSystem.SQLite || DatabaseSystem == DbSystem.SQLiteODBC)
            {
                //Concat in SQLite = ||
                sql = sql.Replace("'%'+", "'%'||");
                sql = sql.Replace("+'%'", "||'%'");

                sql = sql.Replace("'%' +", "'%' ||");
                sql = sql.Replace("+ '%'", "|| '%'");

                //Convert dateString to date
                sql = sql.Replace("CONVERT(date,", "date(");
                sql = sql.Replace("CONVERT(datetime,", "datetime(");
                sql = sql.Replace("CONVERT(datetime2,", "datetime(");
                sql = sql.Replace("CONVERT(datetime2(0),", "datetime(");
                sql = sql.Replace("CONVERT(datetime2(3),", "strftime('%Y-%m-%d %H:%M:%f',");
            }
            return sql;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2100:Review SQL queries for security vulnerabilities")]
        async Task<DataTable> ExecuteReader(IDbCommand cmd, string sql, string storedProcedure)
        {
            var data = new DataTable();

            if (cmd == null || cmd.Connection == null || cmd.Connection.State != ConnectionState.Open)
                return data;

            cmd.CommandText = sql;

            if (!string.IsNullOrWhiteSpace(storedProcedure))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = storedProcedure;
            }
            else
            {
                cmd.CommandText = ReplaceSQLCommands(cmd.CommandText);
            }

            AddLog(cmd, DbAction.Select);

            if (cmd.Parameters.Count > 0)
                cmd.Prepare();

            return await Task.Run(() =>
            {
                try
                {
                    using (IDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        var schemaTabela = rdr.GetSchemaTable();

                        foreach (DataRow dataRow in schemaTabela.Rows)
                        {
                            var dataColumn = new DataColumn();
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
                    return data;
                }
                catch (Exception) { throw; }
            });
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2100:Review SQL queries for security vulnerabilities")]
        async Task<int> ExecuteNonQuery(IDbCommand cmd, string sql, DbAction action = DbAction.Null)
        {
            int affectedRows = 0;

            if (cmd == null) return affectedRows;

            cmd.CommandText = sql;
            cmd.CommandText = ReplaceSQLCommands(cmd.CommandText);

            AddLog(cmd, action);

            return await Task.Run(() =>
            {
                try
                {
                    if (cmd.Parameters.Count > 0)
                        cmd.Prepare();

                    affectedRows = cmd.ExecuteNonQuery();
                    return affectedRows;
                }
                catch (Exception) { throw; }
            });
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2100:Review SQL queries for security vulnerabilities")]
        async Task<string> ExecuteScalar(IDbCommand cmd, string sql)
        {
            if (cmd == null) return string.Empty;

            cmd.CommandText = sql;
            AddLog(cmd);

            return await Task.Run(() =>
            {
                try
                {
                    if (cmd.Parameters.Count > 0)
                        cmd.Prepare();

                    var select = cmd.ExecuteScalar();

                    if (select != null)
                        return select.ToString();

                    return string.Empty;
                }
                catch (Exception) { throw; }
            });
        }

        public async Task<DataTable> ExecuteSelect(string sql, List<cSqlParameter> parameters = null, string storedProcedure = default(string))
        {
            var cmd = NewConnection(parameters);

            DataTable table = await ExecuteReader(cmd, sql, storedProcedure);

            CloseConnection(cmd);

            return table;
        }

        public async Task<string> ExecuteSelectString(string sql, List<cSqlParameter> parameters = null)
        {
            var cmd = NewConnection(parameters);

            string select = await ExecuteScalar(cmd, sql);

            CloseConnection(cmd);

            return select;
        }

        public async Task<cSqlResult> Execute(string sql, DbAction action, List<cSqlParameter> parameters)
        {
            var cmd = NewConnection(parameters);

            var result = new cSqlResult();
            result.AffectedRows = await ExecuteNonQuery(cmd, sql, action);

            if (action == DbAction.Insert && result.AffectedRows > 0)
                result.LastId = await GetLastID(cmd);

            CloseConnection(cmd);

            return result;
        }
    }
}