using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.DrumSet
{
    class Program
    {
        private static double savings;
        private static int[] originalDrums;
        private static bool[] drums;

        static void Main(string[] args)
        {
            savings = double.Parse(Console.ReadLine());

            originalDrums = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            drums = new bool[originalDrums.Length];
            Array.Fill(drums, true);

            List<int> drumsQuality = originalDrums.ToList();

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Hit it again, Gabsy!")
            {
                int value = int.Parse(command);

                PowerDrums(drumsQuality, value);
            }

            PrintResult(drumsQuality);
        }

        private static void PrintResult(List<int> drumsQuality)
        {
            Console.WriteLine(string.Join(' ', drumsQuality.Where(x => x > 0)));
            Console.WriteLine($"Gabsy has {savings:f2}lv.");
        }

        private static void PowerDrums(List<int> drumsQuality, int value)
        {
            for (int i = 0; i < drumsQuality.Count; i++)
            {
                drumsQuality[i] -= value;

                if (drums[i] && drumsQuality[i] <= 0)
                {
                    ReplaceDrum(drumsQuality, i);
                }
            }
        }

        private static void ReplaceDrum(List<int> drumsQuality, int i)
        {
            double price = originalDrums[i] * 3;

            if (savings - price >= 0)
            {
                savings -= price;
                drumsQuality[i] = originalDrums[i];
            }
        }
    }
}
