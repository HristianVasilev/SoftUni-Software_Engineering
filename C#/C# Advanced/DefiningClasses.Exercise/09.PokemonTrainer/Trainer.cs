using System;
using System.Collections.Generic;
using System.Text;

namespace _09.PokemonTrainer
{
    class Trainer
    {
        private const int defaultNumberOfBadges = 0;

        private string name;
        private int numberOfBadges;
        private List<Pokemon> pokemons;

        public Trainer(string name)
        {
            this.Name = name;
            this.NumberOfBadges = defaultNumberOfBadges;
            this.Pokemons = new List<Pokemon>();
        }

        public string Name
        {
            get => this.name;
            set => this.name = value;
        }

        public int NumberOfBadges
        {
            get => this.numberOfBadges;
            set => this.numberOfBadges = value;
        }


        public List<Pokemon> Pokemons
        {
            get => this.pokemons;
            set => this.pokemons = value;
        }

        public void AddPokemon(Pokemon pokemon)
        {
            this.Pokemons.Add(pokemon);
        }

        public void AddBadge()
        {
            this.NumberOfBadges++;
        }

        public void DecreaseAllPokemonsHealth(int value)
        {
            for (int i = 0; i < this.Pokemons.Count; i++)
            {
                Pokemon pokemon = this.Pokemons[i];

                if (pokemon.Health - value <= 0)
                {
                    this.Pokemons.Remove(pokemon);
                    i--;
                    continue;
                }

                pokemon.DecreaseHealth(value);
            }
        }

        public override string ToString()
        {
            return $"{this.Name} {this.NumberOfBadges} {this.Pokemons.Count}";
        }
    }
}
