using System;
using System.Collections.Generic;
using System.Linq;

namespace SumOfCoins
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<int> coins = Console.ReadLine().Split(", ").Select(int.Parse).OrderByDescending(x => x).ToList();
            int targetSum = int.Parse(Console.ReadLine());

            try
            {
                var foundCoins = ChooseCoins(coins, targetSum);
                Console.WriteLine($"Number of coins to take: {foundCoins.Sum(x => x.Value)}");
                foreach (var coin in foundCoins)
                {
                    Console.WriteLine($"{coin.Value} coin(s) with value {coin.Key}");
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }

        public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
        {
            Dictionary<int, int> coinPairs = new Dictionary<int, int>();

            for (int i = 0; i < coins.Count; i++)
            {
                int count = targetSum / coins[i];

                if (count == 0)
                {
                    continue;
                }

                targetSum -= count * coins[i];
                coinPairs[coins[i]] = count;

                if (targetSum == 0)
                {
                    return coinPairs;
                }
            }

            throw new InvalidOperationException("Error");
        }
    }
}
