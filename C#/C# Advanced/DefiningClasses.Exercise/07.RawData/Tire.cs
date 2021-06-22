using System;
using System.Collections.Generic;
using System.Text;

namespace _07.RawData
{
    class Tire
    {
        public Tire(double Pressure, int Age)
        {
            this.Pressure = Pressure;
            this.Age = Age;
        }

        public double Pressure { get; }
        public int Age { get; }
    }
}
