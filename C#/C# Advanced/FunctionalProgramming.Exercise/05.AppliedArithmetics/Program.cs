using System;
using System.Linq;

namespace _05.AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int[], int[]> add = array => { return array.Select(x => x += 1).ToArray(); };
            Func<int[], int[]> multiply = array => { return array.Select(x => x *= 2).ToArray(); };
            Func<int[], int[]> subtract = array => { return array.Select(x => x -= 1).ToArray(); };
            Func<int[], string> print = array => { return string.Join(' ', array); };

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                switch (command)
                {
                    case "add":
                        numbers = add(numbers);

                        break;
                    case "multiply":
                        numbers = multiply(numbers);

                        break;
                    case "subtract":
                        numbers = subtract(numbers);

                        break;
                    case "print":
                        Console.WriteLine(print(numbers));
                        break;

                    default:
                        break;
                }
            }


        }
    }
}
