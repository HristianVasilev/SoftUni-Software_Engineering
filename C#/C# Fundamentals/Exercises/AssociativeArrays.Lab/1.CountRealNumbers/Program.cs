using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.CountRealNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Dictionary<int, int> stat = new Dictionary<int, int>();

            int[] distinctNumbers = numbers.Distinct().OrderBy(n => n).ToArray();

            foreach (int num in distinctNumbers)
            {
                stat.Add(num, numbers.Count(n => n.Equals(num)));
            }

            Print(ref stat);
        }

        private static void Print(ref Dictionary<int, int> stat)
        {
            foreach (var item in stat)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
