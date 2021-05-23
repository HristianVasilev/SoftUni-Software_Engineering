using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<string> input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Stack<string> stack = new Stack<string>(input);
            int result = 0;

            while (stack.Count > 0)
            {
                string current = stack.Pop();

                if (int.TryParse(current, out int number))
                {
                    if (stack.Count > 0)
                    {
                        string sign = stack.Pop();

                        if (sign == "-")
                        {
                            number *= -1;
                        }
                    }
                }
                else
                {
                    throw new InvalidCastException();
                }

                result += number;
            }

            Console.WriteLine(result);
        }
    }
}
