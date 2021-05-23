using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05.PrintEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> queue = new Queue<int>(input);

            string result = Filter(queue);
            Console.WriteLine(result);
        }

        private static string Filter(Queue<int> queue)
        {
            List<int> filteredNumbers = new List<int>();

            while (queue.Count > 0)
            {
                int currentNumber = queue.Dequeue();

                if (currentNumber %2 ==0)
                {
                    filteredNumbers.Add(currentNumber);
                }
            }

            return string.Join(", ", filteredNumbers);
        }
    }
}
