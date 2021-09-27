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
            eType typeName = (eType)_type.TypeHandle.Value;
            if (typeName == eType.String) { result = string.Empty; }

            List<string> cols = dRow.Table.Rows.Cast<DataRow>().Select(row => row["ColumnName"] as string).ToList();
            if (!cols.Contains(ColumnName)) { return result; }
			
            try
            {
				object column = dRow[ColumnName];
                string columnValue = column.ToString().Trim();
				
                if (!Convert.IsDBNull(column) && !(string.IsNullOrEmpty(columnValue)))
                {
                    switch (_type.Name)
                    {
                        case eType.Int32:
                            result = cConvert.ToIntNull(columnValue);
                            break;
                        //Short
                        case eType.Int16:
                            result = cConvert.ToShortNull(columnValue);
                            break;
                        //Float
                        case eType.Single:
                            result = cConvert.ToFloatNull(columnValue);
                            break;
                        case eType.Double:
                            result = cConvert.ToDoubleNull(columnValue);
                            break;
                        case "Decimal":
                            result = cConvert.ToDecimalNull(columnValue);
                            break;
                        case eType.String:
                            result = columnValue;
                            break;
                        case eType.Boolean:
                            result = cConvert.ToBoolean(columnValue);
                            break;
                        case eType.DateTime:
                            result = cConvert.ToDateTimeNull(columnValue);
                            break;
                        case eType.ByteArray:
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
