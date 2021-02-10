using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.GaussTrick
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            for (int i = 0; i < numbers.Count / 2; i++)
            {
                numbers[i] += numbers[numbers.Count - i - 1];
            }

            for (int i = 0; i < numbers.Count / 2; i++)
            {
                Console.Write($"{numbers[i]} ");
            }

            if (numbers.Count % 2 != 0)
            {
                Console.Write(numbers[numbers.Count / 2]);
            }
        }
    }
}
