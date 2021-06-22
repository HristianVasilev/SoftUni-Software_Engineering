using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.RawData
{
    class Program
    {
        static void Main(string[] args)
        {
            Car[] cars = GenerateCars();

            string filterCommand = Console.ReadLine();
            Car[] filteredCars = FilterCars(filterCommand, cars);
            string result = GetResult(filteredCars);
            Console.WriteLine(result);
        }

        private static string GetResult(Car[] filteredCars)
        {
            IEnumerable<string> carModels = filteredCars.Select(c => c.Model);

            return string.Join(Environment.NewLine, carModels);
        }

        private static Car[] FilterCars(string filterCommand, Car[] cars)
        {
            Func<Car, bool> func;

            switch (filterCommand)
            {
                case "fragile":
                    func = car => car.Cargo.Type == "fragile" && car.Tires.Any(p => p.Pressure < 1);
                    break;
                case "flamable":
                    func = car => car.Cargo.Type == "flamable" && car.Engine.Power > 250;
                    break;

                default:
                    throw new InvalidOperationException("Invalid command!");
            }

            return cars.Where(func).ToArray();
        }

        private static Car[] GenerateCars()
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = tokens[0];
                int engineSpeed = int.Parse(tokens[1]);
                int enginePower = int.Parse(tokens[2]);
                int cargoWeight = int.Parse(tokens[3]);
                string cargoType = tokens[4];

                double tire1Pressure = double.Parse(tokens[5]);
                int tire1Age = int.Parse(tokens[6]);

                double tire2Pressure = double.Parse(tokens[7]);
                int tire2Age = int.Parse(tokens[8]);

                double tire3Pressure = double.Parse(tokens[9]);
                int tire3Age = int.Parse(tokens[10]);

                double tire4Pressure = double.Parse(tokens[11]);
                int tire4Age = int.Parse(tokens[12]);

                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoWeight, cargoType);

                Tire tire1 = new Tire(tire1Pressure, tire1Age);
                Tire tire2 = new Tire(tire2Pressure, tire2Age);
                Tire tire3 = new Tire(tire3Pressure, tire3Age);
                Tire tire4 = new Tire(tire4Pressure, tire4Age);

                Tire[] tires = new Tire[]
                {
                    tire1,
                    tire2,
                    tire3,
                    tire4
                };

                Car car = new Car(model, engine, cargo, tires);
                cars.Add(car);
            }

            return cars.ToArray();
        }
    }
}
