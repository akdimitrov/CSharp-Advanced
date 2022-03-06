using System;
using System.Linq;

namespace T08.GroupNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[][] matrix = new int[3][];
            for (int i = 0; i < 3; i++)
            {
                matrix[i] = numbers.Where(x => x % 3 == i || x % 3 == -i).ToArray();
            }

            foreach (var item in matrix)
            {
                Console.WriteLine(string.Join(" ", item));
            }
        }
    }
}
