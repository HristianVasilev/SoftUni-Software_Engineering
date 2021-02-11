using System;

namespace _02.CenterPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());

            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            Console.WriteLine($"({String.Join(", ", Coordinates(x1, y1, x2, y2))})");
        }
        static double VectorLength(double x, double y)
        {
            return Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
        }
        static double[] Coordinates(double x1, double y1, double x2, double y2)
        {
            double vector1 = VectorLength(x1, y1);
            double vector2 = VectorLength(x2, y2);

            double[] array = new double[2];
            if (vector1 < vector2)
            {
                array[0] = x1;
                array[1] = y1;
                return array;
            }
            else
            {
                array[0] = x2;
                array[1] = y2;
                return array;
            }
        }
    }
}
