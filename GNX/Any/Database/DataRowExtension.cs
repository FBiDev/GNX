using System;
using System.Data;

namespace GNX
{
    public static class DataRowExtension
    {
        internal static object ConvertFieldValue(DataRow row, string column, TypeCode type, object result)
        {
            try
            {
                object columnObj = row[column];
                var columnValue = columnObj.ToString().Trim();

                if (Convert.IsDBNull(columnObj) || string.IsNullOrEmpty(columnValue))
                    return result;

                switch (type)
                {
                    case TypeCode.Object: result = columnObj; break;
                    case TypeCode.String: result = columnValue; break;
                    case TypeCode.Boolean: result = cConvert.ToBoolean(columnValue); break;
                    case TypeCode.DateTime: result = cConvert.ToDateTimeNull(columnValue); break;
                    case TypeCode.Int16: result = cConvert.ToShortNull(columnValue); break;
                    case TypeCode.Int32: result = cConvert.ToIntNull(columnValue); break;
                    case TypeCode.Single: result = cConvert.ToFloatNull(columnValue); break;
                    case TypeCode.Double: result = cConvert.ToDoubleNull(columnValue); break;
                    case TypeCode.Decimal: result = cConvert.ToDecimalNull(columnValue); break;
                    default: throw new Exception("Tipo de dado inválido");
                }
            }
            catch (Exception e)
            {
                var error = e.Message;
            }

            return result;
        }

        public static string Cell(this DataRow row, int collumn)
        {
            return row.ItemArray[collumn].ToString();
        }
    }
}