using System;
using System.Linq;

namespace ZigZagArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] firstArray = new int[n];
            int[] secondArray = new int[n];

            byte fArrCounter = 0;
            byte sArrCounter = 0;

            for (int i = 0; i < n; i++)
            {
                int[] arr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                if (i % 2 != 0)
                {
                    arr = arr.Reverse().ToArray();
                }

                firstArray[fArrCounter] = arr.First();
                secondArray[sArrCounter] = arr.Last();

                fArrCounter++;
                sArrCounter++;
            }

            Console.WriteLine(string.Join(' ', firstArray));
            Console.WriteLine(string.Join(' ', secondArray));
        }
    }
}
