using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace _02.LineNumbers
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (StreamReader sr = new StreamReader("text.txt"))
            {
                using (StreamWriter sw = new StreamWriter("output.txt"))
                {
                    int counter = 1;
                    string line;

                    while ((line = await sr.ReadLineAsync()) != null)
                    {
                        int countOfLetters = line.ToCharArray().Where(x => char.IsLetter(x)).Count();
                        int countOfPuncMarks = line.ToCharArray().Where(x => char.IsPunctuation(x)).Count();

                        await sw.WriteLineAsync($"Line {counter++}: {line} ({countOfLetters})({countOfPuncMarks})");
                    }
                }
            }
        }
    }
}
