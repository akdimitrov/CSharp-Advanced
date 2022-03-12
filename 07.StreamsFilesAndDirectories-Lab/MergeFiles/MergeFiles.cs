namespace MergeFiles
{
    using System;
    using System.IO;
    public class MergeFiles
    {
        static void Main(string[] args)
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            string[] input1 = File.ReadAllLines(firstInputFilePath);
            string[] input2 = File.ReadAllLines(secondInputFilePath);

            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                for (int i = 0; i < Math.Max(input1.Length, input2.Length); i++)
                {
                    if (i < input1.Length)
                    {
                        writer.WriteLine(input1[i]);
                    }
                    if (i < input2.Length)
                    {
                        writer.WriteLine(input2[i]);
                    }
                }
            }
        }
    }
}
