using System;
using System.Linq;
using System.Text;

namespace _6.ReplaceRepeatingChars
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            StringBuilder sb = new StringBuilder();

            sb.Append(word[0]);

            for (int i = 1; i < word.Length; i++)
            {
                if (word[i] == word[i - 1])
                {
                    continue;
                }

                sb.Append(word[i]);
            }

            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
}
