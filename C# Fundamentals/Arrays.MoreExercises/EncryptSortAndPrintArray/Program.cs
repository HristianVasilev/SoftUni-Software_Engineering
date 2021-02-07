using System;
using System.Linq;

namespace EncryptSortAndPrintArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[] sumsOfWords = new int[rows];

            for (int i = 0; i < rows; i++)
            {
                string word = Console.ReadLine();

                int sum = StringEncryptOperations(word);
                sumsOfWords[i] = sum;
            }

            sumsOfWords = sumsOfWords.OrderBy(x => x).ToArray();
            Console.WriteLine(string.Join(Environment.NewLine, sumsOfWords));
        }

        private static int StringEncryptOperations(string word)
        {
            int sum = 0;

            for (int j = 0; j < word.Length; j++)
            {
                char c = word[j];

                if (IsVowel(c))
                {
                    sum += c * word.Length;
                }
                else
                {
                    sum += c / word.Length;
                }
            }

            return sum;
        }

        private static bool IsVowel(char c)
        {
            return
                c == 65 || c == 69 || c == 73 || c == 79 || c == 85 ||
                c == 97 || c == 101 || c == 105 || c == 111 || c == 117;
        }

    }
}
