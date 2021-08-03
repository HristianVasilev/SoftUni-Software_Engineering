using System;

namespace _02.VehiclesExtension.Models
{
    public abstract class Vehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;
        private double tankCapacity;
        private double airConditionerConsumption;

        public Vehicle(double fuelQuantity, double fuelConsumption, double airConditionerConsumption, double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            this.AirConditionerConsumption = airConditionerConsumption;
        }

        public double FuelQuantity
        {
            get { return fuelQuantity; }
            protected set
            {
                if (value > this.TankCapacity)
                {
                    this.fuelQuantity = 0;
                }
                else
                {
                    fuelQuantity = value;
                }
            }
        }

        public double FuelConsumption
        {
            get { return fuelConsumption; }
            set { fuelConsumption = value; }
        }

        public double AirConditionerConsumption
        {
            get { return airConditionerConsumption; }
            set { airConditionerConsumption = value; }
        }

        public double TankCapacity
        {
            get => this.tankCapacity;
            protected set { this.tankCapacity = value; }
        }


        public string Drive(double distance, bool ACisON = true)
        {
            double consumption;

            if (ACisON)
            {
                consumption = this.FuelConsumption + this.AirConditionerConsumption;
            }
            else
            {
                consumption = this.FuelConsumption;
            }

            if (this.fuelQuantity - distance * consumption < 0)
            {
                return $"{this.GetType().Name} needs refueling";
            }

            this.FuelQuantity -= distance * consumption;
            return $"{this.GetType().Name} travelled {distance} km";
        }

        public virtual void Refuel(double amountOfFuel, double correctCoefficient = 1.0)
        {
            if (amountOfFuel <= 0)
            {
                throw new InvalidOperationException("Fuel must be a positive number");
            }

            if (this.FuelQuantity + amountOfFuel > this.TankCapacity)
            {
                throw new InvalidOperationException($"Cannot fit {amountOfFuel} fuel in the tank");
            }

            amountOfFuel = amountOfFuel * correctCoefficient;
            this.FuelQuantity += amountOfFuel;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
