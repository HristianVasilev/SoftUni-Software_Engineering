using System;
using System.Collections.Generic;
using System.Text;

namespace _07.RawData
{
    class Cargo
    {
        public Cargo(int Weight, string Type)
        {
            this.Weight = Weight;
            this.Type = Type;
        }

        public int Weight { get; }
        public string Type { get; }
    }
}
