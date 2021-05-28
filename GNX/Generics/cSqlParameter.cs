using System;
using System.Collections.Generic;
using System.Data;
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
            this.Value = Value;

            if (this.Value != null)
            {
                Type ValueType = Value.GetType();

                switch (ValueType.Name)
                {
                    case "String": this.DbType = DbType.String; break;
                    case "Int32": this.DbType = DbType.Int32; break;
                    case "DateTime":
                        this.DbType = DbType.DateTime2;
                        this.Value = cConvert.ToDateTimeDB((DateTime?)Value);
                        break;
                    case "Boolean": this.DbType = DbType.Boolean; break;
                }
            }

            this.Size = Size;
        }

        public cSqlParameter(string ParameterName, DbType DbType, object Value, int Size = 0, byte Precision = 0, byte Scale = 0)
        {
            this.ParameterName = ParameterName;
            this.DbType = DbType;
            this.Value = Value;
            this.Size = Size;
            this.Precision = Precision;
            this.Scale = Scale;
        }
    }
}
