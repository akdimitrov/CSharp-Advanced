using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace T05.GenericCountMethodString
{
    public class Box<T> where T : IComparable
    {
        public Box()
        {
            Items = new List<T>();
        }

        public List<T> Items { get; set; }

        public void Swap(int index1, int index2)
        {
            if (AreInRange(index1, index2))
            {
                (Items[index1], Items[index2])
              = (Items[index2], Items[index1]);
            }
        }

        public int CountGreaterThan(T element)
            => Items.Count(x => x.CompareTo(element) > 0);

        public override string ToString()
            => string.Join(Environment.NewLine,
                Items.Select(x => $"{typeof(T)}: {x}"));

        private bool AreInRange(int index1, int index2)
            => index1 >= 0 && index1 < this.Items.Count
                && index2 >= 0 && index2 < this.Items.Count;
    }
}
