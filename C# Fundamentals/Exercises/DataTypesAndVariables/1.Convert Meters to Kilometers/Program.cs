using System;

namespace _1.Convert_Meters_to_Kilometers
{
    class Program
    {
        static void Main(string[] args)
        {
            int meters = int.Parse(Console.ReadLine());
            double kilometers = meters*0.001;
            Console.WriteLine($"{kilometers:f2}");
        }
    }
}
