using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.PizzaCalories.Enums
{
    class BakingTechnique
    {
        private static ICollection<KeyValuePair<string, double>> collection;
        private KeyValuePair<string, double> properties;

        public BakingTechnique(string backingTechnique)
        {
            collection = new KeyValuePair<string, double>[]
            {
                new KeyValuePair<string, double>("crispy",0.9),
                new KeyValuePair<string, double>("chewy",1.1),
                new KeyValuePair<string, double>("homemade",1.0),
            };

            TryCreate(backingTechnique);
        }

        public string Name => this.properties.Key;
        public double Modifier => this.properties.Value;

        private void TryCreate(string element)
        {
            this.properties = collection.First(x => x.Key.Equals(element));
        }

    }
}
