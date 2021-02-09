using System;

namespace GreaterThanTwoValues
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            string firstArg = Console.ReadLine();
            string secondArg = Console.ReadLine();

            switch (type)
            {
                case "int":
                    int a = int.Parse(firstArg);
                    int b = int.Parse(secondArg);
                    Console.WriteLine(GetMax(a, b));

                    break;
                case "char":
                    char c1 = char.Parse(firstArg);
                    char c2 = char.Parse(secondArg);
                    Console.WriteLine(GetMax(c1, c2));

                    break;
                case "string":
                    Console.WriteLine(GetMax(firstArg, secondArg));
                    break;
                default:
                    throw new InvalidOperationException();
            }
        }

        private static int GetMax(int a, int b)
        {
            return Math.Max(a, b);
        }

        private static char GetMax(char c1, char c2)
        {
            if (c1.CompareTo(c2) == -1)
            {
                return c1;
            }

            return c2;
        }

        private static string GetMax(string firstArg, string secondArg)
        {
            int i = firstArg.CompareTo(secondArg);
            if (i == -1)
            {
                return secondArg;
            }

            return firstArg;
        }

    }
}
