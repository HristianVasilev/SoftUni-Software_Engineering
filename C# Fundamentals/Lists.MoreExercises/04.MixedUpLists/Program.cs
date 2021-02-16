using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.MixedUpLists
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstList = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] secondList = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            List<int> result = new List<int>();

            sbyte firstCounter = 0;
            sbyte secondCounter = (sbyte)(secondList.Length - 1);

            while (secondCounter >= 0)
            {
                result.Add(firstList[firstCounter++]);

                result.Add(secondList[secondCounter--]);
            }

            var range = firstList.TakeLast(2).ToArray();

            int lowerLimit = range.Min();
            int higherLimit = range.Max();

            result = result.Where(x => x > lowerLimit && x < higherLimit).OrderBy(n => n).ToList();

            Console.WriteLine(string.Join(' ', result));
        }
    }
}
