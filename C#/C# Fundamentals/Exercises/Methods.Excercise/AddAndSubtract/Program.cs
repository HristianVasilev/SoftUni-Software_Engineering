using System;

namespace AddAndSubtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());
            int n3 = int.Parse(Console.ReadLine());

            int sumResult = Sum(n1, n2);
            int output = Subtract(sumResult, n3);

            Console.WriteLine(output);
        }

        private static int Subtract(int sumResult, int n3)
        {
            return sumResult - n3;
        }

        private static int Sum(int n1, int n2)
        {
            return n1 + n2;
        }

    }
}
