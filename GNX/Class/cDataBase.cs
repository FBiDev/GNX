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

        private static DatabaseName DatabaseName;

        private static IDbCommand cmd { get; set; }
        private static IDbConnection conn { get; set; }

        public static string GetError()
        {
            string newError = error;
            error = string.Empty;
            return newError;
        }

        public static int GetLastID()
        {
            string aSQL = string.Empty;
            if (DatabaseName == DatabaseName.DB_SOLUTION)
            {
                if (cDataBaseConfig.SolutionType == DatabaseType.SQLite || cDataBaseConfig.SolutionType == DatabaseType.SQLiteODBC)
                {
                    aSQL = "SELECT LAST_INSERT_ROWID();";
                }
            }

            SetCommand();

            string select = ExecuteScalar(aSQL);
            return Convert.ToInt32(0 + select);
        }

        private static IDbConnection CreateConnection()
        {
            if (DatabaseName == DatabaseName.DB_SOLUTION)
            {
                conn = cDataBaseConfig.SolutionConnection;
                conn.ConnectionString = cDataBaseConfig.SolutionDataSource;

                //if (cDataBaseConfig.SolutionType == DatabaseType.SQLite || cDataBaseConfig.SolutionType == DatabaseType.SQLiteODBC)
                //{
                //    if (cDataBaseConfig.SQLiteEnable && File.Exists(cDataBaseConfig.SolutionFile))
                //    {
                //        conn = cDataBaseSQLite.CreateConnection(cDataBaseConfig.SolutionDataSource);
                //    }
                //    else
                //    {
                //        throw new Exception(cDataBaseConfig.SolutionFile);
                //    }
                //}
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
            if (DatabaseName != DatabaseName.DB_SOLUTION)
            {
                DatabaseName = DatabaseName.DB_SOLUTION;
                conn = null;
            }
            SetCommand();
        }

        public static void OpenGeral()
        {
            if (DatabaseName != DatabaseName.DB_GERAL)
            {
                DatabaseName = DatabaseName.DB_GERAL;
                conn = null;
            }
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

                //if (_databaseName == DatabaseName.DB_SOLUTION)
                //{
                //    if (cDataBaseConfig.SolutionType == DatabaseType.SQLite || cDataBaseConfig.SolutionType == DatabaseType.SQLiteODBC)
                //    {
                //        if (cDataBaseConfig.SQLiteEnable)
                //        {
                //            cmd = cDataBaseSQLite.SetCommand();
                //        }
                //    }
                //}
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

                    Log.Add(new cLog(cmd, DbMovement.Select, cObject.GetDaoClassAndMethod()));

                    using (IDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        //IDataAdapter da = default(IDataAdapter);

                        //if (_databaseName == DatabaseName.DB_SOLUTION)
                        //{
                        //    if (cDataBaseConfig.SolutionType == DatabaseType.SQLite || cDataBaseConfig.SolutionType == DatabaseType.SQLiteODBC)
                        //    {
                        //        if (cDataBaseConfig.SQLiteEnable)
                        //        {
                        //            da = cDataBaseSQLite.ExecuteReader(cmd.CommandText, cmd.Connection.ConnectionString);
                        //        }
                        //    }
                        //}

                        //if (da != null)
                        //{
                        //    da.Fill(ds);
                        //    data = ds.Tables[0];
                        //}

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
        public static int ExecuteNonQuery(string aSQL, DbMovement Movement = DbMovement.Null)
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

                    Log.Add(new cLog(cmd, Movement, cObject.GetDaoClassAndMethod()));
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
            cDataBase.Open();

            if (Params != null)
            {
                foreach (cSqlParameter P in Params)
                {
                    cDataBase.AddSQLParameter(P);
                }
            }

            DataTable Table = cDataBase.ExecuteReader(Sql);
            cDataBase.Close();

            return Table.Rows;

            //T ListObjects = new T();
            //foreach (DataRow Row in Table.Rows)
            //{
            //    ListObjects.Add(BaseDAO. obj. SetObject(Row));
            //}

            //return ListObjects;
        }

        public static cSqlResult Execute(string Sql, List<cSqlParameter> Params, DbMovement Movement)
        {
            cDataBase.Open();

            if (Params != null)
            {
                foreach (cSqlParameter p in Params)
                {
                    cDataBase.AddSQLParameter(p);
                }
            }

            cSqlResult result = new cSqlResult();
            result.AffectedRows = cDataBase.ExecuteNonQuery(Sql, Movement);

            if (Movement == DbMovement.Insert)
            {
                if (result.AffectedRows > 0)
                {
                    result.LastId = cDataBase.GetLastID();
                }
            }

            cDataBase.Close();

            return result;
        }
    }
}
