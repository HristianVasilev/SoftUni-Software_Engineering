using System;

namespace MidExam6Aug19
{
    class Program
    {
        static void Main(string[] args)
        {
            int daysOfPlunder = int.Parse(Console.ReadLine());
            int dailyPlunder = int.Parse(Console.ReadLine());
            double expectedPlunder = double.Parse(Console.ReadLine());

            double totalPlunder = GetPlunders(daysOfPlunder, dailyPlunder);

            if (totalPlunder >= expectedPlunder)
            {
                Console.WriteLine($"Ahoy! {totalPlunder:f2} plunder gained.");
            }
            else
            {
                double percentage = totalPlunder / expectedPlunder * 100;

                Console.WriteLine($"Collected only {percentage:f2}% of the plunder.");
            }


        }

        private static double GetPlunders(int daysOfPlunder, int dailyPlunder)
        {
            double totalPlunder = 0;

            for (int i = 1; i <= daysOfPlunder; i++)
            {
                totalPlunder += dailyPlunder;

                if (i % 3 == 0)
                {
                    totalPlunder += (dailyPlunder / 2.0);
                }

                if (i % 5 == 0)
                {
                    totalPlunder *= 0.70;
                }
            }

            return totalPlunder;
        }
    }
}
