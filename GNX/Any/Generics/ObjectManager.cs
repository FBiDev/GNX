using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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

        public static string GetStackTrace()
        {
            var st = new StackTrace(true);
            var sf = st.GetFrames();

            var frames = sf.ToList();
            frames.RemoveRange(0, 4);

            string result = string.Empty;
            var lineNumber = 0;

            foreach (var frame in frames)
            {
                var frameMethod = frame.GetMethod();
                var frameMethodName = frameMethod.Name;

                if (new List<string> { "Start" }.Contains(frameMethod.Name))
                    continue;

                if (frameMethod.Name == ".ctor")
                {
                    frameMethodName = frameMethod.DeclaringType.Name;
                }

                if (frameMethod.Name == "MoveNext")
                {
                    lineNumber = frame.GetFileLineNumber();
                    continue;
                }

                if (new List<string> { "WndProc" }.Contains(frameMethod.Name))
                    break;

                if (lineNumber == 0) lineNumber = frame.GetFileLineNumber();

                result += lineNumber.ToString().PadLeft(3, '0');
                result += " : " + frameMethod.DeclaringType.Name + "." + frameMethodName;
                result += Environment.NewLine;
                lineNumber = 0;
            }
            return result;
        }
    }
}