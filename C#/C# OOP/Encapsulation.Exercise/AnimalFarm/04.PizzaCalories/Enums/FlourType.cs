using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.PizzaCalories.Enums
{
    public class FlourType
    {
        private static ICollection<KeyValuePair<string, double>> collection;
        private KeyValuePair<string, double> properties;

        public FlourType(string flourType)
        {
            collection = new KeyValuePair<string, double>[]
            {
            new KeyValuePair<string, double>("white", 1.5),
            new KeyValuePair<string, double>("wholegrain", 1.0),
            };

            TryCreate(flourType);
        }

        public string Name => this.properties.Key;
        public double Modifier => this.properties.Value;

        private void TryCreate(string element)
        {
            this.properties = collection.First(x => x.Key.Equals(element));
        }
    }
}
