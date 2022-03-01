using System;
using System.Collections.Generic;
using System.Linq;

namespace T02.StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            string command = Console.ReadLine().ToLower();
            while (command != "end")
            {
                string[] cmd = command.Split();
                if (cmd[0] == "add")
                {
                    stack.Push(int.Parse(cmd[1]));
                    stack.Push(int.Parse(cmd[2]));
                }
                else if (cmd[0] == "remove")
                {
                    int count = int.Parse(cmd[1]);
                    if (count <= stack.Count)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            stack.Pop();
                        }
                    }
                }

                command = Console.ReadLine().ToLower();
            }

            Console.WriteLine($"Sum: {stack.Sum()}");
        }
    }
}
