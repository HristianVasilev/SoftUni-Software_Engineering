using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _4.RawData
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int countOfCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfCars; i++)
            {
                string[] carArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = carArgs[0];
                double engineSpeed = double.Parse(carArgs[1]);
                double enginePower = double.Parse(carArgs[2]);
                double cargoWeight = double.Parse(carArgs[3]);
                string cargoType = carArgs[4];

                Car car = new Car(model, engineSpeed, enginePower, cargoWeight, cargoType);
                cars.Add(car);
            }

            string cargo = Console.ReadLine();
            string carsInfo = GetCarsWith(ref cars, cargo);
            Console.WriteLine(carsInfo);
        }

        private static string GetCarsWith(ref List<Car> cars, string cargo)
        {
            Func<Car, bool> predicate;

            switch (cargo)
            {
                case "fragile":
                    predicate = c => c.Cargo.CargoType.Equals(cargo) && c.Cargo.CargoWeight < 1000;

                    break;
                case "flamable":
                    predicate = c => c.Cargo.CargoType.Equals(cargo) && c.Engine.EnginePower > 250;

                    break;

                default:
                    throw new InvalidOperationException();
            }

            cars = cars.Where(predicate).ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var car in cars)
            {
                sb.AppendLine(car.Model);
            }

            return sb.ToString().TrimEnd();
        }
    }

    class Car
    {
        public Car(string model, double engineSpeed, double enginePower, double cargoWeight, string cargoType)
        {
            this.Model = model;
            this.Engine = new Engine(engineSpeed, enginePower);
            this.Cargo = new Cargo(cargoWeight, cargoType);
        }

        public string Model { get; private set; }
        public Engine Engine { get; private set; }
        public Cargo Cargo { get; private set; }

    }

    class Engine
    {
        public Engine(double engineSpeed, double enginePower)
        {
            this.EngineSpeed = engineSpeed;
            this.EnginePower = enginePower;
        }

        public double EngineSpeed { get; }
        public double EnginePower { get; }
    }

    class Cargo
    {
        public Cargo(double cargoWeight, string cargoType)
        {
            this.CargoWeight = cargoWeight;
            this.CargoType = cargoType;
        }

        public double CargoWeight { get; }
        public string CargoType { get; }
    }

}
