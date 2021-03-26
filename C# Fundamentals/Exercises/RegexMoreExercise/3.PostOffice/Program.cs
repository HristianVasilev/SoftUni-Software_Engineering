using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _3.PostOffice
{
    class Program
    {

        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries);

            char[] capitalLetters = FirstPart(input[0]);

            List<string> criteries = Criteries(input[1], capitalLetters);

            HashSet<string> words = FindWords(input[2], criteries);

            string result = string.Join(Environment.NewLine, words);
            Console.WriteLine(result);
        }


        private static char[] FirstPart(string input)
        {
            string pattern = @"([#$%*&])(?<capitalLetters>[A-Z]+)\1";

            char[] capitalLetters = Regex.Match(input, pattern).Groups["capitalLetters"].Value.ToCharArray();

            return capitalLetters;
        }

        private static List<string> Criteries(string input, char[] capitalLetters)
        {
            List<string> matches = new List<string>();

            for (int i = 0; i < capitalLetters.Length; i++)
            {
                int current = capitalLetters[i];

                string pattern = $"(?<!\\d){current}:\\d{{2}}(?!\\d)";
                IEnumerable<string> collection = Regex.Matches(input, pattern).Select(x => x.Value);

                matches.AddRange(collection);
            }

            return matches;
        }

        private static HashSet<string> FindWords(string input, List<string> criteries)
        {
            HashSet<string> words = new HashSet<string>();

            foreach (var criteria in criteries)
            {
                string[] tokens = criteria.Split(':', StringSplitOptions.RemoveEmptyEntries);

                char startLetter = (char)int.Parse(tokens[0]);
                int countOfSymbols = int.Parse(tokens[1]);

                string pattern = $"(?<=\\s|^)[{startLetter}]\\S{{{countOfSymbols}}}(?=\\s|$)";

                IEnumerable<string> matches = Regex.Matches(input, pattern).Select(x => x.Value);

                AddWords(matches, ref words);
            }

            return words;
        }


        private static void AddWords(IEnumerable<string> matches, ref HashSet<string> words)
        {
            foreach (var word in matches)
            {
                words.Add(word);
            }
        }
    }
}
