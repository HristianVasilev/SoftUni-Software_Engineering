using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.RemoveNegativesAndReverse
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> sequenceOfNumbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            List<int> output = sequenceOfNumbers.Where(x => x > 0).Reverse().ToList();

            if (output.Count > 0)
            {
                Console.WriteLine(string.Join(' ', output));
            }
            else
            {
                Console.WriteLine("empty");
            }
        }
    }
}
