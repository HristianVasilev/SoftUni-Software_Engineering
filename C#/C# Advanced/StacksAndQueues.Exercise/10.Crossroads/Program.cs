using System;
using System.Collections.Generic;

namespace _10.Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLightDuration = int.Parse(Console.ReadLine());
            int freeWindowDuration = int.Parse(Console.ReadLine());

            Queue<string> cars = new Queue<string>();
            int totalCarsPassed = 0;

            string inputCommand;
            while ((inputCommand = Console.ReadLine()) != "END")
            {
                if (inputCommand == "green")
                {
                    PassTheCrossroad(ref cars, greenLightDuration, freeWindowDuration, ref totalCarsPassed);
                    continue;
                }

                cars.Enqueue(inputCommand);
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{totalCarsPassed} total cars passed the crossroads.");

        }

        private static void PassTheCrossroad(ref Queue<string> cars, int greenLightDuration, int freeWindowDuration, ref int totalCarsPassed)
        {
            string currentCar = cars.Dequeue();

            do
            {
                greenLightDuration -= currentCar.Length;
                totalCarsPassed++;

                if (greenLightDuration < 0)
                {
                    freeWindowDuration += greenLightDuration;

                    if (freeWindowDuration < 0)
                    {
                        Console.WriteLine("A crash happened!");
                        char characterHit = currentCar[currentCar.Length + freeWindowDuration];
                        Console.WriteLine($"{currentCar} was hit at {characterHit}.");
                        Environment.Exit(0);
                    }
                }

                if (cars.Count == 0)
                {
                    break;
                }

                currentCar = cars.Dequeue();

            } while (greenLightDuration > 0);

        }
    }
}
