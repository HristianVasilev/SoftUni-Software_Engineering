using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.WordCount
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Dictionary<string, int> wordsCount = new Dictionary<string, int>();

            await DefineWordsForAnalyzing(wordsCount);

            List<string> text = await ReadText();

            string output = GetOutput(text, wordsCount);

            await WriteOutput(output);
        }

        private static async Task WriteOutput(string output)
        {
            using (StreamWriter sw = new StreamWriter("Output.txt"))
            {
                await sw.WriteLineAsync(output);
            }
        }

        private static string GetOutput(List<string> text, Dictionary<string, int> wordsCount)
        {
            foreach (var textLine in text)
            {
                string[] textWords = textLine.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                foreach (var word in textWords)
                {
                    string currentWord = FormatWord(word);

                    if (wordsCount.ContainsKey(currentWord))
                    {
                        wordsCount[currentWord]++;
                    }
                }
            }

            StringBuilder sb = new StringBuilder();
            foreach (var kvp in wordsCount.OrderByDescending(x => x.Value))
            {
                sb.AppendLine($"{kvp.Key} - {kvp.Value}");
            }

            return sb.ToString().TrimEnd();
        }

        private static string FormatWord(string word)
        {
            char[] wordArray = word.ToLower().ToCharArray();

            return string.Join(string.Empty, wordArray.Where(c => char.IsLetter(c)));
        }

        private static async Task<List<string>> ReadText()
        {
            List<string> text = new List<string>();
            using (StreamReader sr = new StreamReader("text.txt"))
            {
                string textLine;

                while ((textLine = await sr.ReadLineAsync()) != null)
                {
                    text.Add(textLine);
                }

            }

            return text;
        }

        private static async Task DefineWordsForAnalyzing(Dictionary<string, int> wordsCount)
        {
            using (StreamReader sr = new StreamReader("words.txt"))
            {
                string allwords = await sr.ReadToEndAsync();
                string[] words = allwords.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                foreach (var word in words)
                {
                    if (!wordsCount.ContainsKey(word))
                    {
                        wordsCount.Add(word, 0);
                    }
                }
            }
        }
    }
}
