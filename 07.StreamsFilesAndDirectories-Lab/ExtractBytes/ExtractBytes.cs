namespace ExtractBytes
{
    using System;
    using System.IO;
    using System.Linq;

    public class ExtractBytes
    {
        static void Main(string[] args)
        {
            string binaryFilePath = @"..\..\..\Files\example.png";
            string bytesFilePath = @"..\..\..\Files\bytes.txt";
            string outputPath = @"..\..\..\Files\output.bin";

            ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputPath);
        }

        public static void ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputPath)
        {
            byte[] binaryFileBytes = File.ReadAllBytes(binaryFilePath);
            byte[] bytes = File.ReadAllBytes(bytesFilePath);

            using (StreamWriter writer = new StreamWriter(outputPath))
            {
                foreach (var item in binaryFileBytes)
                {
                    if (bytes.Contains(item))
                    {
                        writer.WriteLine(item);
                    }
                }
            }
        }
    }
}
