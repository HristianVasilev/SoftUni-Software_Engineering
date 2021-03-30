using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem3.NeedForSpeedIII
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Car> cars = new Dictionary<string, Car>();

            int numberOfCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] tokens = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);

                RegisterCars(ref cars, tokens);
            }

            string command;
            while ((command = Console.ReadLine()) != "Stop")
            {
                string[] tokens = command.Split(" : ", StringSplitOptions.RemoveEmptyEntries);

                switch (tokens[0])
                {
                    case "Drive":
                        Drive(ref cars, tokens);
                        break;
                    case "Refuel":
                        Refuel(ref cars, tokens);
                        break;
                    case "Revert":
                        Revert(ref cars, tokens);
                        break;
                    default:
                        throw new NotImplementedException("Invalid command!");
                }
            }

            PrintCars(ref cars);
        }

        private static void PrintCars(ref Dictionary<string, Car> cars)
        {
            cars = cars.OrderByDescending(c => c.Value.MileAge)
                .ThenBy(c => c.Key)
                .ToDictionary(k => k.Key, v => v.Value);

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Key} -> Mileage: {car.Value.MileAge} kms, Fuel in the tank: {car.Value.Fuel} lt.");
            }
        }

        private static void Revert(ref Dictionary<string, Car> cars, string[] tokens)
        {
            string car = tokens[1];
            int kilometers = int.Parse(tokens[2]);

            if (cars[car].MileAge - kilometers > 10000)
            {
                cars[car].MileAge -= kilometers;
                Console.WriteLine($"{car} mileage decreased by {kilometers} kilometers");
            }
            else
            {
                cars[car].MileAge = 10000;
            }
        }

        private static void Refuel(ref Dictionary<string, Car> cars, string[] tokens)
        {
            string car = tokens[1];
            int fuel = int.Parse(tokens[2]);

            if (cars[car].Fuel + fuel <= 75)
            {
                cars[car].Fuel += fuel;
            }
            else
            {
                fuel = 75 - cars[car].Fuel;
                cars[car].Fuel = 75;
            }

            Console.WriteLine($"{car} refueled with {fuel} liters");
        }

        private static void Drive(ref Dictionary<string, Car> cars, string[] tokens)
        {
            string car = tokens[1];
            int distance = int.Parse(tokens[2]);
            int fuel = int.Parse(tokens[3]);

            if (cars[car].Fuel < fuel)
            {
                Console.WriteLine("Not enough fuel to make that ride");
                return;
            }

            cars[car].Fuel -= fuel;
            cars[car].MileAge += distance;

            Console.WriteLine($"{car} driven for {distance} kilometers. {fuel} liters of fuel consumed.");

            if (cars[car].MileAge >= 100000)
            {
                cars.Remove(car);
                Console.WriteLine($"Time to sell the {car}!");
            }
        }



        private static void RegisterCars(ref Dictionary<string, Car> cars, string[] tokens)
        {
            string carName = tokens[0];
            int mileAge = int.Parse(tokens[1]);
            int fuel = int.Parse(tokens[2]);

            if (!cars.ContainsKey(carName))
            {
                cars.Add(carName, new Car());
            }

            cars[carName].Name = carName;
            cars[carName].MileAge = mileAge;
            cars[carName].Fuel = fuel;
        }
    }

    class Car
    {
        public string Name { get; set; }
        public int MileAge { get; set; }
        public int Fuel { get; set; }
    }
}
