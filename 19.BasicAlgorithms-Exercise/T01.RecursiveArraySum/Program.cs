using System;
using System.Linq;

namespace T01.RecursiveArraySum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Console.WriteLine(ArraySum(array, 0));
        }

        public static int ArraySum(int[] array, int index)
        {
            if (index == array.Length)
            {
                return 0;
            }

            return array[index] + ArraySum(array, index + 1);
        }
    }
}
