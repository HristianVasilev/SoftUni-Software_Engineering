using System;
using System.Reflection;

namespace _7.WaterOverflow
{
    class Program
    {
        static void Main(string[] args)
        {
            byte capacityOfTank = byte.MaxValue;

            byte n = byte.Parse(Console.ReadLine());
            int totalWater = 0;

            for (int i = 0; i < n; i++)
            {
                int pouring = int.Parse(Console.ReadLine());

                if (totalWater + pouring <= capacityOfTank)
                {
                    totalWater += pouring;
                }
                else
                {
                    Console.WriteLine("Insufficient capacity!");
                }
            }
            Console.WriteLine(totalWater);
        }
    }
}
