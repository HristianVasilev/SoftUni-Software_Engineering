using System;

namespace _05._Divide_Without_Remainder
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfNumbers = int.Parse(Console.ReadLine());
            double p1 = 0;
            double p2 = 0;
            double p3 = 0;

            for (int i = 0; i < countOfNumbers; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());

                if (currentNumber % 2 == 0)
                {
                    p1++;
                }
                if (currentNumber % 3 == 0)
                {
                    p2++;
                }
                if (currentNumber % 4 == 0)
                {
                    p3++;
                }
            }

            Console.WriteLine($"{(p1 / countOfNumbers * 100.00):f2}%");
            Console.WriteLine($"{(p2 / countOfNumbers * 100.00):f2}%");
            Console.WriteLine($"{(p3 / countOfNumbers * 100.00):f2}%");
        }
    }
}
