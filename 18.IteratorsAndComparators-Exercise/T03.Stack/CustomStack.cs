using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace T03.Stack
{
    class CustomStack<T> : IEnumerable<T>
    {
        private List<T> list;

        public CustomStack()
        {
            this.list = new List<T>();
        }

        public void Push(T element)
        {
            this.list.Add(element);
        }

        public T Pop()
        {
            if (this.list.Count == 0)
            {
                Console.WriteLine("No elements");
                return default;
            }

            T element = this.list[^1];
            list.RemoveAt(this.list.Count - 1);
            return element;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new CustomStackIterator(this.list);
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private class CustomStackIterator : IEnumerator<T>
        {
            private List<T> list;
            private int index;

            public CustomStackIterator(List<T> list)
            {
                this.list = list;
                this.index = this.list.Count;
            }

            public T Current => this.list[index];

            public bool MoveNext()
            {
                return --index >= 0;
            }

            public void Reset() { }

            public void Dispose() { }

            object IEnumerator.Current => this.Current;
        }
    }
}
