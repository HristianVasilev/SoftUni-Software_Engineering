using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Problem2.Mirror_words
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string pattern = @"(#|@)([A-Za-z]{3,})\1{2}([A-Za-z]{3,})\1";
            var collection = Regex.Matches(text, pattern);

            if (collection.Count == 0)
            {
                Console.WriteLine("No word pairs found!");
                Console.WriteLine("No mirror words!");
                return;
            }

            Console.WriteLine($"{collection.Count} word pairs found!");

            bool containsMirrorWords = ContainsMirrorWords(collection);

            if (!containsMirrorWords)
            {
                Console.WriteLine("No mirror words!");
                return;
            }

            List<string> mirrorWords = GetAllMirrorWords(collection);

            Console.WriteLine("The mirror words are:");
            Console.WriteLine(string.Join(", ", mirrorWords));
        }

        private static List<string> GetAllMirrorWords(MatchCollection collection)
        {
            List<string> mirrorWords = new List<string>();

            foreach (Match match in collection)
            {
                string leftWord = match.Groups[2].Value;
                string rightWord = match.Groups[3].Value;
                string rightWordReversed = string.Join(string.Empty, rightWord.Reverse());

                if (leftWord == rightWordReversed)
                {
                    mirrorWords.Add($"{leftWord} <=> {rightWord}");
                }
            }

            return mirrorWords;
        }

        private static bool ContainsMirrorWords(MatchCollection collection)
        {
            foreach (Match match in collection)
            {
                string leftWord = match.Groups[2].Value;
                string rightWordReversed = string.Join(string.Empty, match.Groups[3].Value.Reverse());

                if (leftWord == rightWordReversed)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
