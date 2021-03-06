using System;
using System.Collections.Generic;
using System.Linq;

namespace T04.GenericSwapMethodInteger
{
    public class Box<T>
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

        public override string ToString()
            => string.Join(Environment.NewLine,
                Items.Select(x => $"{typeof(T)}: {x}"));

        private bool AreInRange(int index1, int index2)
            => index1 >= 0 && index1 < this.Items.Count
                && index2 >= 0 && index2 < this.Items.Count;
    }
}
