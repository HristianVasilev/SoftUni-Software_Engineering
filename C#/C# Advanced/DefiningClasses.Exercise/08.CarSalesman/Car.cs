using System;
using System.Collections.Generic;
using System.Text;

namespace _08.CarSalesman
{
    class Car
    {
        private string model;
        private Engine engine;
        private int? weight = null;
        private string color = null;

        public Car(string model, Engine engine)
        {
            this.Model = model;
            this.Engine = engine;
        }

        public Car(string model, Engine engine, int weight) : this(model, engine)
        {
            this.Weight = weight;
        }

        public Car(string model, Engine engine, string color) : this(model, engine)
        {
            this.Color = color;
        }

        public Car(string model, Engine engine, int weight, string color) : this(model, engine, weight)
        {
            this.Color = color;
        }

        public string Model
        {
            get => this.model;
            private set => this.model = value;
        }

        public Engine Engine
        {
            get => this.engine;
            private set => this.engine = value;
        }

        public int? Weight
        {
            get => this.weight;
            private set => this.weight = value;
        }

        public string Color
        {
            get => this.color;
            private set => this.color = value;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.Model}:");
            sb.AppendLine($"  {this.Engine.Model}:");
            sb.AppendLine($"    Power: {this.Engine.Power}");
            sb.AppendLine($"    Displacement: {CheckIfAvailable(this.Engine.Displacement)}");
            sb.AppendLine($"    Efficiency: {CheckIfAvailable(this.Engine.Efficiency)}");
            sb.AppendLine($"  Weight: { CheckIfAvailable(this.Weight)}");
            sb.AppendLine($"  Color: {CheckIfAvailable(this.Color)}");

            return sb.ToString().TrimEnd();
        }

        private string CheckIfAvailable(object? element)
        {
            return element == null ? "n/a" : element.ToString();
        }
    }
}
