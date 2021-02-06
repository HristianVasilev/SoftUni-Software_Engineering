using System;
using System.Numerics;

namespace _11.Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            byte numberOfSnowballs = byte.Parse(Console.ReadLine());
            short snow = 0;
            short time = 0;
            short quality = 0;
            BigInteger highest = 0;
            for (int i = 0; i < numberOfSnowballs; i++)
            {
                short snowballSnow = short.Parse(Console.ReadLine());
                short snowballTime = short.Parse(Console.ReadLine());
                short snowballQuality = short.Parse(Console.ReadLine());
                BigInteger snowballValue = BigInteger.Pow((snowballSnow / snowballTime), snowballQuality);
                if (snowballValue > highest)
                {
                    highest = snowballValue;
                    snow = snowballSnow;
                    time = snowballTime;
                    quality = snowballQuality;
                }
            }
            Console.WriteLine($"{snow} : {time} = {highest} ({quality})");
        }
    }
}
