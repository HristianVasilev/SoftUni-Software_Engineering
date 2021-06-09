using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace _01.EvenLines
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (StreamReader sr = new StreamReader("text.txt"))
            {
                byte counter = 0;
                string line;
                while ((line = await sr.ReadLineAsync()) != null)
                {
                    if (counter++ % 2 != 0)
                    {
                        continue;
                    }

                    char[] symbolsToReplace = new char[] { '-', ',', '.', '!', '?' };
                    line = ReplaceSymbols(line, symbolsToReplace);

                    string[] currentLineArray = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    Array.Reverse(currentLineArray);
                    Console.WriteLine(string.Join(' ', currentLineArray));
                }
            }
        }

        private static string ReplaceSymbols(string line, char[] symbols)
        {
            foreach (var symbol in symbols)
            {
                line = line.Replace(symbol, '@');
            }

            return line;
        }
    }
}
