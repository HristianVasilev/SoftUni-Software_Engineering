using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.BombNumbers
{
    class Program
    {
        private static List<int> sequence;

        static void Main(string[] args)
        {
            sequence = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            int[] info = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int bombNumber = info[0];
            int power = info[1];

            int bombLocation = sequence.IndexOf(sequence.FirstOrDefault(x => x == bombNumber));

            while (bombLocation != -1)
            {
                Detonate(bombLocation, bombNumber, power);

                bombLocation = sequence.IndexOf(sequence.FirstOrDefault(x => x == bombNumber));
            }

            int result = sequence.Sum();
            Console.WriteLine(result);
        }

        private static void Detonate(int bombLocation, int bombNumber, int power)
        {
            int startIndex = GetIndex(bombLocation, -power, 0);
            int endIndex = GetIndex(bombLocation, power, sequence.Count - 1);

            endIndex = CheckForBombInRight(bombLocation, bombNumber, power, endIndex);

            sequence.RemoveRange(startIndex, endIndex - startIndex + 1);
        }

        private static int GetIndex(int bombLocation, int power, int defaultValue)
        {
            int index = bombLocation + power;

            if (!ValidIndex(sequence, index))
            {
                index = defaultValue;
            }

            return index;
        }

        private static int CheckForBombInRight(int bombLocation, int bombNumber, int power, int endIndex)
        {
            int lastIndexOfBomb = -1;

            for (int i = bombLocation + 1; i <= endIndex; i++)
            {
                if (sequence[i] == bombNumber)
                {
                    lastIndexOfBomb = i;
                }
            }

            if (lastIndexOfBomb != -1)
            {
                endIndex = GetIndex(lastIndexOfBomb, power, sequence.Count - 1);
                endIndex = CheckForBombInRight(lastIndexOfBomb, bombNumber, power, endIndex);
            }

            return endIndex;
        }

        private static bool ValidIndex(List<int> sequence, int index)
        {
            return index >= 0 && index < sequence.Count;
        }
    }
}
