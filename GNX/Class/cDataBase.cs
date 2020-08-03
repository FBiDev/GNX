using System;
using System.Collections.Generic;
//
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace GNX
{
    public class cDataBase
    {
        private static string error = String.Empty;

        private static DatabaseName _databaseName;
        private static DatabaseName DatabaseName { get { return _databaseName; } }

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
            if (_databaseName == DatabaseName.DB_SOLUTION)
            {
                if (cDataBaseConfig.SolutionType == DatabaseType.SQLite || cDataBaseConfig.SolutionType == DatabaseType.SQLiteODBC)
                {
                    aSQL = "SELECT last_insert_rowid();";
                }
            }

            SetCommand(aSQL);

            string select = ExecuteScalar();
            return Convert.ToInt32(0 + select);
        }

        private static IDbConnection CreateConnection()
        {
            if (_databaseName == DatabaseName.DB_SOLUTION)
            {
                if (cDataBaseConfig.SolutionType == DatabaseType.SQLite || cDataBaseConfig.SolutionType == DatabaseType.SQLiteODBC)
                {
                    if (File.Exists(cDataBaseConfig.SolutionFile))
                    {
                        conn = new SQLiteConnection(cDataBaseConfig.SolutionDataSource);
                    }
                    else
                    {
                        throw new Exception(cDataBaseConfig.SolutionFile);
                    }
                }
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

        public static void AddSQLParameter(string ParameterName, DbType DbType, object Value, int Size = 0, byte Precision = 0, byte Scale = 0)
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
            }
        }

        public static void SetSQL(string aSQl)
        {
            _databaseName = DatabaseName.DB_SOLUTION;
            SetCommand(aSQl);
        }

        public static void SetSQLGeral(string aSQl)
        {
            _databaseName = DatabaseName.DB_GERAL;
            SetCommand(aSQl);
        }

        private static void SetCommand(string aSQl)
        {
            try
            {
                if (_databaseName == DatabaseName.DB_SOLUTION)
                {
                    if (cDataBaseConfig.SolutionType == DatabaseType.SQLite || cDataBaseConfig.SolutionType == DatabaseType.SQLiteODBC)
                    {
                        cmd = new SQLiteCommand(aSQl);
                    }
                }

                if (conn == null)
                {
                    conn = CreateConnection();
                }

                OpenConnection();

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

        public static DataTable ExecuteReader()
        {
            DataTable data = new DataTable();
            DataSet ds = new DataSet();

            if (cmd != null && cmd.Connection != null && cmd.Connection.State == ConnectionState.Open)
            {
                try
                {
                    using (IDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        IDataAdapter da = default(IDataAdapter);

                        if (_databaseName == DatabaseName.DB_SOLUTION)
                        {
                            if (cDataBaseConfig.SolutionType == DatabaseType.SQLite || cDataBaseConfig.SolutionType == DatabaseType.SQLiteODBC)
                            {
                                da = new SQLiteDataAdapter(cmd.CommandText, cmd.Connection.ConnectionString);
                            }
                        }

                        if (da != null)
                        {
                            da.Fill(ds);
                            data = ds.Tables[0];
                        }
                        rdr.Close();
                    }
                }
                catch (Exception ex)
                {
                    GNX.cException.ShowBox(ex, cmd.CommandText);
                }
            }

            return data;
        }

        public static int ExecuteNonQuery()
        {
            int affectedRows = 0;
            try
            {
                if (cmd.Parameters.Count > 0) { cmd.Prepare(); }
                affectedRows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                GNX.cException.ShowBox(ex, cmd.CommandText);
            }

            return affectedRows;
        }

        public static string ExecuteScalar()
        {
            object select = string.Empty;
            try
            {
                if (cmd.Parameters.Count > 0) { cmd.Prepare(); }
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
            return string.Empty;
        }
    }
}
