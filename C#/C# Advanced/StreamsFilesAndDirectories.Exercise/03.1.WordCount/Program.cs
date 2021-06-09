using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace _03._1.WordCount
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Dictionary<string, int> wordOccurrences = await ReadWordsFile();

            string[] textWords = await ReadTextFile();

            AnalyzeText(ref wordOccurrences, textWords);

            WriteResult(wordOccurrences);
        }

        private static async Task WriteResult(Dictionary<string, int> wordOccurrences)
        {
            var result = wordOccurrences.Select(x => $"{x.Key} - {x.Value}");

            await File.WriteAllLinesAsync("./actualResult.txt", result);
        }

        private static void AnalyzeText(ref Dictionary<string, int> wordOccurrences, string[] textWords)
        {
            foreach (var word in textWords)
            {
                if (!wordOccurrences.ContainsKey(word))
                {
                    continue;
                }

                wordOccurrences[word]++;
            }
        }

        private static async Task<string[]> ReadTextFile()
        {
            string[] textLines = await File.ReadAllLinesAsync("./text.txt");

            List<string> wordsArray = new List<string>();

            for (int i = 0; i < textLines.Length; i++)
            {
                string line = textLines[i];

                string[] lineWordsArray = line
                   .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                   .Select(w => w.ToLower())
                   .ToArray();

                for (int j = 0; j < lineWordsArray.Length; j++)
                {
                    if (lineWordsArray[j].Any(c => char.IsPunctuation(c)))
                    {
                        lineWordsArray[j] = RemovePunctuationFromStartAndEnd(lineWordsArray[j]);
                    }

                    wordsArray.Add(lineWordsArray[j]);
                }
            }

            return wordsArray.ToArray();
        }

        private static string RemovePunctuationFromStartAndEnd(string word)
        {
            while (char.IsPunctuation(word[0]))
            {
                word = word.Remove(0, 1);
            }

            while (char.IsPunctuation(word[word.Length - 1]))
            {
                word = word.Remove(word.Length - 1, 1);
            }

            return word;
        }

        private static async Task<Dictionary<string, int>> ReadWordsFile()
        {
            Dictionary<string, int> wordOccurrences = new Dictionary<string, int>();

            string[] words = await File.ReadAllLinesAsync("./words.txt");

            foreach (var word in words)
            {
                if (!wordOccurrences.ContainsKey(word))
                {
                    wordOccurrences.Add(word, 0);
                }
            }

            return wordOccurrences;
        }
    }
}
