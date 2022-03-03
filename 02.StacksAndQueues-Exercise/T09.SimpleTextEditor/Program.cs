using System;
using System.Collections.Generic;
using System.Text;

namespace T09.SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            StringBuilder text = new StringBuilder();
            Stack<string> stack = new Stack<string>();
            stack.Push(text.ToString());
            for (int i = 0; i < n; i++)
            {
                string[] cmd = Console.ReadLine().Split();
                if (cmd[0] == "1")
                {
                    text.Append(cmd[1]);
                    stack.Push(text.ToString());
                }
                else if (cmd[0] == "2")
                {
                    int count = int.Parse(cmd[1]);
                    text.Remove(text.Length - count, count);
                    stack.Push(text.ToString());
                }
                else if (cmd[0] == "3")
                {
                    int index = int.Parse(cmd[1]) - 1;
                    Console.WriteLine(text[index]);
                }
                else if (cmd[0] == "4")
                {
                    text.Clear();
                    stack.Pop();
                    text.Append(stack.Peek());
                }
            }
        }
    }
}
