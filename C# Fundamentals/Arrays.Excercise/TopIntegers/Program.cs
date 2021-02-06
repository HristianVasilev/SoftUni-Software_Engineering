using System;
using System.Linq;

namespace TopIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputArr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            for (int i = 0; i < inputArr.Length; i++)
            {
                bool hasBiggestAtRight = false;

                for (int j = i+1; j < inputArr.Length; j++)
                {
                    if (inputArr[i] <= inputArr[j])
                    {
                        hasBiggestAtRight = true;
                        break;
                    }
                }

                if (!hasBiggestAtRight)
                {
                    Console.Write($"{inputArr[i]} ");
                }
            }
        }
    }
}
