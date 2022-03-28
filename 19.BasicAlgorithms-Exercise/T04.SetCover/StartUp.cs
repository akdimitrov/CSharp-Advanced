using System;
using System.Collections.Generic;
using System.Linq;

namespace SetCover
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int[] universe = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int numberOfSets = int.Parse(Console.ReadLine());
            int[][] sets = new int[numberOfSets][];
            for (int i = 0; i < numberOfSets; i++)
            {
                sets[i] = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            }

            var selectedSets = ChooseSets(sets.ToList(), universe.ToList());
            Console.WriteLine($"Sets to take ({selectedSets.Count}):");
            foreach (var set in selectedSets)
            {
                Console.WriteLine($"{{ {string.Join(", ", set)} }}");
            }
        }

        public static List<int[]> ChooseSets(IList<int[]> sets, IList<int> universe)
        {
            List<int[]> selectedSets = new List<int[]>();
            while (universe.Any())
            {
                int[] currentSet = sets.OrderByDescending(s => s.Count(x => universe.Contains(x))).FirstOrDefault();
                selectedSets.Add(currentSet);
                foreach (var item in currentSet)
                {
                    universe.Remove(item);
                }
            }

            return selectedSets;
        }
    }
}
