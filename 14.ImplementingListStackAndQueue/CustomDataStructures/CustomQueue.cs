using System;

namespace CustomDataStructures
{
    class CustomQueue<T>
    {
        private const int InitialCapacity = 4;

        private T[] elements;

        public CustomQueue()
        {
            elements = new T[InitialCapacity];
        }

        public int Count { get; private set; }

        public void Enqueue(T element)
        {
            Resize();
            elements[Count++] = element;
        }

        public T Dequeue()
        {
            EnsureIsInRange();
            T element = elements[0];
            Count--;
            ShiftLeft();
            Shrink();
            return element;
        }

        public T Peek()
        {
            return elements[0];
        }

        public void Clear()
        {
            elements = new T[InitialCapacity];
            Count = 0;
        }

        public void ForEach(Action<T> action)
        {
            for (int i = 0; i < Count; i++)
            {
                action(elements[i]);
            }
        }

        private void ShiftLeft()
        {
            for (int i = 0; i < Count; i++)
            {
                elements[i] = elements[i + 1];
            }
        }

        private void EnsureIsInRange()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("CustomQueue is empty");
            }
        }

        private void Shrink()
        {
            if (Count == elements.Length / 4)
            {
                T[] newArray = new T[Count];
                for (int i = 0; i < Count; i++)
                {
                    newArray[i] = elements[i];
                }
                elements = newArray;
            }
        }

        private void Resize()
        {
            if (Count == elements.Length)
            {
                T[] newArray = new T[Count * 2];
                for (int i = 0; i < Count; i++)
                {
                    newArray[i] = elements[i];
                }
                elements = newArray;
            }
        }
    }
}
