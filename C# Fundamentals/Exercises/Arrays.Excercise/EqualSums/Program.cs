using System;
using System.Linq;

namespace EqualSums
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int goldenIndex = -1;

            for (int i = 0; i < arr.Length; i++)
            {
                int sumLeft = SumLeft(i, arr);
                int sumRight = SumRight(i, arr);

                if (sumLeft == sumRight)
                {
                    goldenIndex = i;
                }
            }

            if (goldenIndex != -1)
            {
                Console.WriteLine(goldenIndex);
            }
            else
            {
                Console.WriteLine("no");
            }
        }

        private static int SumLeft(int index, int[] arr)
        {
            int result = 0;

            for (int i = 0; i < index; i++)
            {
                result += arr[i];
            }

            return result;
        }

        private static int SumRight(int index, int[] arr)
        {
            int result = 0;

            for (int i = index + 1; i < arr.Length; i++)
            {
                result += arr[i];
            }

            return result;
        }
    }
}
