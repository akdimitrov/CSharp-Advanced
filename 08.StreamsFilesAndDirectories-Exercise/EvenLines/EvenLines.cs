namespace EvenLines
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class EvenLines
    {
        static void Main(string[] args)
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            StringBuilder sb = new StringBuilder();
            using StreamReader reader = new StreamReader(inputFilePath);
            string line = reader.ReadLine();
            int counter = 0;
            while (line != null)
            {
                if (counter++ % 2 == 0)
                {
                    line = ReplaceSymbols(line);
                    sb.AppendLine(ReverseWords(line));
                }
                line = reader.ReadLine();
            }

            return sb.ToString().TrimEnd();
        }
        private static string ReverseWords(string replacedSymbols)
        {
            return string.Join(" ", replacedSymbols.Split().Reverse());
        }

        private static string ReplaceSymbols(string line)
        {
            char[] symbols = { '-', ',', '.', '!', '?' };
            foreach (var symbol in symbols)
            {
                line = line.Replace(symbol, '@');
            }
            return line;
        }
    }

}
