using System;

namespace ImplementingLinkedList
{
    public class Program
    {
        static void Main(string[] args)
        {
            MyLinkedList linkedList = new MyLinkedList();

            linkedList.AddFirst(1);
            linkedList.AddFirst(2);

            linkedList.AddLast(3);
            linkedList.AddLast(4);

            linkedList.RemoveFirst();
            linkedList.RemoveLast();

            linkedList.ForEach(x => Console.WriteLine(x));
            linkedList.Reverse();
            linkedList.ForEach(x => Console.WriteLine(x));
            linkedList.Reverse();

            int[] array = linkedList.ToArray();
            int first = linkedList.GetFirst();
            int last = linkedList.GetLast();

            linkedList.Clear();
        }
    }
}
