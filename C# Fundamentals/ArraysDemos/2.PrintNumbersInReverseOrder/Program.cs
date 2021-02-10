using System;

namespace _2.PrintNumbersInReverseOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            byte n = byte.Parse(Console.ReadLine());
            int[] numbers = new int[n];
            for (int i = 0; i < n; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }
            for (int j = (numbers.Length-1); j >= 0; j--)
            {
                Console.Write(numbers[j]+" ");
            }
        }
    }
}
