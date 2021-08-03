using System;

namespace _01.Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double ACFuelConsumption = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity, fuelConsumption + ACFuelConsumption) { }

        public override void Refuel(double amount)
        {
            this.FuelQuantity += 0.95 * amount;
        }

    }
}
