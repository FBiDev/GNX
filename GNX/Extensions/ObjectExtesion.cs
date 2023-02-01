using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;

namespace GNX
{
    public static class ObjectExtesion
    {
        public static bool IsNull(this object T)
        {
            return T == null;
        }

        public static bool NotNull(this object T)
        {
            return T != null;
        }

        public static TypeCode TypeCode(this Type type)
        {
            TypeCode code = Type.GetTypeCode(type);
            return code;
        }

        public static void Clone(this object origin, object from)
        {
            if (from.NotNull())
            {
                foreach (PropertyInfo property in from.GetType().GetProperties())
                {
                    if (property.CanWrite && !property.Name.Equals("Cloned"))
                    {
                        var value = property.GetValue(from, null);

                        property.SetValue(origin, value, null);
                    }
                }
            }
        }

        //public static T Clone<T>(this T obj)
        //{
        //    var inst = obj.GetType().GetMethod("MemberwiseClone", BindingFlags.Instance | BindingFlags.NonPublic);

        //    return (T)inst.Invoke(obj, null);
        //}

        public static object Clone(this object source)
        {
            var clone = FormatterServices.GetUninitializedObject(source.GetType());
            for (var type = source.GetType(); type != null; type = type.BaseType)
            {
                var fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);
                foreach (var field in fields)
                    field.SetValue(clone, field.GetValue(source));
            }
            return clone;
        }
    }
}
