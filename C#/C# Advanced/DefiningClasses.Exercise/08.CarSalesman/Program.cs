using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _08.CarSalesman
{
    class Program
    {
        static void Main(string[] args)
        {
            Engine[] engines = GenerateEngines();
            Car[] cars = GenerateCars(engines);

            string result = GetResult(cars);
            Console.WriteLine(result);
        }

        private static string GetResult(Car[] cars)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var car in cars)
            {
                sb.AppendLine(car.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        private static Car[] GenerateCars(Engine[] engines)
        {
            int m = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < m; i++)
            {
                string[] tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = tokens[0];
                Engine engine = engines.FirstOrDefault(x => x.Model == tokens[1]);

                if (engine == null)
                {
                    Console.WriteLine("This engine doesn't exists!");
                    continue;
                }

                int weight;
                string color;

                Car car;

                if (tokens.Length == 2)
                {
                    car = new Car(model, engine);
                }
                else if (tokens.Length == 3 && AllDigits(tokens[2]))
                {
                    weight = int.Parse(tokens[2]);
                    car = new Car(model, engine, weight);
                }
                else if (tokens.Length == 3 && !AllDigits(tokens[2]))
                {
                    color = tokens[2];
                    car = new Car(model, engine, color);
                }
                else if (tokens.Length == 4)
                {
                    weight = int.Parse(tokens[2]);
                    color = tokens[3];
                    car = new Car(model, engine, weight, color);
                }
                else
                {
                    throw new ArgumentException("Invalid arguments!");
                }

                cars.Add(car);
            }

            return cars.ToArray();
        }

        private static Engine[] GenerateEngines()
        {
            int n = int.Parse(Console.ReadLine());

            List<Engine> engines = new List<Engine>();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = tokens[0];
                int power = int.Parse(tokens[1]);
                int displacement;
                string efficiency;

                Engine engine;

                if (tokens.Length == 2)
                {
                    engine = new Engine(model, power);
                }
                else if (tokens.Length == 3 && AllDigits(tokens[2]))
                {
                    displacement = int.Parse(tokens[2]);
                    engine = new Engine(model, power, displacement);
                }
                else if (tokens.Length == 3 && !AllDigits(tokens[2]))
                {
                    efficiency = tokens[2];
                    engine = new Engine(model, power, efficiency);
                }
                else if (tokens.Length == 4)
                {
                    displacement = int.Parse(tokens[2]);
                    efficiency = tokens[3];
                    engine = new Engine(model, power, displacement, efficiency);
                }
                else
                {
                    throw new ArgumentException("Invalid input!");
                }

                engines.Add(engine);
            }

            return engines.ToArray();
        }

        private static bool AllDigits(string element)
        {
            return element.ToCharArray().All(c => char.IsDigit(c));
        }

    }
}
