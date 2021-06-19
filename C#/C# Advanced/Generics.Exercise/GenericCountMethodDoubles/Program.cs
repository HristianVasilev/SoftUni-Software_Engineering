using System;
using System.Collections.Generic;

namespace GenericCountMethodDoubles
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Box<double>> boxes = new List<Box<double>>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                var box = new Box<double>(double.Parse(input));
                boxes.Add(box);
            }

            Box<double> comparisonValue = new Box<double>(double.Parse(Console.ReadLine()));

            int result = Count(boxes, comparisonValue);
            Console.WriteLine(result);
        }

        private static int Count<T>(List<Box<T>> boxes, Box<T> comparisonValue) where T : IComparable
        {
            int count = 0;

            foreach (var box in boxes)
            {
                bool isGreater = box.IsGreaterThan(comparisonValue.Element);

                if (isGreater)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
