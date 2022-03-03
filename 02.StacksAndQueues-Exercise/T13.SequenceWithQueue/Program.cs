using System;
using System.Collections.Generic;

namespace T13.SequenceWithQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());
            Queue<long> queue = new Queue<long>();
            Queue<long> finalSequence = new Queue<long>();
            finalSequence.Enqueue(n);
            while (finalSequence.Count < 50)
            {
                queue.Enqueue(n + 1);
                queue.Enqueue(2 * n + 1);
                queue.Enqueue(n + 2);
                n = queue.Dequeue();
                finalSequence.Enqueue(n);
            }
            Console.WriteLine(string.Join(" ", finalSequence));
        }
    }
}
