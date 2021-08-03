namespace _02.VehiclesExtension.Models
{
    internal class Bus : Vehicle
    {
        private const double AirConditionerConsumption = 1.4;

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, AirConditionerConsumption, tankCapacity) { }
    }
}
