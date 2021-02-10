using System;

namespace VowelsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            int countOfVowels = GetCountOfVowels(word);
            Console.WriteLine(countOfVowels);
        }

        private static int GetCountOfVowels(string word)
        {
            int count = 0;
            for (int i = 0; i < word.Length; i++)
            {
                if (IsVowel(word[i]))
                {
                    count++;
                }
            }

            return count;
        }

        private static bool IsVowel(char c)
        {
            return c == 65 || c == 69 || c == 73 || c == 79 || c == 85
                || c == 97 || c == 101 || c == 105 || c == 111 || c == 117;
        }
    }
}
