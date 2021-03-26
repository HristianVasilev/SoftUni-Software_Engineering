using System;
using System.Linq;

namespace _6.EvenAndOddSubtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int sumEven = 0;
            int sumOdd = 0;
            foreach (var item in array)
            {
                if (item % 2 == 0)
                {
                    sumEven += item;
                }
                else
                {
                    sumOdd += item;
                }
            }
            Console.WriteLine(sumEven-sumOdd);
        }
    }
}
