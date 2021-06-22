using System;
using System.Collections.Generic;
using System.Text;

namespace _06.SpeedRacing
{
    class Car
    {
        private string model;
        private double fuelAmount;
        private double fuelConsumptionPerKilometer;
        private double travelledDistance = 0;

        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
        }


        public string Model
        {
            get => this.model;
            set => this.model = value;
        }

        public double FuelAmount
        {
            get => this.fuelAmount;
            set => this.fuelAmount = value;
        }

        public double FuelConsumptionPerKilometer
        {
            get => this.fuelConsumptionPerKilometer;
            set => this.fuelConsumptionPerKilometer = value;
        }

        public double TravelledDistance
        {
            get => this.travelledDistance;
            set => this.travelledDistance = value;
        }

        public void Drive(int distance)
        {
            if (this.FuelAmount - distance * this.FuelConsumptionPerKilometer < 0)
            {
                throw new ArgumentException("Insufficient fuel for the drive");
            }

            this.FuelAmount -= (distance * this.FuelConsumptionPerKilometer);
            this.TravelledDistance += distance;
        }

        public override string ToString()
        {
            return $"{this.Model} {this.FuelAmount:f2} {this.TravelledDistance}";
        }
    }
}
