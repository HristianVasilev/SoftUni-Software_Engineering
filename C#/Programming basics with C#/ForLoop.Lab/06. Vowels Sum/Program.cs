using System;
using System.Collections.Generic;

namespace _06._Vowels_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, int> vowels = new Dictionary<char, int>();

            vowels.Add('a', 1);
            vowels.Add('e', 2);
            vowels.Add('i', 3);
            vowels.Add('o', 4);
            vowels.Add('u', 5);

            string input = Console.ReadLine();
            int sum = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (vowels.ContainsKey(input[i]))
                {
                    sum += vowels[input[i]];
                }
            }
            Console.WriteLine(sum);
        }
    }
}
