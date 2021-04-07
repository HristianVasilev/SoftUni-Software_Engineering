using System;
using System.Linq;

namespace ArrayRotation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int[] temp = new int[arr.Length];

                for (int j = 1; j < arr.Length; j++)
                {
                    temp[j - 1] = arr[j];
                }

                temp[temp.Length-1] = arr[0];
                arr = temp;
            }

            Console.WriteLine(string.Join(' ',arr));
        }
    }
}
