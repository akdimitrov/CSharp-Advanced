using System;

namespace CustomDataStructures
{
    public class CustomStack<T>
    {
        private const int InitialCapacity = 4;

        private T[] elements;
        private int count;

        public CustomStack()
        {
            count = 0;
            elements = new T[InitialCapacity];
        }

        public int Count => count;

        public void Push(T element)
        {
            this.Resize();
            elements[count++] = element;
        }

        public T Pop()
        {
            EnsureIsInRange();
            T element = elements[count-1];
            count--;
            Shrink();
            return element;
        }

        public T Peek()
        {
            EnsureIsInRange();
            return elements[count - 1];
        }

        public void Clear()
        {
            elements = new T[InitialCapacity];
            count = 0;
        }

        public void ForEach(Action<T> action)
        {
            for (int i = count - 1; i >= 0; i--)
            {
                action(elements[i]);
            }
        }

        private void Shrink()
        {
            if (count <= elements.Length / 4)
            {
                T[] newArr = new T[count];
                for (int i = 0; i < count; i++)
                {
                    newArr[i] = elements[i];
                }
                elements = newArr;
            }
        }

        private void Resize()
        {
            if (elements.Length == count)
            {
                T[] newArr = new T[count * 2];
                for (int i = 0; i < elements.Length; i++)
                {
                    newArr[i] = elements[i];
                }
                elements = newArr;
            }
        }

        private void EnsureIsInRange()
        {
            if (count == 0)
            {
                throw new InvalidOperationException("CustomStack is empty");
            }
        }
    }
}
