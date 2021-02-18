using System;
using System.Linq;

namespace _2.ShootForTheWin
{
    class Program
    {
        private static int[] targetValues;

        static void Main(string[] args)
        {
            targetValues = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int countOfShotTargets = 0;

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                int index = int.Parse(command);

                if (!ValidIndex(index))
                {
                    continue;
                }

                int value = targetValues[index];

                if (value == -1)
                {
                    continue;
                }

                targetValues[index] = -1;

                Shoot(value);
                countOfShotTargets++;
            }

            Console.WriteLine($"Shot targets: {countOfShotTargets} -> {string.Join(' ',targetValues)}");
        }

        private static bool ValidIndex(int index)
        {
            return index >= 0 && index < targetValues.Length;
        }

        private static void Shoot(int value)
        {
            for (int i = 0; i < targetValues.Length; i++)
            {
                if (targetValues[i] == -1)
                {
                    continue;
                }

                if (targetValues[i] > value)
                {
                    targetValues[i] -= value;
                }
                else
                {
                    targetValues[i] += value;
                }
            }
        }
    }
}
