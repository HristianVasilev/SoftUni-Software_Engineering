using System;
using System.Collections.Generic;
using System.Linq;

namespace LongestIncreasingSubsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sequence = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Stack<int> result = new Stack<int>();

            for (int i = 0; i < sequence.Length; i++)
            {
                if (result.Count != 0 && sequence[i] < result.Last())
                {
                    result.Pop();
                }

                if (sequence[i] < result.Last())
                {
                    continue;
                }

                result.Push(sequence[i]);
            }



            Console.WriteLine(string.Join(' ',result));
        }
    }
}
