using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDoublyLinkedList
{
    public class DoublyLinkedList<T>
    {
        public class Node<T>
        {
            public Node(T value)
            {
                Value = value;
            }

            public T Value { get; set; }

            public Node<T> Next { get; set; }

            public Node<T> Previous { get; set; }
        }

        private Node<T> head;
        private Node<T> tail;

        public int Count { get; private set; }

        public bool IsReversed { get; private set; }

        public Node<T> First => head;

        public Node<T> Last => tail;

        public void AddFirst(T element)
        {
            Node<T> node = new Node<T>(element);
            if (Count == 0)
            {
                head = node;
                tail = node;
            }
            else
            {
                node.Next = head;
                head.Previous = node;
                head = node;
            }
            Count++;
        }

        public void AddLast(T element)
        {
            Node<T> node = new Node<T>(element);
            if (Count == 0)
            {
                head = node;
                tail = node;
            }
            else
            {
                node.Previous = tail;
                tail.Next = node;
                tail = node;
            }
            Count++;
        }

        public T RemoveFirst()
        {
            IsEmpty();
            var node = head;
            head = node.Next;
            if (head == null)
            {
                tail = null;
            }
            else
            {
                head.Previous = null;
            }

            Count--;
            return node.Value;
        }

        public T RemoveLast()
        {
            IsEmpty();
            var node = tail;
            tail = tail.Previous;
            if (tail == null)
            {
                head = null;
            }
            else
            {
                tail.Next = null;
            }

            Count--;
            return node.Value;
        }

        public void ForEach(Action<T> action)
        {
            var node = IsReversed ? tail : head;
            while (node != null)
            {
                action(node.Value);
                node = IsReversed ? node.Previous : node.Next;
            }
        }

        public T[] ToArray()
        {
            T[] array = new T[Count];
            int index = 0;
            ForEach(x => array[index++] = x);
            return array;
        }

        public void Reverse()
        {
            IsReversed = !IsReversed;
        }

        public void Clear()
        {
            head = null;
            tail = null;
            Count = 0;
        }

        private bool IsEmpty()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }
            return false;
        }
    }
}
