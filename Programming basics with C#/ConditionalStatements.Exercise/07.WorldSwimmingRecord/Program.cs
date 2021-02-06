using System;

namespace _07.WorldSwimmingRecord
{
    class Program
    {
        static void Main(string[] args)
        {
            double recordTime = double.Parse(Console.ReadLine());
            double distance = double.Parse(Console.ReadLine());
            double timePerMeter = double.Parse(Console.ReadLine());

            double timeResult = distance * timePerMeter + (int)(distance / 15.0) * 12.5;

            if (timeResult < recordTime)
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {(timeResult):F2} seconds.");
            }
            else
            {
                Console.WriteLine($"No, he failed! He was {(timeResult - recordTime):F2} seconds slower.");
            }
        }
    }
}
