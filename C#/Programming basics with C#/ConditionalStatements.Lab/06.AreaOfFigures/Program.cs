using System;

namespace _06.AreaOfFigures
{
    class Program
    {
        static void Main(string[] args)
        {
            string figure = Console.ReadLine();

            double a = 0.0;
            double b = 0.0;
            double result = 0.0;

            switch (figure)
            {
                case "square":

                    a = double.Parse(Console.ReadLine());
                    result = a * a;

                    break;
                case "rectangle":

                    a = double.Parse(Console.ReadLine());
                    b = double.Parse(Console.ReadLine());
                    result = a * b;

                    break;
                case "circle":

                    a = double.Parse(Console.ReadLine());
                    result = Math.PI * a*a;

                    break;
                case "triangle":

                    a = double.Parse(Console.ReadLine());
                    b = double.Parse(Console.ReadLine());
                    result = 0.5 * (a * b);

                    break;

                default:
                    throw new ArgumentException("KaputMachen! Invalid figure! Please try again!");
            }

            Console.WriteLine($"{result:f3}");
        }
    }
}
