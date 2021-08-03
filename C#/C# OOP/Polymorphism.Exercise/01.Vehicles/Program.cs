using _01.Vehicles.Models;
using System;

namespace _01.Vehicles
{
    class Program
    {
        static void Main(string[] args)
        {
            Vehicle car = ReadVehicle();
            Vehicle truck = ReadVehicle();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string action = tokens[0];
                string vehicleType = tokens[1];
                double argument = double.Parse(tokens[2]);

                Vehicle vehicle = SelectVehicle(car, truck, vehicleType);
                string result = Action(tokens, action, ref vehicle);
                if (result != null)
                {
                    Console.WriteLine(result);
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);

        }

        private static string Action(string[] tokens, string action, ref Vehicle vehicle)
        {
            string result = null;

            switch (action)
            {
                case "Drive":
                    double distance = double.Parse(tokens[2]);
                    result = vehicle.Drive(distance);

                    break;
                case "Refuel":
                    double amountOfFuel = double.Parse(tokens[2]);
                    vehicle.Refuel(amountOfFuel);

                    break;
                default:
                    throw new InvalidOperationException("Invalid action!");
            }

            return result;
        }

        private static Vehicle SelectVehicle(Vehicle car, Vehicle truck, string vehicleType)
        {
            Vehicle vehicle;
            switch (vehicleType)
            {
                case "Car":
                    vehicle = car;
                    break;
                case "Truck":
                    vehicle = truck;
                    break;

                default:
                    throw new InvalidOperationException("Invalid vehicle type!");
            }

            return vehicle;
        }

        private static Vehicle ReadVehicle()
        {
            string[] carArguments = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string type = carArguments[0].ToLower();

            double fuelQuantity = double.Parse(carArguments[1]);
            double fuelConsumption = double.Parse(carArguments[2]);

            Vehicle vehicle;

            switch (type)
            {
                case "car":
                    vehicle = new Car(fuelQuantity, fuelConsumption);

                    break;
                case "truck":
                    vehicle = new Truck(fuelQuantity, fuelConsumption);

                    break;
                default:
                    throw new InvalidOperationException("Invalid type of vehicle!");
            }

            return vehicle;
        }
    }
}
