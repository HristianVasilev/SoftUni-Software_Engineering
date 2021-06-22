using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06.SpeedRacing
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = GenerateCars();

            DriveCars(ref cars);
            string result = GetResult(cars);
            Console.WriteLine(result);
        }

        private static string GetResult(List<Car> cars)
        {
            StringBuilder sb = new StringBuilder();

            foreach (Car car in cars)
            {
                sb.AppendLine(car.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        private static void DriveCars(ref List<Car> cars)
        {
            string commandInput;
            while ((commandInput = Console.ReadLine()) != "End")
            {
                try
                {
                    string[] tokens = commandInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    string command = tokens[0];
                    string carModel = tokens[1];
                    int distance = int.Parse(tokens[2]);

                    Car car = cars.FirstOrDefault(x => x.Model.Equals(carModel));

                    if (car == null)
                    {
                        throw new ArgumentNullException("The car model is unavailable!");
                    }

                    car.Drive(distance);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
            
        }

        private static List<Car> GenerateCars()
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = tokens[0];
                double fuelAmount = double.Parse(tokens[1]);
                double fuelConsumptionPerKilometer = double.Parse(tokens[2]);

                Car car = new Car(model, fuelAmount, fuelConsumptionPerKilometer);
                cars.Add(car);
            }

            return cars;
        }
    }
}
