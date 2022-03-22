using System;
using System.Collections.Generic;

namespace CustomDoublyLinkedList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            DoublyLinkedList<int> custom = new DoublyLinkedList<int>();
            custom.AddFirst(1);
            custom.AddFirst(2);
            custom.AddFirst(3);
            custom.AddLast(4);
            custom.AddLast(5);
            custom.AddLast(6);
            Console.WriteLine(custom.RemoveFirst());
            Console.WriteLine(custom.RemoveLast());
            Console.WriteLine("#" + custom.Count);

            custom.ForEach(Console.WriteLine);
            custom.Reverse();
            int[] array = custom.ToArray();
            Console.WriteLine(string.Join(", ", array));

            custom.Clear();
            Console.WriteLine("#" + custom.Count);

            DoublyLinkedList<List<int>> custom1 = new DoublyLinkedList<List<int>>();
            custom1.AddFirst(new List<int>() { 7, 8, 9 });
            custom1.AddFirst(new List<int>() { 4, 5, 6 });
            custom1.AddFirst(new List<int>() { 1, 2, 3 });

            foreach (var item in custom1)
            {
                Console.WriteLine(string.Join(" ", item));
            }
        }
    }
}
