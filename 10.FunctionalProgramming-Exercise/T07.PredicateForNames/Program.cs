using System;
using System.Collections.Generic;
using System.Linq;

namespace T07.PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int, bool> isValid = (name, length) => name.Length <= length;
            int n = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine().Split().Where(x => isValid(x, n)).ToList();
            names.ForEach(Console.WriteLine);
        }
    }
}
