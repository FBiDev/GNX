﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//
using System.Text.RegularExpressions;

namespace GNX
{
    public static class ListExtension
    {
        public static bool Empty<TSource>(this IEnumerable<TSource> source)
        {
            return source == null || source.Count() == 0;
        }

        public static T First<T>(this List<T> list) where T : class, new()
        {
            if (list.Count == 0) { return new T(); }

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

        public static void MoveToLast<T>(this List<T> list, IEnumerable<T> items)
        {
            items.ToList().ForEach(x => list.Move(x, list.Count));
        }

        public static void MoveToFirst<T>(this List<T> list, T item)
        {
            list.Move(item, 0);
        }

        public static void MoveToFirst<T>(this List<T> list, IEnumerable<T> items)
        {
            items.ToList().ForEach(x => list.Move(x, 0));
        }

        public static IEnumerable<T> OrderByNatural<T>(this IEnumerable<T> items, Func<T, string> selector, StringComparer stringComparer = null)
        {
            var regex = new Regex(@"\d+", RegexOptions.Compiled);

            int maxDigits = items
                          .SelectMany(i => regex.Matches(selector(i)).Cast<Match>().Select(digitChunk => (int?)digitChunk.Value.Length))
                          .Max() ?? 0;

            return items.OrderBy(i => regex.Replace(selector(i), match => match.Value.PadLeft(maxDigits, '0')), stringComparer ?? StringComparer.CurrentCulture);
        }
    }
}
