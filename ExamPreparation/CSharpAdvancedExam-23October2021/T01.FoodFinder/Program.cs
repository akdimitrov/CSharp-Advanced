using System;
using System.Collections.Generic;
using System.Linq;

namespace T01.FoodFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<char> vowels = new Queue<char>(Console.ReadLine().Replace(" ", ""));
            Stack<char> consonants = new Stack<char>(Console.ReadLine().Replace(" ", ""));
            List<string> words = new List<string>() { "pear", "flour", "pork", "olive" };
            string allLetters = string.Join("", words);
            string foundLetters = string.Empty;

            while (consonants.Any())
            {
                char vowel = vowels.Peek();
                char consonant = consonants.Pop();
                vowels.Enqueue(vowels.Dequeue());

                if (allLetters.Contains(vowel) && !foundLetters.Contains(vowel))
                {
                    foundLetters += vowel;
                }
                if (allLetters.Contains(consonant))
                {
                    foundLetters += consonant;
                }
            }

            for (int i = 0; i < words.Count; i++)
            {
                string word = words[i];
                for (int j = 0; j < word.Length; j++)
                {
                    if (!foundLetters.Contains(word[j]))
                    {
                        words.RemoveAt(i--);
                        break;
                    }
                }
            }

            Console.WriteLine($"Words found: {words.Count}");
            words.ForEach(Console.WriteLine);
        }
    }
}
