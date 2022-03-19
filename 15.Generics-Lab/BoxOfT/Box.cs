using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOfT
{
    class Box<T>
    {
        private List<T> box = new List<T>();

        public int Count => this.box.Count;

        public void Add(T element)
        {
            this.box.Add(element);
        }

        public T Remove()
        {
            T element = this.box[^1];
            this.box.RemoveAt(this.box.Count - 1);
            return element;
        }
    }
}
