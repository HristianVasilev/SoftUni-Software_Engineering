using System;
using System.Collections.Generic;

namespace GenericCountMethodStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Box<string>> boxes = new List<Box<string>>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                var box = new Box<string>(input);
                boxes.Add(box);
            }

            Box<string> comparisonValue = new Box<string>(Console.ReadLine());

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
