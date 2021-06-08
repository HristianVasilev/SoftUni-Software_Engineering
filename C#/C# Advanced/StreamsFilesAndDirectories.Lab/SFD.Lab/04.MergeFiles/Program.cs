using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace _04.MergeFiles
{
    class Program
    {
        static async Task Main(string[] args)
        {
            List<int> fileOne = await ReadFileOne("FileOne.txt");
            List<int> fileTwo = await ReadFileOne("FileTwo.txt");
            List<int> mergedFile = MergeFiles(fileOne, fileTwo);

            using (StreamWriter sw = new StreamWriter("Output.txt"))
            {
                foreach (var item in mergedFile)
                {
                    await sw.WriteLineAsync(item.ToString());
                }
            }
        }

        private static List<int> MergeFiles(List<int> fileOne, List<int> fileTwo)
        {
            List<int> mergedFile = new List<int>();
            mergedFile.AddRange(fileOne);
            mergedFile.AddRange(fileTwo);

            return mergedFile.OrderBy(x => x).ToList();
        }

        private static async Task<List<int>> ReadFileOne(string path)
        {
            List<int> file;
            using (StreamReader sr = new StreamReader(path))
            {
                file = new List<int>();

                string line;
                while ((line = await sr.ReadLineAsync()) != null)
                {
                    file.Add(int.Parse(line));
                }
            }

            return file;
        }
    }
}
