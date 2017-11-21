using System.Collections;
using System.Collections.Generic;

namespace NullReferencesDemo.Common
{
    public class Option<T> : IEnumerable<T>
    {
        private readonly T[] data;

        private Option(T[] data)
        {
            this.data = data;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>) data).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public static Option<T> Create(T element)
        {
            return new Option<T>(new[] {element});
        }

        public static Option<T> CreateEmpty()
        {
            return new Option<T>(new T[0]);
        }
    }
}