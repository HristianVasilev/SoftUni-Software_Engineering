using System;
using System.Collections.Generic;

namespace _3.WordSynonyms
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();

            byte countOfWords = byte.Parse(Console.ReadLine());

            for (byte i = 0; i < countOfWords; i++)
            {
                string word = Console.ReadLine();
                string synonym = Console.ReadLine();

                AddToDictionary(word, synonym, ref dictionary);
            }

            PrintDictionary(ref dictionary);
        }

        private static void PrintDictionary(ref Dictionary<string, List<string>> dictionary)
        {
            foreach (var word in dictionary)
            {
                Console.WriteLine($"{word.Key} - {string.Join(", ",word.Value)}");
            }
        }

        private static void AddToDictionary(string word, string synonym, ref Dictionary<string, List<string>> dictionary)
        {
            if (!dictionary.ContainsKey(word))
            {
                dictionary.Add(word, new List<string>());
            }

            if (!dictionary[word].Contains(synonym))
            {
                dictionary[word].Add(synonym);
            }
        }
    }
}
