using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenericSwapMethodIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                list.Add(int.Parse(input));
            }

            int[] swapIndexes = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int index1 = swapIndexes[0];
            int index2 = swapIndexes[1];

            string result = Swap(list, index1, index2);
            Console.WriteLine(result);
        }
        private static string Swap<T>(List<T> list, int index1, int index2)
        {
            var elementAtIndex1 = list[index1];
            list[index1] = list[index2];
            list[index2] = elementAtIndex1;

            StringBuilder sb = new StringBuilder();

            foreach (var item in list)
            {
                sb.AppendLine($"{item.GetType().FullName}: {item}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
