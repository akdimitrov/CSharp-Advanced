using System;
using System.Linq;

namespace T03.CountUppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Predicate<string> isStartingWithCapital = x => char.IsUpper(x[0]);
            Console.WriteLine(string.Join(Environment.NewLine, words.Where(x => isStartingWithCapital(x))));
        }
    }
}
