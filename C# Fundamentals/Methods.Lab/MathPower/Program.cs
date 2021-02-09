using System;

namespace MathPower
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());

            double result = MathPower(x, y);
            Console.WriteLine(result);
        }

        private static double MathPower(int x, int y)
        {
            return Math.Pow(x, y);
        }
    }
}
