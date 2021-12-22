using System;
using System.Collections.Generic;
using System.Data;

namespace GNX
{
    public static class DataRowExtension
    {
        private static object ConvertFieldValue<T>(this DataRow row, string column)
        {
            object result = null;

            TypeCode type = typeof(T).TypeCode();
            if (type == TypeCode.String) { result = string.Empty; }
            if (!row.Table.Columns.Contains(column))
            {
                cDebug.AddError(Messages.ColumnError(column));
                return result;
            }

            try
            {
                object columnObj = row[column];
                string columnValue = columnObj.ToString().Trim();

                if (!Convert.IsDBNull(columnObj) && !string.IsNullOrEmpty(columnValue))
                {
                    switch (type)
                    {
                        case TypeCode.Object:
                            result = columnObj;
                            break;
                        case TypeCode.String:
                            result = columnValue;
                            break;
                        case TypeCode.Boolean:
                            result = cConvert.ToBoolean(columnValue);
                            break;
                        case TypeCode.DateTime:
                            result = cConvert.ToDateTimeNull(columnValue);
                            break;
                        case TypeCode.Int16:
                            result = cConvert.ToShortNull(columnValue);
                            break;
                        case TypeCode.Int32:
                            result = cConvert.ToIntNull(columnValue);
                            break;
                        case TypeCode.Single:
                            result = cConvert.ToFloatNull(columnValue);
                            break;
                        case TypeCode.Double:
                            result = cConvert.ToDoubleNull(columnValue);
                            break;
                        case TypeCode.Decimal:
                            result = cConvert.ToDecimalNull(columnValue);
                            break;
                        default:
                            throw new Exception("Tipo de dado inválido");
                    }
                }
            }
            catch (Exception) { }
            return result;
        }

        public static T FieldValue<T>(this DataRow row, string column)
        {
            object result = ConvertFieldValue<T>(row, column);

            if (result != null)
            {
                return (T)result;
            }
            else
            {
                return default(T);
            }
        }

        public static Nullable<T> FieldValueNull<T>(this DataRow row, string column) where T : struct
        {
            object result = ConvertFieldValue<T>(row, column);

            if (result != null)
            {
                return (T)result;
            }
            else
            {
                return null;
            }
        }

        public static string Cell(this DataRow row, int collumn)
        {
            return row.ItemArray[collumn].ToString();
        }
    }
}
