using System;
using System.Collections.Generic;

namespace _1.CountCharsInAString
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> researchResult = new Dictionary<string, int>();

            string text = Console.ReadLine();
            Research(ref researchResult, text);

            PrintResult(ref researchResult);
        }

        private static void Research(ref Dictionary<string, int> researchResult, string text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];

                if (char.IsWhiteSpace(c))
                {
                    continue;
                }

                if (!researchResult.ContainsKey(c.ToString()))
                {
                    researchResult.Add(c.ToString(), 0);
                }

                researchResult[c.ToString()]++;
            }
        }

        private static void PrintResult(ref Dictionary<string, int> researchResult)
        {
            foreach (var character in researchResult)
            {
                Console.WriteLine($"{character.Key} -> {character.Value}");
            }
        }
    }
}
