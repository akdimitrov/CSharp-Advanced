using System;
using System.Collections.Generic;
using System.Linq;

namespace T13.InfernoIII
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> gems = Console.ReadLine().Split().Select(int.Parse).ToList();
            Dictionary<string, Predicate<int>> filters = new Dictionary<string, Predicate<int>>();

            string command = Console.ReadLine();
            while (command != "Forge")
            {
                string[] cmd = command.Split(";", StringSplitOptions.RemoveEmptyEntries);
                string action = cmd[0];
                string type = cmd[1];
                int value = int.Parse(cmd[2]);

                if (action == "Exclude")
                {
                    filters[type + value] = GetFilter(gems, type, value);
                }
                else if (action == "Reverse")
                {
                    filters.Remove(type + value);
                }

                command = Console.ReadLine();
            }

            foreach (var filter in filters)
            {
                gems = gems.Where(x => !filter.Value(x)).ToList();
            }

            Console.WriteLine(string.Join(" ", gems));
        }

        private static Predicate<int> GetFilter(List<int> gems, string type, int value)
        {
            return x => GetSum(x, gems, type) == value;
        }

        static int GetSum(int num, List<int> list, string direction)
        {
            int index = list.IndexOf(num);
            int leftNum = index - 1 < 0 ? 0 : list[index - 1];
            int rightNum = index + 1 > list.Count - 1 ? 0 : list[index + 1];

            if (direction == "Sum Left")
            {
                return num + leftNum;
            }
            else if (direction == "Sum Right")
            {
                return num + rightNum;
            }

            return num + leftNum + rightNum;
        }
    }
}
