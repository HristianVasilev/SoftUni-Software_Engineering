using System;

namespace CarManufacturer
{
    class Car
    {
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;


        public string Make
        {
            get { return make; }
            set { make = value; }
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        public double FuelQuantity
        {
            get { return fuelQuantity; }
            set { fuelQuantity = value; }
        }

        public double FuelConsumption
        {
            get { return fuelConsumption; }
            set { fuelConsumption = value; }
        }

        public void Drive(double distance)
        {
            if (this.FuelQuantity - distance * this.FuelConsumption <= 0)
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
                return;
            }

            this.FuelQuantity -= distance * this.FuelConsumption;
        }

        public string WhoAmI()
        {
            return $"Make: {this.Make}{Environment.NewLine}Model: {this.Model}{Environment.NewLine}Year: {this.Year}{Environment.NewLine}Fuel: {this.FuelQuantity:F2}";
        }
    }
}
