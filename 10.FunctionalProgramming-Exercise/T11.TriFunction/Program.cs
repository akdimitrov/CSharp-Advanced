using System;
using System.Linq;

namespace T11.TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int, bool> checkName = (name, sum) => name.Sum(x => x) >= sum;
            Func<string[], int, Func<string, int, bool>, string> findFirstName = GetName;

            int targetSum = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split();


            Console.WriteLine(findFirstName(names, targetSum, checkName));
        }

        private static string GetName(string[] names, int sum, Func<string, int, bool> func)
        {
            return names.Where(x => func(x, sum)).FirstOrDefault();
        }
    }
}
