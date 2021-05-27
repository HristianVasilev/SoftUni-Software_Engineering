using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._1.Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            byte greenLightDuration = byte.Parse(Console.ReadLine());
            byte freeWindowDuration = byte.Parse(Console.ReadLine());

            Queue<string> cars = new Queue<string>();
            byte passedCars = 0;

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "END")
            {
                if (command == "green")
                {
                    PassTheCrossroad(greenLightDuration, freeWindowDuration, ref cars, ref passedCars);
                }
                else
                {
                    cars.Enqueue(command);
                }
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{passedCars} total cars passed the crossroads.");
        }

        private static void PassTheCrossroad(byte greenLightDuration, byte freeWindowDuration, ref Queue<string> cars, ref byte passedCars)
        {
            while (greenLightDuration > 0 && cars.Count > 0)
            {
                string currentCar = cars.Dequeue();
                byte countOfChars = (byte)(currentCar.Length);

                if (greenLightDuration - countOfChars > 0)
                {
                    greenLightDuration -= countOfChars;
                    passedCars++;
                    continue;
                }

                byte remainingSeconds = (byte)(greenLightDuration + freeWindowDuration);

                if (remainingSeconds >= countOfChars)
                {
                    passedCars++;
                    return;
                }
                else
                {
                    byte index = (byte)(remainingSeconds);
                    char characterHit = currentCar[index];
                    Console.WriteLine("A crash happened!");
                    Console.WriteLine($"{currentCar} was hit at {characterHit}.");
                    Environment.Exit(0);
                }
            }
        }
    }
}
