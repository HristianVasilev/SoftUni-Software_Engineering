using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace _05.DirectoryTraversal
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Dictionary<string, List<FileInfo>> filesByExtension = new Dictionary<string, List<FileInfo>>();

            string path = Console.ReadLine();

            string[] files = Directory.GetFiles(path);

            foreach (var file in files)
            {
                FileInfo info = new FileInfo(file);
                string extension = info.Extension;

                if (!filesByExtension.ContainsKey(extension))
                {
                    filesByExtension.Add(extension, new List<FileInfo>());
                }

                filesByExtension[extension].Add(info);
            }

            using (StreamWriter writer = new StreamWriter
                (Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/report.txt"))
            {
                foreach (KeyValuePair<string, List<FileInfo>> kvp in filesByExtension.OrderByDescending(v => v.Value.Count)
                                                                                     .ThenBy(k => k.Key))
                {
                    await writer.WriteLineAsync(kvp.Key);

                    foreach (var fileInfo in kvp.Value.OrderBy(x => Math.Ceiling((decimal)x.Length / 1024)))
                    {
                        await writer.WriteLineAsync($"--{fileInfo.Name} - {(int)Math.Ceiling((decimal)fileInfo.Length / 1024)}kb");
                    }
                }
            }
        }
    }
}
