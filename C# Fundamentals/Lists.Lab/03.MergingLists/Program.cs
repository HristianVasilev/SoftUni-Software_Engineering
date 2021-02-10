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

            List<int> minRow = GetMinRow(rowOne, rowTwo);
            List<int> maxRow = GetMaxRow(rowOne, rowTwo);

            List<int> result = new List<int>();

            for (int i = 0; i < minRow.Count; i++)
            {
                result.Add(minRow[i]);
                result.Add(maxRow[i]);
            }

            for (int i = minRow.Count; i < maxRow.Count; i++)
            {
                result.Add(maxRow[i]);
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
