using System;

namespace _9.SpiceMustFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            int startingYield = int.Parse(Console.ReadLine());
            int totalAmount = 0;
            byte days = 0;

            do
            {
                int amountPerDay = 0;
                if (startingYield >= 26)
                {
                    amountPerDay += (startingYield - 26);
                }
                else
                {
                    amountPerDay += startingYield;
                }
                startingYield -= 10;
                days++;
                totalAmount += amountPerDay;
            } while (startingYield >= 100);
            if (totalAmount >=26)
            {
                totalAmount -= 26;
            }
            Console.WriteLine(days);
            Console.WriteLine(totalAmount);
        }
    }
}
