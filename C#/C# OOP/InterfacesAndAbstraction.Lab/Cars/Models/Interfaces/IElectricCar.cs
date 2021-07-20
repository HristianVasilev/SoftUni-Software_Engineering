namespace Cars.Models.Interfaces
{
    interface IElectricCar : ICar
    {
        public int Battery { get; }
    }
}
