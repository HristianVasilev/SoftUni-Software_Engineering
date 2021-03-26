using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.PokemonDontGo
{
    class Program
    {
        private static List<int> sequence;

        static void Main(string[] args)
        {
            sequence = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            List<int> removedElements = new List<int>();

            while (sequence.Count > 0)
            {
                int index = int.Parse(Console.ReadLine());

                int removedElement = RemoveElement(index);
                removedElements.Add(removedElement);

                IncreaseOrDecrease(removedElement);
            }

            Console.WriteLine(removedElements.Sum());
        }

        private static void IncreaseOrDecrease(int removedElement)
        {
            for (int i = 0; i < sequence.Count; i++)
            {
                if (sequence[i] <= removedElement)
                {
                    sequence[i] += removedElement;
                }
                else
                {
                    sequence[i] -= removedElement;
                }
            }
        }

        private static int RemoveElement(int index)
        {
            int removedElement;

            if (ValidIndex(index))
            {
                removedElement = sequence.ElementAt(index);
                sequence.RemoveAt(index);
            }
            else
            {
                if (index < 0)
                {
                    removedElement = sequence.ElementAt(0);
                    sequence[0] = sequence[sequence.Count - 1];
                }
                else
                {
                    removedElement = sequence.ElementAt(sequence.Count - 1);
                    sequence[sequence.Count - 1] = sequence[0];
                }
            }

            return removedElement;
        }

        private static bool ValidIndex(int index)
        {
            return index >= 0 && index < sequence.Count;
        }
    }
}
