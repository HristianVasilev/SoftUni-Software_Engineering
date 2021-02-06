using System;

namespace _02._Equal_Sums_Even_Odd_Position
{
    class Program
    {
        static void Main(string[] args)
        {
            int number1 = int.Parse(Console.ReadLine());
            int number2 = int.Parse(Console.ReadLine());

            for (int i = number1; i <= number2; i++)
            {
                string number = i.ToString();
                int sumEven = 0;
                int sumOdd = 0;

                for (int j = 0; j < number.Length; j++)
                {
                    if (j % 2 == 0)
                    {
                        sumEven += int.Parse(number[j].ToString());
                    }
                    else
                    {
                        sumOdd += int.Parse(number[j].ToString());
                    }
                }
                if (sumOdd == sumEven)
                {
                    Console.Write(i + " ");
                }
            }
        }
    }
}
