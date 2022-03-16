using System;

namespace CustomDataStructures
{
    public class CustomList
    {
        private const int InitialCapacity = 2;

        private int[] elements;
        private int count;

        public CustomList()
        {
            this.elements = new int[InitialCapacity];
            this.count = 0;
        }

        public int Count => this.count;

        public int this[int index]
        {
            get
            {
                this.EnsureIsInRage(index);
                return elements[index];
            }
            set
            {
                this.EnsureIsInRage(index);
                elements[index] = value;
            }
        }


        public void Add(int element)
        {
            this.Resize();
            this.elements[this.count++] = element;
        }

        public void Shrink()
        {
            int[] newArr = new int[this.count];
            for (int i = 0; i < this.Count; i++)
            {
                newArr[i] = this.elements[i];
            }

            this.elements = newArr;
        }

        public int RemovaAt(int index)
        {
            this.EnsureIsInRage(index);

            int element = this.elements[index];
            this.count--;
            this.Shift(index);

            if (this.count <= this.elements.Length / 4)
            {
                this.Shrink();
            }

            return element;
        }

        public void Insert(int index, int element)
        {
            this.EnsureIsInRage(index);
            this.Resize();

            this.ShiftToRight(index);
            this.elements[index] = element;
            this.count++;
        }

        public bool Contains(int element)
        {
            foreach (var item in this.elements)
            {
                if (item == element)
                {
                    return true;
                }
            }
            return false;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            EnsureIsInRage(firstIndex);
            EnsureIsInRage(secondIndex);

            int element = this.elements[firstIndex];
            this.elements[firstIndex] = this.elements[secondIndex];
            this.elements[secondIndex] = element;
        }

        public void ForEach(Action<int> action)
        {
            for (int i = 0; i < this.count; i++)
            {
                action(this.elements[i]);
            }
        }

        public void Clear()
        {
            elements = new int[InitialCapacity];
            count = 0;
        }

        private void EnsureIsInRage(int index)
        {
            if (index >= this.count || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
        }

        private void Resize()
        {
            if (this.count == this.elements.Length)
            {
                int[] newArr = new int[this.elements.Length * 2];
                for (int i = 0; i < this.elements.Length; i++)
                {
                    newArr[i] = this.elements[i];
                }

                this.elements = newArr;
            }
        }

        private void Shift(int index)
        {
            for (int i = index; i < this.count; i++)
            {
                this.elements[i] = this.elements[i + 1];
            }
        }

        private void ShiftToRight(int index)
        {
            for (int i = this.count; i > index; i--)
            {
                this.elements[i] = this.elements[i - 1];
            }
        }
    }
}
