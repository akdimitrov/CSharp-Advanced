using System;
using System.Collections.Generic;
using System.Linq;

namespace T06.Quicksort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Quicksort(array, 0, array.Length - 1);
            Console.WriteLine(string.Join(" ", array));
        }

        static void Quicksort(int[] array, int left, int right)
        {
            if (left >= right)
            {
                return;
            }

            var partitionIndex = Partition(array, left, right);
            Quicksort(array, left, partitionIndex);
            Quicksort(array, partitionIndex + 1, right);
        }

        static int Partition(int[] array, int left, int right)
        {
            int pivot = array[(left + right) / 2];
            int i = left - 1;
            int j = right + 1;
            while (true)
            {
                do
                {
                    i++;
                } while (array[i] < pivot);

                do
                {
                    j--;
                } while (array[j] > pivot);

                if (i >= j)
                {
                    return j;
                }

                var temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }
    }
}
