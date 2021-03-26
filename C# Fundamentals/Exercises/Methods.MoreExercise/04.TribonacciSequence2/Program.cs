using System;

namespace _04.TribonacciSequence2
{
    class Program
    {
        private static int[] arr;

        static void Main(string[] args)
        {

            int num = int.Parse(Console.ReadLine());

            arr = new int[num];

            FirstTribonacciSequence(num);

            if (num >= 4)
            {
                GetTribonacciSequence(num);
            }

            Console.WriteLine(string.Join(' ', arr));
        }

        private static void FirstTribonacciSequence(int num)
        {
            if (num >= 1)
            {
                arr[0] = 1;
            }

            if (num >= 2)
            {
                arr[1] = 1;
            }

            if (num >= 3)
            {
                arr[2] = 2;
            }
        }

        private static void GetTribonacciSequence(int num)
        {
            for (int i = 3; i < num; i++)
            {
                arr[i] = arr[i - 1] + arr[i - 2] + arr[i - 3];
            }
        }
    }
}
