using System;

namespace MidExam21
{
    class Program
    {
        static void Main(string[] args)
        {
            double requiredExp = double.Parse(Console.ReadLine());
            int countOdBattles = int.Parse(Console.ReadLine());

            double exp = 0.0;

            for (int i = 1; i <= countOdBattles; i++)
            {
                double currentPlayetExp = double.Parse(Console.ReadLine());

                if (i % 3 == 0)
                {
                    currentPlayetExp *= 1.15;
                }

                if (i % 5 == 0)
                {
                    currentPlayetExp *= 0.90;
                }

                if (i % 15 == 0)
                {
                    currentPlayetExp *= 1.05;
                }

                exp += currentPlayetExp;

                if (exp >= requiredExp)
                {
                    Console.WriteLine($"Player successfully collected his needed experience for {i} battles.");

                    Environment.Exit(0);
                }
            }

            double neededExp = requiredExp - exp;

            Console.WriteLine($"Player was not able to collect the needed experience, {neededExp:f2} more needed.");
        }
    }
}
