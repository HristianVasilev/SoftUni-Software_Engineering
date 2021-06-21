using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Tire[][] tires = GenerateTires();

            Engine[] engines = GenerateEngines();

            Car[] cars = GenerateCars(tires, engines);

            Car[] specialCars = DriveSpecialCars20km(cars);
            string result = GetResult(specialCars);
            Console.WriteLine(result);
        }

        private static string GetResult(Car[] cars)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var car in cars)
            {
                sb.AppendLine(car.WhoAmI());
            }

            return sb.ToString().TrimEnd();
        }

        private static Car[] DriveSpecialCars20km(Car[] cars)
        {
            Car[] specialCars = cars.Where(y => y.Year >= 2017
                                            && y.Engine.HorsePower > 330
                                            && y.Tires.Sum(p => p.Pressure) >= 9
                                            && y.Tires.Sum(p => p.Pressure) <= 10)
                                    .ToArray();

            foreach (var car in specialCars)
            {
                car.Drive(20d);
            }

            return specialCars;
        }

        private static Car[] GenerateCars(Tire[][] tiresCollection, Engine[] engines)
        {
            List<Car> cars = new List<Car>();

            string input;
            while ((input = Console.ReadLine()) != "Show special")
            {
                string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string make = tokens[0];
                string model = tokens[1];
                int year = int.Parse(tokens[2]);
                int fuelQuantity = int.Parse(tokens[3]);
                double fuelConsumption = double.Parse(tokens[4]);
                int engineIndex = int.Parse(tokens[5]);
                int tiresIndex = int.Parse(tokens[6]);

                Engine engine = engines[engineIndex];
                Tire[] tires = tiresCollection[tiresIndex];

                Car car = new Car(make, model, year, fuelQuantity, fuelConsumption, engine, tires);
                cars.Add(car);
            }

            return cars.ToArray();
        }

        private static Engine[] GenerateEngines()
        {
            List<Engine> engines = new List<Engine>();

            string input;
            while ((input = Console.ReadLine()) != "Engines done")
            {
                string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int horsePower = int.Parse(tokens[0]);
                double cubicCapacity = double.Parse(tokens[1]);

                Engine engine = new Engine(horsePower, cubicCapacity);
                engines.Add(engine);
            }

            return engines.ToArray();
        }

        private static Tire[][] GenerateTires()
        {
            List<Tire[]> tiresCollection = new List<Tire[]>();

            string tireInput;
            while ((tireInput = Console.ReadLine()) != "No more tires")
            {
                Queue<string> tireTokens = new Queue<string>(tireInput.Split(' ', StringSplitOptions.RemoveEmptyEntries));

                Tire[] tires = new Tire[4];

                int i = 0;

                while (tireTokens.Count != 0 && i < tires.Length)
                {
                    int year = int.Parse(tireTokens.Dequeue());
                    double pressure = double.Parse(tireTokens.Dequeue());
                    Tire tire = new Tire(year, pressure);
                    tires[i++] = tire;
                }

                tiresCollection.Add(tires);
            }

            return tiresCollection.ToArray();
        }
    }
}
