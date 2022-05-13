using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
//

namespace GNX
{
    public class cSqlParameter
    {
        public string ParameterName { get; set; }
        public DbType DbType { get; set; }
        public object Value { get; set; }
        public int Size { get; set; }
        public byte Precision { get; set; }
        public byte Scale { get; set; }

        public cSqlParameter(string ParameterName, object Value, int Size = 0)
        {
            this.ParameterName = ParameterName;

            this.Value = Value ?? DBNull.Value;
            if (this.Value == DBNull.Value) Size = 1;

            if (this.Value != null && this.Value != DBNull.Value)
            {
                Type ValueType = Value.GetType();

                switch (ValueType.Name)
                {
                    case "String":
                        this.DbType = DbType.String;
                        if (Size == 0) Size = -1;
                        break;
                    case "Int32": this.DbType = DbType.Int32; break;
                    case "DateTime":
                        this.DbType = DbType.DateTime2;
                        this.Value = cConvert.ToDateTimeDB((DateTime?)Value);
                        break;
                    case "Boolean":
                        this.DbType = DbType.Boolean;
                        this.Value = cConvert.ToIntNull(Value);
                        break;
                }
            }

            if (Size > 0 || Size == -1) this.Size = Size;
        }

        public cSqlParameter(string ParameterName, DbType DbType, object Value, int Size = 0, byte Precision = 0, byte Scale = 0)
        {
            if (DbType == DbType.String && Size == 0) Size = -1;

            this.ParameterName = ParameterName;
            this.DbType = DbType;
            this.Value = Value;
            this.Size = Size;
            this.Precision = Precision;
            this.Scale = Scale;
        }

        public static string Replace(string query, List<cSqlParameter> lParamsReplace)
        {
            foreach (cSqlParameter p in lParamsReplace)
            {
                query = ReplaceItem(query, p.Value, p.DbType, p.ParameterName);
            }
            return query;
        }

        public static string Replace(string query, IDataParameterCollection Parameters)
        {
            foreach (IDbDataParameter p in Parameters)
            {
                query = ReplaceItem(query, p.Value, p.DbType, p.ParameterName);
            }
            return query;
        }

        private static string ReplaceItem(string query, object value, DbType DbType, string ParameterName)
        {
            string val = value == null ? "NULL" : value.ToString();
            val = value == DBNull.Value ? "NULL" : value.ToString();

            val = val.Replace("'", "''");

            switch (DbType)
            {
                case DbType.String: val = "'" + val + "'"; break;
                case DbType.DateTime2: val = "'" + val + "'"; break;
                case DbType.DateTime: val = "'" + val + "'"; break;
            }

            query = Regex.Replace(query, ParameterName + @"\b", val);

            return query;
        }
    }
}
