using System;
using System.Collections.Generic;
using System.Linq;

namespace T01.Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> tasks = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Queue<int> threads = new Queue<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            int taskToBeKilled = int.Parse(Console.ReadLine());
            while (tasks.Peek() != taskToBeKilled)
            {
                if (threads.Peek() < tasks.Peek())
                {
                    threads.Dequeue();
                    continue;
                }

                tasks.Pop();
                threads.Dequeue();
            }

            Console.WriteLine($"Thread with value {threads.Peek()} killed task {taskToBeKilled}");
            Console.WriteLine(string.Join(' ', threads));
        }
    }
}
