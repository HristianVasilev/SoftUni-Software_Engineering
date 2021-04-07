using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.OddOccurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> statistic = new Dictionary<string, int>();

            string[] elements = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in elements)
            {
                string element = item.ToLower();

                if (!statistic.ContainsKey(element))
                {
                    statistic.Add(element, 0);
                }

                statistic[element]++;
            }

            var collection = statistic.Where(v => v.Value % 2 != 0).Select(kvp => kvp.Key).ToList();

            Console.WriteLine(string.Join(" ", collection));
        }
    }
}
