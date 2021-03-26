using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.AppendArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> output = new List<int>();
            string input = Console.ReadLine();
            string[] arrays = input.Split('|', StringSplitOptions.RemoveEmptyEntries).Reverse().ToArray();

            for (int i = 0; i < arrays.Length; i++)
            {
                int[] currentArr = arrays[i].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                output.AddRange(currentArr);
            }

            Console.WriteLine(string.Join(' ',output));
        }
    }
}
