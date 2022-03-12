namespace DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class DirectoryTraversal
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            var files = new Dictionary<string, Dictionary<string, double>>();
            StringBuilder sb = new StringBuilder();
            var dirInfo = new DirectoryInfo(inputFolderPath);
            var dirFiles = dirInfo.GetFiles();
            foreach (var file in dirFiles)
            {
                string name = file.Name;
                string extesion = file.Extension;
                double size = file.Length / 1024d;

                if (!files.ContainsKey(extesion))
                {
                    files[extesion] = new Dictionary<string, double>();
                }
                files[extesion][name] = size;
            }

            foreach (var extension in files.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                sb.AppendLine(extension.Key);
                foreach (var file in extension.Value.OrderBy(x => x.Value))
                {
                    sb.AppendLine($"--{file.Key} - {file.Value:f3}kb");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            string desktoPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + reportFileName;
            using StreamWriter writer = new StreamWriter(desktoPath);
            writer.WriteLine(textContent);
        }
    }
}
