using System;

namespace _10._Odd_Even_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            byte n = byte.Parse(Console.ReadLine());

            int sumEven = 0;
            int sumOdd = 0;

            for (byte i = 0; i < n; i++)
            {
                if (i % 2 == 0)
                {
                    sumEven += int.Parse(Console.ReadLine());
                }
                else
                {
                    sumOdd += int.Parse(Console.ReadLine());
                }
            }

            if (sumEven == sumOdd)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {sumOdd}");
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {Math.Abs(sumEven - sumOdd)}");
            }
        }
    }
}
