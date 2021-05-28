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
            try
            {
                if (dRow[ColumnName] != null && !(string.IsNullOrEmpty(dRow[ColumnName].ToString().Trim())))
                {
                    object column = dRow[ColumnName];
                    string columnValue = column.ToString().Trim();

                    switch (_type.Name)
                    {
                        case "Int32":
                            result = cConvert.ToIntNull(columnValue);
                            break;
                        //Short
                        case "Int16":
                            result = cConvert.ToShortNull(columnValue);
                            break;
                        //Float
                        case "Single":
                            result = cConvert.ToFloatNull(columnValue);
                            break;
                        case "Double":
                            result = cConvert.ToDoubleNull(columnValue);
                            break;
                        case "Decimal":
                            result = cConvert.ToDecimalNull(columnValue);
                            break;
                        case "String":
                            result = columnValue;
                            break;
                        case "Boolean":
                            result = cConvert.ToBoolean(columnValue);
                            break;
                        case "DateTime":
                            result = cConvert.ToDateTimeNull(columnValue);
                            break;
                        case "Byte[]":
                            result = column;
                            break;
                        default:
                            throw new Exception("Tipo de dado inválido");
                    }
                }
                //Empty Value
                else
                {
                    return null;
                }
            }
            catch (Exception) { }
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
