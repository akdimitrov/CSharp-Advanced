using System;
using System.Collections.Generic;
using System.Linq;

namespace T01.TheFightForGondor
{
    class Program
    {
        static void Main(string[] args)
        {
            int waves = int.Parse(Console.ReadLine());
            Queue<int> plates = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            Stack<int> orcs = new Stack<int>();
            for (int i = 1; i <= waves; i++)
            {
                int[] inputOrcs = Console.ReadLine().Split().Select(int.Parse).ToArray();
                if (i % 3 == 0)
                {
                    plates.Enqueue(int.Parse(Console.ReadLine()));
                }

                foreach (var orc in inputOrcs)
                {
                    orcs.Push(orc);
                }

                while (orcs.Any() && plates.Any())
                {
                    if (orcs.Peek() > plates.Peek())
                    {
                        orcs.Push(orcs.Pop() - plates.Dequeue());
                    }
                    else if (plates.Peek() > orcs.Peek())
                    {
                        plates.Enqueue(plates.Dequeue() - orcs.Pop());
                        for (int j = 0; j < plates.Count - 1; j++)
                        {
                            plates.Enqueue(plates.Dequeue());
                        }
                    }
                    else
                    {
                        plates.Dequeue();
                        orcs.Pop();
                    }
                }

                if (!plates.Any())
                {
                    break;
                }
            }

            Console.WriteLine(plates.Any() ? $"The people successfully repulsed the orc's attack."
                : "The orcs successfully destroyed the Gondor's defense.");

            Console.WriteLine(plates.Any() ? $"Plates left: {string.Join(", ", plates)}"
                : $"Orcs left: {string.Join(", ", orcs)}");
        }
    }
}
