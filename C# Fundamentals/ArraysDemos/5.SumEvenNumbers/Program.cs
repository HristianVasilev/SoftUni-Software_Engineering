using System;
using System.Linq;

namespace _5.SumEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            //string[] input = Console.ReadLine().Split();
            //int sumEven = 0;
            //foreach (var item in input)
            //{
            //    if (int.Parse(item) % 2 == 0)
            //    {
            //        sumEven += int.Parse(item);
            //    }
            //}
            //Console.WriteLine(sumEven);
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int sum = 0;
            foreach (var item in numbers)
            {
                if (item % 2 ==0)
                {
                    sum += item;
                }
            }
            Console.WriteLine(sum);
        }
    }
}
