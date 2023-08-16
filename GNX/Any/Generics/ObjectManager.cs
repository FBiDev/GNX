using System;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace GNX
{
    public static class ObjectManager
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
        public static string GetDaoClassAndMethod(int frameIndex = 0)
        {
            var st = new StackTrace();
            var sf = st.GetFrame(frameIndex);

            return sf.GetMethod().DeclaringType.Name + "." + sf.GetMethod().Name;
        }
    }
}