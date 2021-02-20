using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _6.VehicleCatalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] vehicleArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string typeOfVehicle = vehicleArgs[0];
                string model = vehicleArgs[1];
                string color = vehicleArgs[2];
                double horsePower = double.Parse(vehicleArgs[3]);

                CreateAndAddVehicle(ref vehicles, typeOfVehicle, model, color, horsePower);
            }

            string getModel = string.Empty;
            while ((getModel = Console.ReadLine()) != "Close the Catalogue")
            {
                Vehicle vehicle = vehicles.FirstOrDefault(v => v.Model.Equals(getModel));

                if (vehicle is null)
                {
                    throw new NullReferenceException("Non existent vehicle!");
                }

                Console.WriteLine(vehicle.ToString());
            }

            string averageHorsepower = GetAverageHorsePower(ref vehicles);
            Console.WriteLine(averageHorsepower);
        }

        private static string GetAverageHorsePower(ref List<Vehicle> vehicles)
        {
            string carTypeName = nameof(Car);
            string truckTypeName = nameof(Truck);

            double carsAvgHP = vehicles.Where(t => t.GetType().Name.Equals(carTypeName)).Average(v => v.HorsePower);
            double trucksAvgHP = vehicles.Where(t => t.GetType().Name.Equals(truckTypeName)).Average(v => v.HorsePower);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{carTypeName}s have average horsepower of: {carsAvgHP:f2}.");
            sb.AppendLine($"{truckTypeName}s have average horsepower of: {trucksAvgHP:f2}.");

            return sb.ToString().TrimEnd();
        }

        private static void CreateAndAddVehicle(ref List<Vehicle> vehicles, string typeOfVehicle, string model, string color, double horsePower)
        {
            Vehicle vehicle;

            switch (typeOfVehicle.ToLower())
            {
                case "car":
                    vehicle = new Car(model, color, horsePower);

                    break;
                case "truck":
                    vehicle = new Truck(model, color, horsePower);

                    break;

                default:
                    throw new InvalidOperationException();
            }

            vehicles.Add(vehicle);
        }
    }

    abstract class Vehicle
    {
        public Vehicle(string model, string color, double horsePower)
        {
            this.Model = model;
            this.Color = color;
            this.HorsePower = horsePower;
        }

        public string Model { get; private set; }
        public string Color { get; private set; }
        public double HorsePower { get; private set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Type: {this.GetType().Name}");
            sb.AppendLine($"Model: {this.Model}");
            sb.AppendLine($"Color: {this.Color}");
            sb.AppendLine($"Horsepower: {this.HorsePower}");

            return sb.ToString().TrimEnd();
        }

    }

    internal class Car : Vehicle
    {
        public Car(string model, string color, double horsePower) : base(model, color, horsePower) { }

    }

    internal class Truck : Vehicle
    {
        public Truck(string model, string color, double horsePower) : base(model, color, horsePower) { }
    }
}
