using System;
using System.Collections.Generic;
using System.Reflection;

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
            foreach (PropertyInfo property in from.GetType().GetProperties())
            {
                if (property.CanWrite)
                {
                    property.SetValue(origin, property.GetValue(from, null), null);
                }
            }
        }
    }
}
