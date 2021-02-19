using System;


namespace _1.RandomizeWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Random rnd = new Random();

            int wordsCount = words.Length;
            while (wordsCount > 1)
            {
                int randomPosition = rnd.Next(wordsCount - 1);
                string valueOfRamdomPosition = words[randomPosition];
                words[randomPosition] = words[wordsCount - 1];
                words[wordsCount - 1] = valueOfRamdomPosition;
                wordsCount--;
            }

            foreach (var item in words)
            {
                Console.WriteLine(item);
            }
        }
    }
}
