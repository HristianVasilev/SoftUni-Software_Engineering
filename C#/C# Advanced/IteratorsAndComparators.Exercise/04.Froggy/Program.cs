using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.Froggy
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] stones = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Lake lake = new Lake(stones);
            lake.OrderStones();

            string result = GetResult(lake);
            Console.WriteLine(result);
        }

        private static string GetResult(Lake lake)
        {
            List<int> res = new List<int>();

            foreach (var stone in lake)
            {
                res.Add(stone);
            }

            return string.Join(", ", res);
        }
    }
}
