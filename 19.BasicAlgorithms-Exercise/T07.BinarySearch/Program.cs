using System;
using System.Linq;

namespace T07.BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine(BinarySearch(array, number, 0, array.Length));
        }

        static int BinarySearch(int[] array, int number, int start, int end)
        {
            int middle = (start + end) / 2;
            if (start > end || middle >= array.Length)
            {
                return -1;
            }

            if (number < array[middle])
            {
                return BinarySearch(array, number, start, middle - 1);
            }
            else if (number > array[middle])
            {
                return BinarySearch(array, number, middle + 1, end);
            }

            return middle;
        }
    }
}
