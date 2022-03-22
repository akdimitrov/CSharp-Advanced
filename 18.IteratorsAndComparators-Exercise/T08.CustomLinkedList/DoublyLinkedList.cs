using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CustomDoublyLinkedList
{
    public class DoublyLinkedList<T> : IEnumerable<T>
    {
        public class Node<U>
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
            if (Count != 0)
            {
                node.Next = head;
                head.Previous = node;
                head = node;
            }
            else head = tail = node;

            Count++;
        }

        public void AddLast(T element)
        {
            Node<T> node = new Node<T>(element);
            if (Count != 0)
            {
                tail.Next = node;
                node.Previous = tail;
                tail = node;
            }
            else head = tail = node;

            Count++;
        }

        public T RemoveFirst()
        {
            IsEmpty();
            var node = head;
            head = node.Next;

            if (head == null) tail = null;
            else head.Previous = null;

            Count--;
            return node.Value;
        }

        public T RemoveLast()
        {
            IsEmpty();
            var node = tail;
            tail = tail.Previous;

            if (tail == null) head = null;
            else tail.Next = null;

            Count--;
            return node.Value;
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

        public T[] ToArray()
        {
            T[] array = new T[Count];
            int index = 0;
            ForEach(x => array[index++] = x);
            return array;
        }

        public void ForEach(Action<T> action)
        {
            Node<T> node = !IsReversed ? head : tail;
            while (node != null)
            {
                action(node.Value);
                node = !IsReversed ? node.Next : node.Previous;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> node = !IsReversed ? head : tail;
            while (node != null)
            {
                yield return node.Value;
                node = !IsReversed ? node.Next : node.Previous;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

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
