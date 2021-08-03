namespace _01.Vehicles.Models
{
    class Car : Vehicle
    {
        private const double ACFuelConsumption = 0.9;

        public Car(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity, fuelConsumption + ACFuelConsumption) { }


    }
}
