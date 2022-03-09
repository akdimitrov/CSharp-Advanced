using System;
using System.Linq;

namespace T17.ParkingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[,] parking = new int[size[0], size[1]];
            string input = Console.ReadLine();
            while (input != "stop")
            {
                int[] cmd = input.Split().Select(int.Parse).ToArray();
                int entryRow = cmd[0];
                int row = cmd[1];
                int col = cmd[2];
                if (IsRowFree(parking, row))
                {
                    FindNearesParkingSpot(parking, row, ref col);
                    parking[row, col] = 1;
                    int distance = Math.Abs(row - entryRow) + col + 1;
                    Console.WriteLine(distance);
                }
                else
                {
                    Console.WriteLine($"Row {row} full");
                }

                input = Console.ReadLine();
            }
        }

        private static bool IsRowFree(int[,] parking, int row)
        {
            for (int col = 1; col < parking.GetLength(1); col++)
            {
                if (parking[row, col] == 0)
                {
                    return true;
                }
            }
            return false;
        }

        static void FindNearesParkingSpot(int[,] parking, int row, ref int column)
        {
            int left = -1;
            int right = -1;
            for (int col = column; col >= 1; col--)
            {
                if (parking[row, col] == 0)
                {
                    left = col;
                    break;
                }
            }

            for (int col = column; col < parking.GetLength(1); col++)
            {
                if (parking[row, col] == 0)
                {
                    right = col;
                    break;
                }
            }

            bool isRight = (right != -1 && left != -1 && column - left > right - column) || left == -1;
            column = isRight ? right : left;
        }
    }
}
