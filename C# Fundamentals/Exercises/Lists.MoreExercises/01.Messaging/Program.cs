using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Messaging
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> output = new List<string>();

            List<string> numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
            string text = Console.ReadLine();

            foreach (var number in numbers)
            {
                int index = SumOfDigits(number);

                if (index > text.Length - 1)
                {
                    index = index % text.Length;
                }

                string character = text.Substring(index, 1);
                text = text.Remove(index, 1);
                output.Add(character);
            }

            Console.WriteLine(string.Join("", output));
        }

        private static int SumOfDigits(string number)
        {
            return number.Sum(x => int.Parse(x.ToString()));
        }
    }
}
