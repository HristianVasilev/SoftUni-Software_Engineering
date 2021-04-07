using System;

namespace _8.BeerKegs
{
    class Program
    {
        static void Main(string[] args)
        {
            byte countOfKegs = byte.Parse(Console.ReadLine());
            double maxVolume = double.MinValue;
            string biggestKeg = string.Empty;

            for (int i = 0; i < countOfKegs; i++)
            {
                string model = Console.ReadLine();
                float radius = float.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());

                double volume = Math.PI * Math.Pow(radius,2) * height;
                if (volume > maxVolume)
                {
                    maxVolume = volume;
                    biggestKeg = model;
                }
            }
            Console.WriteLine(biggestKeg);
        }
    }
}
