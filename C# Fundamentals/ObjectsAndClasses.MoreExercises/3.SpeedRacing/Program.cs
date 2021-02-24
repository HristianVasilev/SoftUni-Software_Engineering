using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.SpeedRacing
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
                double fuelAmount = double.Parse(carArgs[1]);
                double fuelConsumption = double.Parse(carArgs[2]);

                Car car = new Car(model, fuelAmount, fuelConsumption);
                cars.Add(car);
            }

            string driveCommand = string.Empty;
            while ((driveCommand = Console.ReadLine()) != "End")
            {
                string[] driveArgs = driveCommand.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = driveArgs[1];
                double distance = double.Parse(driveArgs[2]);

                Car car = cars.FirstOrDefault(c => c.Model == model);

                if (car is null )
                {
                    throw new ArgumentNullException();
                }

                try
                {
                    car.Drive(distance);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
            }

            Print(ref cars);
        }

        private static void Print(ref List<Car> cars)
        {
            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }

    class Car
    {
        public Car(string model, double fuelAmount, double fuelConsumption)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumption = fuelConsumption;
            this.TraveledDistance = 0;
        }

        public string Model { get; private set; }
        public double FuelAmount { get; private set; }
        public double FuelConsumption { get; private set; }
        public double TraveledDistance { get; private set; }

        public void Drive(double distance)
        {
            if (this.FuelAmount - this.FuelConsumption * distance < 0)
            {
                throw new InvalidOperationException("Insufficient fuel for the drive");
            }

            this.FuelAmount -= this.FuelConsumption * distance;
            this.TraveledDistance += distance;
        }

        public override string ToString()
        {
            return $"{this.Model} {this.FuelAmount:f2} {this.TraveledDistance}";
        }
    }
}
