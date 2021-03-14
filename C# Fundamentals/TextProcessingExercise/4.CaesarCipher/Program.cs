using System;
using System.Text;

namespace _4.CaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < word.Length; i++)
            {
                char currentChar = word[i];

                sb.Append((char)(currentChar + 3));
            }

            string shiftedWord = sb.ToString().TrimEnd();
            Console.WriteLine(shiftedWord);
        }
    }
}
