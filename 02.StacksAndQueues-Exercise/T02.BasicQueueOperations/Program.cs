using System;
using System.Collections.Generic;
using System.Linq;

namespace T02.BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int elementsToEnqueue = array[0];
            int elementsToDequeue = array[1];
            int searchedElement = array[2];
            Queue<int> queue = new Queue<int>(numbers.Take(elementsToEnqueue));
            for (int i = 0; i < elementsToDequeue; i++)
            {
                queue.Dequeue();
            }

            if (queue.Contains(searchedElement))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(queue.Count > 0 ? queue.Min() : 0);
            }
        }
    }
}
