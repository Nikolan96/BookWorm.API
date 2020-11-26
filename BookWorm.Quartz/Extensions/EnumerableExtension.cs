using System;
using System.Collections.Generic;

namespace BookWorm.Quartz.Extensions
{
    public static class EnumerableExtension
    {
        public static bool Exists<T>(this T obj)
        {
            return obj != null;
        }

        public static void OnEach<T>(this IEnumerable<T> sequence, Action<T> action)
        {
            foreach (var s in sequence)
            {
                action(s);
            }
        }

        public static IEnumerable<T> ToEnumerable<T>(this T item)
        {
            yield return item;
        }
    }
}
