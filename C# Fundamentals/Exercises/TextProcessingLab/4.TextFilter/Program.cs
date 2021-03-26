using System;
using System.Linq;

namespace _4.TextFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] remove = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            string text = Console.ReadLine();

            foreach (var word in remove)
            {
               text= text.Replace(word, new string('*', word.Length));
            }

            Console.WriteLine(text);
        }
    }
}
