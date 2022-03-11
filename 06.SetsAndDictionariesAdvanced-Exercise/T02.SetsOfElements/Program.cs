using System;
using System.Collections.Generic;
using System.Linq;

namespace T02.SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] setsLenght = Console.ReadLine().Split().Select(int.Parse).ToArray();
            HashSet<int> set1 = new HashSet<int>();
            HashSet<int> set2 = new HashSet<int>();
            for (int i = 0; i < setsLenght.Sum(); i++)
            {
                if (i < setsLenght[0])
                {
                    set1.Add(int.Parse(Console.ReadLine()));
                }
                else
                {
                    set2.Add(int.Parse(Console.ReadLine()));
                }
            }

            set1.IntersectWith(set2);
            Console.WriteLine(string.Join(" ", set1));
        }
    }
}
