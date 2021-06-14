using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int n = int.Parse(Console.ReadLine());

            Func<int[], int[]> filter = array =>
            {
                List<int> collection = new List<int>();

                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] % n != 0)
                    {
                        collection.Add(array[i]);
                    }
                }

                return collection.ToArray();
            };

            Func<int[], int[]> reverseArray = array =>
            {
                List<int> collection = new List<int>();

                for (int i = array.Length - 1; i >= 0; i--)
                {
                    collection.Add(array[i]);
                }

                return collection.ToArray();
            };
                
            var result = filter(numbers);
            result = reverseArray(result);

            Console.WriteLine(string.Join(' ', result));
        }
    }
}
