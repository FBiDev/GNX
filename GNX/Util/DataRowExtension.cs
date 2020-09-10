using System;
using System.Collections.Generic;
using System.Data;
//

namespace GNX
{
    public static class DataRowExtension
    {
        private static object ConvertFieldValue<T>(this DataRow dRow, string ColumnName)
        {
            object result = null;

            Type _type = typeof(T);
            if (dRow.Table.Columns.Contains(ColumnName))
            {
                switch (_type.Name)
                {
                    case "Int32":
                        result = cConvert.ToInt(dRow[ColumnName].ToString());
                        break;
                    case "String":
                        result = dRow[ColumnName].ToString();
                        break;
                    case "Boolean":
                        result = cConvert.ToBoolean(dRow[ColumnName].ToString());
                        break;
                    case "DateTime":
                        result = cConvert.ToDateTimeNull(dRow[ColumnName].ToString());
                        break;
                    //Single = float
                    //Int16 = short
                    //Byte = byte
                }
            }
            return result;
        }

        public static T FieldValue<T>(this DataRow dRow, string ColumnName)
        {
            object result = ConvertFieldValue<T>(dRow, ColumnName);

            if (result != null)
            {
                return (T)result;
            }
            else
            {
                return default(T);
            }
        }

        public static Nullable<T> FieldValueNull<T>(this DataRow dRow, string ColumnName) where T : struct
        {
            object result = ConvertFieldValue<T>(dRow, ColumnName);

            if (result != null)
            {
                return (T)result;
            }
            else
            {
                return null;
            }
        }
    }
}
