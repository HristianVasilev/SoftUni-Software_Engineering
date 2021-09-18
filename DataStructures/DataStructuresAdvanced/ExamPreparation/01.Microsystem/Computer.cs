namespace _01.Microsystem
{
    public class Computer
    {
        public Computer(int number, Brand brand, double price, double screenSize, string color)
        {
            this.Number = number;
            this.RAM = 8;
            this.Brand = brand;
            this.Price = price;
            this.ScreenSize = screenSize;
            this.Color = color;
        }
        public int Number { get; set; }

        public int RAM { get; set; }

        public Brand Brand { get; set; }

        public double Price { get; set; }

        public double ScreenSize { get; set; }

        public string Color { get; set; }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            Computer other = (Computer)obj;

            return this.Number == other.Number
                && this.RAM == other.RAM
                && this.Brand == other.Brand
                && this.Price == other.Price
                && this.ScreenSize == other.ScreenSize
                && this.Color == other.Color;
        }
    }
}