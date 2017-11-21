using System;
using System.Collections.Generic;

namespace NullReferencesDemo.Common
{
    public static class IEnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var obj in source) action(obj);
        }

        public static IEnumerable<T> LazyDefaultIfEmpty<T>(this IEnumerable<T> source, Func<T> defaultFactory)
        {
            var isEmpty = true;

            foreach (var value in source)
            {
                yield return value;
                isEmpty = false;
            }

            if (isEmpty) yield return defaultFactory();
        }
    }
}