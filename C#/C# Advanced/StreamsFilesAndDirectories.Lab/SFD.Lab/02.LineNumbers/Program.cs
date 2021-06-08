using System;
using System.IO;
using System.Threading.Tasks;

namespace _02.LineNumbers
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (StreamReader sr = new StreamReader("Input.txt"))
            {
                string line;
                using (StreamWriter sw = new StreamWriter("Output.txt"))
                {
                    int counter = 1;
                    while ((line = await sr.ReadLineAsync()) != null)
                    {
                        await sw.WriteLineAsync($"{counter++}. {line}");
                    }
                }
            }
        }
    }
}
