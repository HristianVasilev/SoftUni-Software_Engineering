using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.BombNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> sequence = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            int[] info = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int bombNumber = info[0];
            int power = info[1];

            int bombLocation = sequence.IndexOf(sequence.FirstOrDefault(x => x == bombNumber));

            while (bombLocation != -1)
            {
                Detonate(sequence, bombLocation, bombNumber, power);

                bombLocation = sequence.IndexOf(sequence.FirstOrDefault(x => x == bombNumber));
            }

            int result = sequence.Sum();
            Console.WriteLine(result);
        }

        private static void Detonate(List<int> sequence, int bombLocation, int bombNumber, int power)
        {
            int startIndex = GetIndex(sequence, bombLocation, power, 0);
            int endIndex = GetIndex(sequence, bombLocation, power, sequence.Count - 1);

            CheckForBombsInTheRange(sequence, bombLocation, bombNumber, power, startIndex, endIndex);

            sequence.RemoveRange(startIndex, endIndex - startIndex + 1);
        }

        private static int GetIndex(List<int> sequence, int bombLocation, int power, int defaultValue)
        {
            int index = bombLocation - power;

            if (!ValidIndex(sequence, index))
            {
                index = defaultValue;
            }

            return index;
        }

        private static int CheckForBombsInTheRange(List<int> sequence, int bombLocation, int bombNumber, int power, int startIndex, int endIndex)
        {
            int lastIndexOfAnotherBomb = -1;
            for (int i = bombLocation + 1; i < endIndex; i++)
            {
                if (sequence[i] == bombNumber)
                {
                    lastIndexOfAnotherBomb = i;
                }
            }

            if (lastIndexOfAnotherBomb != -1)
            {
                endIndex = GetIndex(sequence, lastIndexOfAnotherBomb, power, sequence.Count - 1);
                int index = CheckForBombsInTheRange(sequence, lastIndexOfAnotherBomb, bombNumber, power, startIndex, endIndex);

                if (index > endIndex)
                {
                    endIndex = index;
                }
            }

            return endIndex;
        }

        private static bool ValidIndex(List<int> sequence, int index)
        {
            return index >= 0 && index < sequence.Count;
        }
    }
}
