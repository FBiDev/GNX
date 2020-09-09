using System;
using System.Collections.Generic;
//
using System.Linq;
using System.Linq.Expressions;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Data;

namespace GNX
{
    public class cObject
    {
        public static string GetPropertyName<T>(Expression<Func<T>> propertyLambda)
        {
            var me = propertyLambda.Body as MemberExpression;

            if (me == null)
            {
                throw new ArgumentException("You must pass a lambda of the form: '() => Class.Property' or '() => object.Property'");
            }

            return me.Member.Name;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetDaoClassAndMethod()
        {
            var st = new StackTrace();
            var sf = st.GetFrame(3);

            return sf.GetMethod().DeclaringType.Name + "." + sf.GetMethod().Name;
        }

        private static object ConvertValueFromRow<T>(DataRow row, string ColumnName)
        {
            object result = null;

            Type _type = typeof(T);
            if (row.Table.Columns.Contains(ColumnName))
            {
                switch (_type.Name)
                {
                    case "Int32":
                        result = cConvert.ToInt(row[ColumnName].ToString());
                        break;
                    case "String":
                        result = row[ColumnName].ToString();
                        break;
                    case "Boolean":
                        result = cConvert.ToBoolean(row[ColumnName].ToString());
                        break;
                    case "DateTime":
                        result = cConvert.ToDateTimeNull(row[ColumnName].ToString());
                        break;
                    //Single = float
                    //Int16 = short
                    //Byte = byte
                }
            }
            return result;
        }

        public static T SetPropertie<T>(DataRow row, string ColumnName)
        {
            object result = ConvertValueFromRow<T>(row, ColumnName);

            if (result != null)
            {
                return (T)result;
            }
            else
            {
                return default(T);
            }
        }

        public static Nullable<T> SetPropertieNullable<T>(DataRow row, string ColumnName) where T : struct
        {
            object result = ConvertValueFromRow<T>(row, ColumnName);

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
