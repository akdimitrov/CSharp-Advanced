using System;

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
        }
    }
}
