using System;
using System.Collections.Generic;

namespace T05.CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<char, int> letters = new SortedDictionary<char, int>();
            string text = Console.ReadLine();
            foreach (var ch in text)
            {
                if (!letters.ContainsKey(ch))
                {
                    letters[ch] = 0;
                }
                letters[ch]++;
            }

            foreach (var letter in letters)
            {
                Console.WriteLine($"{letter.Key}: {letter.Value} time/s");
            }
        }
    }
}
