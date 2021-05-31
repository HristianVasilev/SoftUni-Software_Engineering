using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.CountSameValuesInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            Dictionary<double, int> data = new Dictionary<double, int>();

            foreach (var number in numbers)
            {
                if (!data.ContainsKey(number))
                {
                    data.Add(number, 0);
                }

                data[number]++;
            }

            string output = GetOutput(data);
            Console.WriteLine(output);
        }

        private static string GetOutput(Dictionary<double, int> data)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in data)
            {
                sb.AppendLine($"{item.Key} - {item.Value} times");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
