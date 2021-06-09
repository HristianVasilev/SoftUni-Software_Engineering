using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace _03.WordCount
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Dictionary<string, int> words = new Dictionary<string, int>();

            words = await ReadWords(words);

            string text = File.ReadAllText("text.txt");
            text = text.Replace(Environment.NewLine, " ");

            string[] textArray = text
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(w => w.ToLower())
                .Select(w => string.Join(string.Empty, w.Where(c => char.IsLetter(c))))
                .ToArray();

            MakeWordsStats(ref words, textArray);

            await WriteResult(words);

            string actualResult = File.ReadAllText("actualResult.txt");
            string expectedResult = File.ReadAllText("expectedResult.txt");

            bool areEqual = actualResult == expectedResult;
            Console.WriteLine(areEqual);
        }

        private static async Task WriteResult(Dictionary<string, int> words)
        {
            using (TextWriter tw = new StreamWriter("actualResult.txt"))
            {
                foreach (var word in words)
                {
                    await tw.WriteLineAsync($"{word.Key} - {word.Value}");
                }
            }
        }

        private static void MakeWordsStats(ref Dictionary<string, int> words, string[] textArray)
        {
            foreach (var textWord in textArray)
            {
                if (!words.ContainsKey(textWord))
                {
                    continue;
                }

                words[textWord]++;
            }
        }

        private static async Task<Dictionary<string, int>> ReadWords(Dictionary<string, int> words)
        {
            using (StreamReader sr = new StreamReader("words.txt"))
            {
                string word;
                while ((word = await sr.ReadLineAsync()) != null)
                {
                    if (!words.ContainsKey(word))
                    {
                        words.Add(word, 0);
                    }
                }
            }

            return words;
        }
    }
}
