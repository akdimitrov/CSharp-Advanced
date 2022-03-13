using System;
using System.Collections.Generic;
using System.Linq;

namespace T02.KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<List<string>> appendNames = x => Console.WriteLine
            (string.Join(Environment.NewLine, x.Select(x => $"Sir {x}")));
            List<string> names = Console.ReadLine().Split().ToList();
            appendNames(names);
        }
    }
}
