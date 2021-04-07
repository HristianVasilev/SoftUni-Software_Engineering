using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace _7.VehicleCatalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            Catalog catalog = new Catalog();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] vehicleArgs = input.Split('/', StringSplitOptions.RemoveEmptyEntries);

                string type = vehicleArgs[0];
                string brand = vehicleArgs[1];
                string model = vehicleArgs[2];

                switch (type)
                {
                    case "Truck":
                        string weight = vehicleArgs[3];
                        Truck truck = new Truck(brand, model, weight);
                        catalog.TruckCollection.Add(truck);

                        break;
                    case "Car":
                        string horsePower = vehicleArgs[3];
                        Car car = new Car(brand, model, horsePower);
                        catalog.CarCollection.Add(car);

                        break;
                    default:
                        throw new InvalidOperationException();
                }
            }

            PrintResult(ref catalog);
        }

        private static void PrintResult(ref Catalog catalog)
        {
            if (catalog.CarCollection.Count != 0)
            {
                Func<Car, string> carSort = c => c.Brand;
                string carCollection = catalog.GetCarCollection(carSort);

                Console.WriteLine(carCollection);
            }

            if (catalog.TruckCollection.Count != 0)
            {
                Func<Truck, string> truckSort = c => c.Brand;
                string truckCollection = catalog.GetTruckCollection(truckSort);

                Console.WriteLine(truckCollection);
            }
        }
    }

    class Truck
    {
        public Truck(string brand, string model, string weight)
        {
            this.Brand = brand;
            this.Model = model;
            this.Weight = weight;
        }

        public string Brand { get; set; }
        public string Model { get; set; }
        public string Weight { get; set; }

        public override string ToString()
        {
            return $"{Brand}: {Model} - {Weight}kg";
        }
    }

    class Car
    {
        public Car(string brand, string model, string horsePower)
        {
            this.Brand = brand;
            this.Model = model;
            this.HorsePower = horsePower;
        }

        public string Brand { get; set; }
        public string Model { get; set; }
        public string HorsePower { get; set; }

        public override string ToString()
        {
            return $"{Brand}: {Model} - {HorsePower}hp";
        }
    }

    class Catalog
    {
        public Catalog()
        {
            this.TruckCollection = new List<Truck>();
            this.CarCollection = new List<Car>();
        }

        public IList<Truck> TruckCollection { get; set; }

        public IList<Car> CarCollection { get; set; }

        public string GetCarCollection(Func<Car, string> carSort)
        {
            this.CarCollection = CarCollection.OrderBy(carSort).ToList();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Cars:");

            foreach (var car in this.CarCollection)
            {
                sb.AppendLine(car.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public string GetTruckCollection(Func<Truck, string> truckSort)
        {
            this.TruckCollection = TruckCollection.OrderBy(truckSort).ToList();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Trucks:");

            foreach (var truck in this.TruckCollection)
            {
                sb.AppendLine(truck.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
