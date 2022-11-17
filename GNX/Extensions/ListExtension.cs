using System;
using System.Collections.Generic;
using System.Linq;

namespace GNX
{
    public static class ListExtension
    {
        public static bool Empty<TSource>(this IEnumerable<TSource> source)
        {
            return source.Count() == 0;
        }

        public static T First<T>(this List<T> list) where T : class
        {
            if (list.Count == 0) { return null; }

            return list[0];
        }

        public static T FirstOrNew<T>(this List<T> list) where T : class, new()
        {
            if (list.Count == 0) { return new T(); }

            return list[0];
        }

        public static void Move<T>(this List<T> list, T item, int newIndex)
        {
            if (item != null)
            {
                var oldIndex = list.IndexOf(item);
                if (oldIndex > -1)
                {
                    list.RemoveAt(oldIndex);

                    if (newIndex > oldIndex) newIndex--;
                    // the actual index could have shifted due to the removal

                    list.Insert(newIndex, item);
                }
            }
        }

        public static void MoveToLast<T>(this List<T> list, T item)
        {
            list.Move(item, list.Count);
        }
    }
}
