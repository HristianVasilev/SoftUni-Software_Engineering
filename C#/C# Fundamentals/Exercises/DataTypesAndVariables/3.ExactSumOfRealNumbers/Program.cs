using System;

namespace _3.ExactSumOfRealNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            byte n = byte.Parse(Console.ReadLine());
            decimal exactSum = 0;
            for (int i = 0; i < n; i++)
            {
                decimal number = decimal.Parse(Console.ReadLine());
                exactSum += number;
            }
            Console.WriteLine(exactSum);
        }
    }
}
