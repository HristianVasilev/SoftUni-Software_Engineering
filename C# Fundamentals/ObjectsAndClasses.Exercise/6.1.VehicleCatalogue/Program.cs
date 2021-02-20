using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _6._1.VehicleCatalogue
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

                CreateAndAddVehicle(ref vehicles, typeOfVehicle, typeOfVehicle, model, color, horsePower);
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

            double carsAvgHP = vehicles.Where(t => t.Type.ToLower().Equals("car")).Average(v => v.HorsePower);
            double trucksAvgHP = vehicles.Where(t => t.Type.ToLower().Equals("truck")).Average(v => v.HorsePower);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Cars have average horsepower of: {carsAvgHP:f2}.");
            sb.AppendLine($"Trucks have average horsepower of: {trucksAvgHP:f2}.");

            return sb.ToString().TrimEnd();
        }

        private static void CreateAndAddVehicle(ref List<Vehicle> vehicles, string type, string typeOfVehicle, string model, string color, double horsePower)
        {
            type = type.Substring(0, 1).ToUpper() + type.Substring(1, type.Length-1);
            Vehicle vehicle = new Vehicle(type, model, color, horsePower);

            vehicles.Add(vehicle);
        }
    }

    class Vehicle
    {
        public Vehicle(string type, string model, string color, double horsePower)
        {
            this.Type = type;
            this.Model = model;
            this.Color = color;
            this.HorsePower = horsePower;
        }

        public string Type { get; private set; }
        public string Model { get; private set; }
        public string Color { get; private set; }
        public double HorsePower { get; private set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Type: {this.Type}");
            sb.AppendLine($"Model: {this.Model}");
            sb.AppendLine($"Color: {this.Color}");
            sb.AppendLine($"Horsepower: {this.HorsePower}");

            return sb.ToString().TrimEnd();
        }
    }
}
