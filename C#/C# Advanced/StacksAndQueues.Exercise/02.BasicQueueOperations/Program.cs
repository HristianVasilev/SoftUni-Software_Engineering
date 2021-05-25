using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arguments = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int toEnqueue = arguments[0];
            int toDequeue = arguments[1];
            int toLook = arguments[2];

            Queue<int> queue = new Queue<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Dequeue(toDequeue, ref queue);
            string result = Look(toLook, ref queue);

            Console.WriteLine(result);
        }

        private static string Look(int toLook, ref Queue<int> queue)
        {
            if (queue.Count == 0)
            {
                return "0";
            }

            if (queue.Contains(toLook))
            {
                return "true";
            }

            return $"{queue.Min()}";
        }

        private static void Dequeue(int toDequeue, ref Queue<int> queue)
        {
            for (int i = 0; i < toDequeue; i++)
            {
                queue.Dequeue();
            }
        }
    }
}
