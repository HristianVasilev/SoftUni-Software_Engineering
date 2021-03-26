using System;

namespace _3.Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string stringForRemove = Console.ReadLine();

            string word = Console.ReadLine();

            while (word.Contains(stringForRemove.ToLower()))
            {
                word = word.Replace(stringForRemove.ToLower(), "");
            }

            Console.WriteLine(word);
        }
    }
}
