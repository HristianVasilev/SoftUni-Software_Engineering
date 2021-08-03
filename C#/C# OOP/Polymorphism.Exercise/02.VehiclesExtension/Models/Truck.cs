using System;

namespace _02.VehiclesExtension.Models
{
    public class Truck : Vehicle
    {
        private const double AirConditionerConsumption = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, AirConditionerConsumption, tankCapacity) { }

        public override void Refuel(double amountOfFuel, double correctCoefficient = 1.0)
        {
            base.Refuel(amountOfFuel, 0.95);
        }

    }
}
