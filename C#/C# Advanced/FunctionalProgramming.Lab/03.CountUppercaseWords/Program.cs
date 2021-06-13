using System;
using System.Linq;

namespace _03.CountUppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Where(w => char.IsUpper(w.First()))
                .ToArray();

            Console.WriteLine(string.Join(Environment.NewLine, words));
        }
    }
}
