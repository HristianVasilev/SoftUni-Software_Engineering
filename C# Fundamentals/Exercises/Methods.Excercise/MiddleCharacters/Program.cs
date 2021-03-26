using System;

namespace MiddleCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            string c = GetMiddleCharacter(word);
            Console.WriteLine(c);
        }

        private static string GetMiddleCharacter(string word)
        {
            if (word.Length % 2 == 0)
            {
                return $"{word[word.Length / 2 - 1]}{word[word.Length / 2]}";
            }

            return $"{word[word.Length / 2]}";
        }
    }
}
