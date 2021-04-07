using System;

namespace CharactersInRange
{
    class Program
    {
        static void Main(string[] args)
        {

            char c1 = char.Parse(Console.ReadLine());
            char c2 = char.Parse(Console.ReadLine());

            char startChar;
            char endChar;

            if (c1 < c2)
            {
                startChar = c1;
                endChar = c2;
            }
            else
            {
                startChar = c2;
                endChar = c1;
            }

            GetAllCharactersInRange(startChar, endChar);
        }

        private static void GetAllCharactersInRange(char startChar, char endChar)
        {
            for (int i = startChar + 1; i < endChar; i++)
            {
                Console.Write($"{(char)i} ");
            }
        }
    }
}
