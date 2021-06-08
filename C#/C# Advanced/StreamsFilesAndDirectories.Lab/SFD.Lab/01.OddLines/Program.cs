using System;
using System.IO;
using System.Threading.Tasks;

namespace _01.OddLines
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (StreamReader sr = new StreamReader("Input.txt"))
            {
                string line;
                int counter = 0;

                using (StreamWriter sw = new StreamWriter("Output.txt"))
                {
                    while ((line = await sr.ReadLineAsync()) != null)
                    {
                        if (counter++ % 2 != 0)
                        {
                            await sw.WriteLineAsync(line);
                        }
                    }
                }
            }
        }
    }
}
