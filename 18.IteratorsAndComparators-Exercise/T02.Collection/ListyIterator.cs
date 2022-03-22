using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace T02.Collection
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private readonly List<T> list;
        private int index;

        public ListyIterator(List<T> list)
        {
            this.list = list;
            this.index = 0;
        }

        public bool Move()
        {
            if (HasNext())
            {
                return ++index < this.list.Count;
            }
            return false;
        }

        public bool HasNext()
        {
            return index + 1 < this.list.Count;
        }

        public void Print()
        {
            if (this.list.Count == 0)
            {
                throw new Exception("Invalid Operation!");
            }

            Console.WriteLine(this.list[index]);
        }

        public void PrintAll()
        {
            if (this.list.Count == 0)
            {
                throw new Exception("Invalid Operation!");
            }

            foreach (var item in this.list)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in list)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
