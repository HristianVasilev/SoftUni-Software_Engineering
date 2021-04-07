using System;

namespace _01.Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            double price = 0;

            if (type == "Premiere")
            {
                price = 12;
            }
            else if (type == "Normal")
            {
                price = 7.5;
            }
            else if (type == "Discount")
            {
                price = 5;
            }         

            double result = rows * cols * price;
            Console.WriteLine($"{result:F2} leva");
        }
    }
}
