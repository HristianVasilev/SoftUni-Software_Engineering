using System;
using System.Linq;

namespace _09.ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int boundary = int.Parse(Console.ReadLine());

            int[] dividers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Predicate<int> isDivisible = number =>
            {
                for (int i = 0; i < dividers.Length; i++)
                {
                    if (number % dividers[i] != 0)
                    {
                        return false;
                    }
                }

                return true;
            };

            for (int i = 1; i <= boundary; i++)
            {
                if (isDivisible(i))
                {
                    Console.Write($"{i} ");
                }
            }
        }
    }
}
