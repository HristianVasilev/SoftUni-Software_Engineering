using System;
using System.Linq;

namespace FoldAndSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int[] leftPart = GetLeftPart(arr);
            int[] middlePart = GetMiddlePart(arr);
            int[] rightPart = GetRightPart(arr);

            int[] result = new int[arr.Length / 2];

            GenerateResult(leftPart, middlePart, rightPart, result);
            Console.WriteLine(string.Join(' ',result));
        }

        private static void GenerateResult(int[] leftPart, int[] middlePart, int[] rightPart, int[] result)
        {
            int i = 0;

            while (i < middlePart.Length)
            {
                i = FillArray(leftPart, middlePart, result, i);
                i = FillArray(rightPart, middlePart, result, i);            
            }
        }

        private static int FillArray(int[] leftPart, int[] middlePart, int[] result, int i)
        {
            for (int j = 0; j < leftPart.Length; j++)
            {
                result[i] = leftPart[j] + middlePart[i];
                i++;
            }

            return i;
        }

        private static int[] GetMiddlePart(int[] arr)
        {
            int[] result = new int[arr.Length / 2];
            byte counter = 0;

            for (int i = arr.Length / 4; i < 3 * arr.Length / 4; i++)
            {
                result[counter++] = arr[i];
            }

            return result;
        }

        private static int[] GetRightPart(int[] arr)
        {
            int[] result = new int[arr.Length / 4];
            byte counter = 0;

            for (int i = arr.Length - 1; i >= 3 * arr.Length / 4; i--)
            {
                result[counter++] = arr[i];
            }

            return result;
        }

        private static int[] GetLeftPart(int[] arr)
        {
            int[] result = new int[arr.Length / 4];
            for (int i = 0; i < arr.Length / 4; i++)
            {
                result[i] = arr[i];
            }

            return result.Reverse().ToArray();
        }
    }
}
