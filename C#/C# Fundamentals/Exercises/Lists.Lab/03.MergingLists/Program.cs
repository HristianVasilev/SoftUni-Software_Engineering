using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MergingLists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> rowOne = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            List<int> rowTwo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            List<int> result = new List<int>();

            int i = 0;
            int j = 0;

            while (i < rowOne.Count  || j < rowTwo.Count )
            {
                if (i < rowOne.Count)
                {
                    result.Add(rowOne[i++]);
                }

                if (j < rowTwo.Count)
                {
                    result.Add(rowTwo[j++]);
                }
            }

            Console.WriteLine(string.Join(' ', result));
        }

        private static List<int> GetMaxRow(List<int> rowOne, List<int> rowTwo)
        {
            if (rowOne.Count > rowTwo.Count)
            {
                return rowOne;
            }

            return rowTwo;
        }

        private static List<int> GetMinRow(List<int> rowOne, List<int> rowTwo)
        {
            if (rowOne.Count <= rowTwo.Count)
            {
                return rowOne;
            }

            return rowTwo;
        }
    }
}
