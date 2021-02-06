using System;
using System.Linq;

namespace MaxSequenceOfEqualElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            byte maxCountOfSequel = 1;
            int maxInteger = arr[0];

            byte countOfSequel = 1;
            int integer = default;

            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] == arr[i - 1])
                {
                    integer = arr[i];
                    countOfSequel++;
                }
                else
                {
                    VerifyMaxValues(ref maxCountOfSequel, ref maxInteger, countOfSequel, integer);

                    countOfSequel = 1;
                }

                VerifyMaxValues(ref maxCountOfSequel, ref maxInteger, countOfSequel, integer);
            }

            for (int i = 0; i < maxCountOfSequel; i++)
            {
                Console.Write(maxInteger + " ");
            }



        }

        private static void VerifyMaxValues(ref byte maxCountOfSequel, ref int maxInteger, byte countOfSequel, int integer)
        {
            if (maxCountOfSequel < countOfSequel)
            {
                maxCountOfSequel = countOfSequel;
                maxInteger = integer;
            }
        }
    }
}
