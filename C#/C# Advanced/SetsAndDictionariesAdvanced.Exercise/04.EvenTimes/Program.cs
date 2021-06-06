using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> numbers = new Dictionary<int, int>();

            byte n = byte.Parse(Console.ReadLine());

            for (byte i = 0; i < n; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());

                if (!numbers.ContainsKey(currentNumber))
                {
                    numbers.Add(currentNumber, 0);
                }

                numbers[currentNumber]++;
            }

            int result = numbers.First(x => x.Value % 2 == 0).Key;
            Console.WriteLine(result);
        }
    }
}
