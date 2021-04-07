using System;

namespace _09._Left_and_Right_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            byte n = byte.Parse(Console.ReadLine());
            int leftSum = 0;
            int rightSum = 0;

            for (byte i = 0; i < n; i++)
            {
                leftSum += int.Parse(Console.ReadLine());
            }
            for (byte i = 0; i < n; i++)
            {
                rightSum += int.Parse(Console.ReadLine());
            }

            if (leftSum == rightSum)
            {
                Console.WriteLine($"Yes, sum = {leftSum}");
            }
            else
            {
                Console.WriteLine($"No, diff = {Math.Abs(leftSum - rightSum)}");
            }
        }
    }
}
