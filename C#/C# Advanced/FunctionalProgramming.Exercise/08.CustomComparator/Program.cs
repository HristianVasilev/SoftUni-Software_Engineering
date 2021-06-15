using System;
using System.Linq;

namespace _08.CustomComparator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Comparison<int> comparison = (x, y) =>
            {
                int sorter = 0;

                if (x % 2 == 0 && y % 2 != 0)
                {
                    sorter = -1;
                }
                else if (x % 2 != 0 && y % 2 == 0)
                {
                    sorter = 1;
                }
                else
                {
                    sorter = x.CompareTo(y);
                }

                return sorter;
            };

            Array.Sort(array, comparison);

            Console.WriteLine(string.Join(' ', array));
        }
    }
}
