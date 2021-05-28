using System;
//
using System.Reflection;

namespace GNX
{
    public class cClone
    {
        public static void Object(Object Origin, Object Destination)
        {
            foreach (PropertyInfo property in Origin.GetType().GetProperties())
            {
                if (property.CanWrite)
                {
                    property.SetValue(Destination, property.GetValue(Origin, null), null);
                }
            }
        }
    }
}
