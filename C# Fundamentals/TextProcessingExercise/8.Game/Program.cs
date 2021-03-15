using System;
using System.Linq;
using System.Text;

namespace _08.LettersChangeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            double total = 0;

            for (int i = 0; i < input.Length; i++)
            {
                string current = input[i];

                char first = current[0];
                string n = string.Empty;
                char last = current[current.Length - 1];

                for (int j = 0; j < current.Length; j++)
                {
                    if (char.IsDigit(current[j]))
                    {
                        n += current[j];
                    }
                }

                double number = int.Parse(n);

                // firstSymbol
                int letterPosition = 0;

                if (char.IsUpper(first))
                {
                    // uppercase -> divide the number by letter position
                    letterPosition = first - 64;
                    number /= letterPosition;
                }
                else if (char.IsLower(first))
                {
                    letterPosition = first - 96;
                    number *= letterPosition;
                }

                // lastSymbol

                if (char.IsUpper(last))
                {
                    letterPosition = last - 64;
                    number -= letterPosition;
                }
                else if (char.IsLower(last))
                {
                    letterPosition = last - 96;
                    number += letterPosition;
                }

                total += number;
            }

            Console.WriteLine($"{total:f2}");

        }
    }
}
