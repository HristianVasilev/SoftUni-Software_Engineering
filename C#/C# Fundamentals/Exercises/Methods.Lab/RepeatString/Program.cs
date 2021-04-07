using System;

namespace RepeatString
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            int count = int.Parse(Console.ReadLine());

            RepeatString(word, count);

        }

        private static void RepeatString(string word, int count)
        {
            for (int i = 0; i < count; i++)
            {
                Console.Write(word);
            }
        }
    }
}
