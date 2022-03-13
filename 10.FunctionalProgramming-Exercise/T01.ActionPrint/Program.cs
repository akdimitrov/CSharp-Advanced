using System;

namespace T01.ActionPrint
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string[]> printer = x => Console.WriteLine(string.Join(Environment.NewLine, x));
            string[] names = Console.ReadLine().Split();
            printer(names);
        }
    }
}
