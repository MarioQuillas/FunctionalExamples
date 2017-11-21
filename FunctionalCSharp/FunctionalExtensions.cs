using System;

namespace FunctionalCSharp
{
    public static class FunctionalExtensions
    {
        public static TResult Map<TSource, TResult>(this TSource @this, Func<TSource, TResult> fn)
        {
            return fn(@this);
        }

        public static T Tee<T>(this T @this, Action<T> action)
        {
            action(@this);
            return @this;
        }

        public static T When<T>(this T @this, Func<bool> predicate, Func<T, T> fn)
        {
            return predicate() ? fn(@this) : @this;
        }
    }
}