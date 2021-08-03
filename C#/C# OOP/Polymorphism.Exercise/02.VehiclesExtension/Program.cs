using _02.VehiclesExtension.Models;
using System;

namespace _02.VehiclesExtension
{
    class Program
    {
        static void Main(string[] args)
        {
            Vehicle car = ReadVehicle();
            Vehicle truck = ReadVehicle();
            Vehicle bus = ReadVehicle();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string action = tokens[0];
                string vehicleType = tokens[1];
                double argument = double.Parse(tokens[2]);

                Vehicle vehicle = SelectVehicle(car, truck, bus, vehicleType);
                string result = Action(argument, action, ref vehicle);
                if (result != null)
                {
                    Console.WriteLine(result);
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }

        private static string Action(double argument, string action, ref Vehicle vehicle)
        {
            string result = null;

            try
            {
                switch (action)
                {
                    case "Drive":
                        result = vehicle.Drive(argument);

                        break;
                    case "DriveEmpty":
                        result = vehicle.Drive(argument, false);

                        break;
                    case "Refuel":
                        vehicle.Refuel(argument);

                        break;
                    default:
                        throw new InvalidOperationException("Invalid action!");
                }
            }
            catch (InvalidOperationException ex)
            {
                result = ex.Message;
            }

            return result;
        }

        private static Vehicle SelectVehicle(Vehicle car, Vehicle truck, Vehicle bus, string vehicleType)
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
                case "Bus":
                    vehicle = bus;
                    break;

                default:
                    throw new InvalidOperationException("Invalid vehicle type!");
            }

            return vehicle;
        }

        private static Vehicle ReadVehicle()
        {
            string[] vehicleArguments = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string type = vehicleArguments[0].ToLower();

            double fuelQuantity = double.Parse(vehicleArguments[1]);
            double fuelConsumption = double.Parse(vehicleArguments[2]);
            double tankCapacity = double.Parse(vehicleArguments[3]);

            Vehicle vehicle;

            switch (type)
            {
                case "car":
                    vehicle = new Car(fuelQuantity, fuelConsumption, tankCapacity);
                    break;
                case "truck":
                    vehicle = new Truck(fuelQuantity, fuelConsumption, tankCapacity);
                    break;
                case "bus":
                    vehicle = new Bus(fuelQuantity, fuelConsumption, tankCapacity);
                    break;

                default:
                    throw new InvalidOperationException("Invalid type of vehicle!");
            }

            return vehicle;
        }
    }
}
