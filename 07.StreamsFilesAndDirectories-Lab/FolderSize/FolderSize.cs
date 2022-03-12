namespace FolderSize
{
    using System;
    using System.IO;
    public class FolderSize
    {
        static void Main(string[] args)
        {
            string folderPath = @"..\..\..\Files\TestFolder";
            string outputPath = @"..\..\..\Files\output.txt";

            GetFolderSize(folderPath, outputPath);
        }

        public static void GetFolderSize(string folderPath, string outputFilePath)
        {
            double totalSize = 0;
            var dirInfo = new DirectoryInfo(folderPath);
            var files = dirInfo.GetFiles();
            foreach (var file in files)
            {
                totalSize += file.Length / 1024.0;
            }

            var dirs = dirInfo.GetDirectories();
            foreach (var dir in dirs)
            {
                var currentInfo = new DirectoryInfo(dir.ToString());
                var currentFiles = currentInfo.GetFiles();
                foreach (var file in currentFiles)
                {
                    totalSize += file.Length / 1024.0;
                }
            }

            string result = $"{totalSize} KB";
            File.WriteAllText(outputFilePath, result);
        }
    }
}
