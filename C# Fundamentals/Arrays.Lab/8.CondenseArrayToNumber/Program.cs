using System;
using System.Linq;

namespace _8.CondenseArrayToNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int sum = 0;
            while (arr.Length > 1)
            {
                int[] arrSecond = new int[arr.Length - 1];

                for (int i = 0; i < (arr.Length - 1); i++)
                {
                    arrSecond[i] = arr[i] + arr[i + 1];
                }
                arr = arrSecond;
            }
            Console.WriteLine(arr[0]);
        }
    }
}
