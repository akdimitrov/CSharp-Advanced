using System.IO;

namespace CopyBinaryFile
{
    public class CopyBinaryFile
    {
        static void Main(string[] args)
        {
            string inputPath = @"..\..\..\copyMe.png";
            string outputPath = @"..\..\..\copyMe-copy.png";

            CopyFile(inputPath, outputPath);
        }

        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
            using FileStream stream = new FileStream(inputFilePath, FileMode.Open);
            using FileStream copy = new FileStream(outputFilePath, FileMode.Create);
            var data = new byte[4096];
            while (true)
            {
                int currentBytes = stream.Read(data, 0, data.Length);
                if (currentBytes == 0)
                {
                    break;
                }
                copy.Write(data, 0, data.Length);
            }
        }
    }
}
