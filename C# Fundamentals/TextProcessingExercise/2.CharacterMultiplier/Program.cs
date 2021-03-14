using System;

namespace _2.CharacterMultiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] strings = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string str1 = strings[0];
            string str2 = strings[1];

            Multiply(str1, str2);



        }

        private static void Multiply(string str1, string str2)
        {
            int i = 0;
            int maxLength = Math.Max(str1.Length, str2.Length);

            int totalSum = 0;

            while (i < maxLength)
            {
                int currentResult = 0;

                if (!ValidIndex(i, str1))
                {
                    totalSum += str2[i];
                }
                else if (!ValidIndex(i, str2))
                {
                    totalSum += str1[i];
                }
                else
                {
                    currentResult = str1[i] * str2[i];
                }

                totalSum += currentResult;
                i++;
            }

            Console.WriteLine(totalSum);
        }

        private static bool ValidIndex(int i, string str)
        {
            return i >= 0 && i < str.Length;
        }
    }
}
