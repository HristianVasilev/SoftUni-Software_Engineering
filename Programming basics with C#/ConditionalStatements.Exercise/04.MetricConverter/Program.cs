using System;

namespace _04.MetricConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            double dimension = double.Parse(Console.ReadLine());
            string inputUnit = Console.ReadLine();
            string outputUnit = Console.ReadLine();

            double output = 0.00;

            switch (inputUnit)
            {
                case "m":

                    if (outputUnit == "cm")
                    {
                        output = dimension * 100;
                    }
                    else if (outputUnit == "mm")
                    {
                        output = dimension * 1000;
                    }

                    break;

                case "cm":

                    if (outputUnit == "m")
                    {
                        output = dimension / 100;
                    }
                    else if (outputUnit == "mm")
                    {
                        output = dimension * 10;
                    }

                    break;

                case "mm":

                    if (outputUnit == "m")
                    {
                        output = dimension / 1000;
                    }
                    else if (outputUnit == "cm")
                    {
                        output = dimension / 10;
                    }

                    break;

                default:
                    throw new ArgumentException("Invalid unit! Kaput machen!");
            }

            Console.WriteLine($"{output:F3}");
        }
    }
}
