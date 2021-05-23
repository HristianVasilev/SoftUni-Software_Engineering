using System;
using System.Linq;

namespace _05._1.PrintEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                 .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();

            int[] filteredNumbers = input.Where(x => x % 2 == 0).ToArray();

            string result = string.Join(", ", filteredNumbers);
            Console.WriteLine(result);
        }
    }
}
