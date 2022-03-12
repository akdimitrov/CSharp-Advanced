namespace SplitMergeBinaryFile
{
    using System;
    using System.IO;
    using System.Linq;

    public class SplitMergeBinaryFile
    {
        static void Main(string[] args)
        {
            string sourceFilePath = @"..\..\..\Files\example.png";
            string joinedFilePath = @"..\..\..\Files\example-joined.png";
            string partOnePath = @"..\..\..\Files\part-1.bin";
            string partTwoPath = @"..\..\..\Files\part-2.bin";

            SplitBinaryFile(sourceFilePath, partOnePath, partTwoPath);
            MergeBinaryFiles(partOnePath, partTwoPath, joinedFilePath);
        }

        public static void SplitBinaryFile(string sourceFilePath, string partOneFilePath, string partTwoFilePath)
        {
            using (FileStream stream = new FileStream(sourceFilePath, FileMode.Open))
            {
                long file1Length = stream.Length / 2 + stream.Length % 2;
                long file2Length = stream.Length / 2;


                using (FileStream newFile = new FileStream(partOneFilePath, FileMode.Create))
                {
                    var data = new byte[file1Length];
                    stream.Read(data, 0, data.Length);
                    newFile.Write(data, 0, data.Length);
                }
                using (FileStream newFile = new FileStream(partTwoFilePath, FileMode.Create))
                {
                    var data = new byte[file2Length];
                    stream.Read(data, 0, data.Length);
                    newFile.Write(data, 0, data.Length);
                }
            }
        }

        public static void MergeBinaryFiles(string partOneFilePath, string partTwoFilePath, string joinedFilePath)
        {
            using FileStream stream1 = new FileStream(partOneFilePath, FileMode.Open);
            using FileStream stream2 = new FileStream(partTwoFilePath, FileMode.Open);
            using FileStream newFile = new FileStream(joinedFilePath, FileMode.Create);

            var data = new byte[stream1.Length];
            stream1.Read(data, 0, data.Length);
            newFile.Write(data, 0, data.Length);

            data = new byte[stream2.Length];
            stream2.Read(data, 0, data.Length);
            newFile.Write(data, 0, data.Length);
        }
    }
}