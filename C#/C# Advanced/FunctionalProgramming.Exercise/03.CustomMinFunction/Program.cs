using System;
using System.Linq;

namespace _03.CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int[], int> getSmallest = array => 
            {
                int min = int.MaxValue;

                foreach (var item in array)
                {
                    if (item< min)
                    {
                        min = item;
                    }
                }

                return min;
            };

            var smallest = getSmallest(numbers);
            Console.WriteLine(smallest);           
        }
    }
}
