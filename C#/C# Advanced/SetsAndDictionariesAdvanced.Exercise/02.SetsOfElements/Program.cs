using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int n = tokens[0];
            int m = tokens[1];

            HashSet<int> setA = new HashSet<int>();
            HashSet<int> setB = new HashSet<int>();

            for (int i = 0; i < n; i++)
            {
                setA.Add(int.Parse(Console.ReadLine()));
            }

            for (int i = 0; i < m; i++)
            {
                setB.Add(int.Parse(Console.ReadLine()));
            }

            setA.IntersectWith(setB);

            Console.WriteLine(string.Join(" ", setA));
        }
    }
}
