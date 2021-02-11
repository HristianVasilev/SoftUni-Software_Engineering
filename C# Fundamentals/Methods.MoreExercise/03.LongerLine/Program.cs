using System;

namespace _03.LongerLine
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] point1 = Array();
            double[] point2 = Array();

            decimal line1Length = Line(point1, point2);

            double[] point3 = Array();
            double[] point4 = Array();

            decimal line2Length = Line(point3, point4);

            string output;

            if (line1Length < line2Length)
            {
                output = GetCoordinates(point3, point4);
            }
            else if (line1Length == line2Length)
            {
                output = GetCoordinates(point1, point2);
            }
            else
            {
                output = GetCoordinates(point1, point2);
            }

            Console.WriteLine(output);
        }

        private static string GetCoordinates(double[] firstPoint, double[] secontPoint)
        {
            decimal lengthToFirstPoint = Line(new double[] { 0, 0 }, firstPoint);
            decimal lengthToSecondPoint = Line(new double[] { 0, 0 }, secontPoint);

            if (lengthToFirstPoint < lengthToSecondPoint)
            {
                return $"({string.Join(", ", firstPoint)})({string.Join(", ", secontPoint)})";
            }
            else
            {
                return $"({string.Join(", ", secontPoint)})({string.Join(", ", firstPoint)})";
            }
        }

        static double[] Array()
        {
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());

            double[] array = new double[] { x, y };

            return array;
        }

        static decimal Line(double[] firstPoint, double[] secondPoint)
        {
            double deltaX = Math.Abs(firstPoint[0] - secondPoint[0]);
            double deltaY = Math.Abs(firstPoint[1] - secondPoint[1]);

            decimal length = (decimal)(Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2)));
            return length;
        }

    }
}
