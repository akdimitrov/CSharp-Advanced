using System;
using System.Collections.Generic;
using System.Linq;

namespace T01.Blacksmith
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> steel = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            Stack<int> carbon = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            SortedDictionary<string, int> swords = new SortedDictionary<string, int>();

            while (steel.Any() && carbon.Any())
            {
                int steelValue = steel.Dequeue();
                int carbonValue = carbon.Pop();
                string sword = string.Empty;
                switch (steelValue + carbonValue)
                {
                    case 70: sword = "Gladius"; break;
                    case 80: sword = "Shamshir"; break;
                    case 90: sword = "Katana"; break;
                    case 110: sword = "Sabre"; break;
                    case 150: sword = "Broadsword"; break;
                }

                if (sword == string.Empty)
                {
                    carbon.Push(carbonValue + 5);
                    continue;
                }

                if (!swords.ContainsKey(sword))
                {
                    swords[sword] = 0;
                }
                swords[sword]++;
            }

            Console.WriteLine(swords.Any() ? $"You have forged {swords.Sum(x => x.Value)} swords."
                : "You did not have enough resources to forge a sword.");
            Console.WriteLine("Steel left: {0}", !steel.Any() ? "none" : string.Join(", ", steel));
            Console.WriteLine("Carbon left: {0}", !carbon.Any() ? "none" : string.Join(", ", carbon));
            Console.WriteLine(string.Join(Environment.NewLine, swords.Select(x => $"{x.Key}: {x.Value}")));
        }
    }
}
