using System;
using System.Collections.Generic;
using System.Text;

namespace ImplementingLinkedList
{

    public class MyLinkedList
    {
        private class Node
        {
            public Node(int value)
            {
                Value = value;
            }

            public int Value { get; set; }

            public Node Next { get; set; }

            public Node Previous { get; set; }
        }

        private Node head;
        private Node tail;
        private bool isReversed;

        public int Count { get; private set; }

        public bool IsReversed { get { return this.isReversed; } }

        public void Clear()
        {
            this.tail = null;
            this.head = null;
            this.Count = 0;
        }

        public int GetFirst()
        {
            return this.head.Value;
        }

        public int GetLast()
        {
            return this.tail.Value;
        }

        public int[] ToArray()
        {
            int[] array = new int[this.Count];
            Node currentNode = this.head;
            int index = 0;
            while (currentNode != null)
            {
                array[index++] = currentNode.Value;
                currentNode = currentNode.Next;
            }

            return array;
        }

        public void Reverse()
        {
            this.isReversed = !this.isReversed;
        }

        public void ForEach(Action<int> action)
        {
            Node currentNode = !this.isReversed ? this.head : this.tail;
            while (currentNode != null)
            {
                action(currentNode.Value);
                currentNode = !this.isReversed ? currentNode.Next : currentNode.Previous;
            }
        }

        public int RemoveLast()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            Node lastNode = this.tail;
            this.tail = this.tail.Previous;
            if (this.tail == null)
            {
                this.head = null;
            }
            else
            {
                this.tail.Next = null;
            }

            this.Count--;
            return lastNode.Value;
        }

        public int RemoveFirst()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            Node firstNode = this.head;
            this.head = this.head.Next;
            if (this.head == null)
            {
                this.tail = null;
            }
            else
            {
                this.head.Previous = null;
            }

            this.Count--;
            return firstNode.Value;
        }

        public void AddLast(int value)
        {
            Node newNode = new Node(value);
            if (this.Count == 0)
            {
                this.head = newNode;
                this.tail = newNode;
            }
            else
            {
                newNode.Previous = this.tail;
                this.tail.Next = newNode;
                this.tail = newNode;
            }
            this.Count++;
        }

        public void AddFirst(int value)
        {
            Node newNode = new Node(value);
            if (this.Count == 0)
            {
                this.head = newNode;
                this.tail = newNode;
            }
            else
            {
                newNode.Next = this.head;
                this.head.Previous = newNode;
                this.head = newNode;
            }
            this.Count++;
        }
    }
}
