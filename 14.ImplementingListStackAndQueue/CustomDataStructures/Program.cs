using System;

namespace CustomDataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CustomList Test:");

            CustomList customList = new CustomList();
            customList.Add(1);
            customList.Add(2);
            customList.Add(3);
            customList.Add(4);
            customList.Add(5);
            Console.WriteLine(customList.RemovaAt(2));
            Console.WriteLine(customList.Count);
            Console.WriteLine(customList.Contains(5));
            customList.Swap(0, 1);
            customList[0] = 150;
            customList.ForEach(x => Console.WriteLine(x));
            Console.WriteLine(customList.Count == 4);
            customList.Clear();
            Console.WriteLine(customList.Count == 0);



            Console.WriteLine("--------------------------------");
            Console.WriteLine("CustomStack Test:");

            CustomStack<int> customStack = new CustomStack<int>();
            customStack.Push(1);
            customStack.Push(2);
            customStack.Push(3);
            customStack.Push(4);
            customStack.Push(5);
            Console.WriteLine(customStack.Count == 5);
            Console.WriteLine(customStack.Pop() == 5);
            Console.WriteLine(customStack.Count == 4);
            Console.WriteLine(customStack.Peek() == 4);
            Console.WriteLine(customStack.Count == 4);
            customStack.ForEach(Console.WriteLine);
            Console.WriteLine(customStack.Count == 4);
            customStack.Clear();
            Console.WriteLine(customStack.Count == 0);



            Console.WriteLine("--------------------------------");
            Console.WriteLine("CustomQueue Test:");

            CustomQueue<int> customQueue = new CustomQueue<int>();
            customQueue.Enqueue(1);
            customQueue.Enqueue(2);
            customQueue.Enqueue(3);
            customQueue.Enqueue(4);
            customQueue.Enqueue(5);
            Console.WriteLine(customQueue.Count == 5);
            Console.WriteLine(customQueue.Dequeue() == 1);
            Console.WriteLine(customQueue.Count == 4);
            Console.WriteLine(customQueue.Peek() == 2);
            Console.WriteLine(customQueue.Count == 4);
            customQueue.ForEach(Console.WriteLine);
            Console.WriteLine(customQueue.Count == 4);
            customQueue.Clear();
            Console.WriteLine(customQueue.Count == 0);
        }
    }
}
