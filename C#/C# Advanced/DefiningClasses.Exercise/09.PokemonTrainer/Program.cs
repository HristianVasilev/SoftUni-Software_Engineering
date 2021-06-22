using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _09.PokemonTrainer
{
    class Program
    {
        static void Main(string[] args)
        {
            Trainer[] trainers = GenerateTrainers();

            TreatTrainers(ref trainers);

            string result = GetResult(trainers);
            Console.WriteLine(result);
        }

        private static string GetResult(Trainer[] trainers)
        {
            StringBuilder sb = new StringBuilder();

            var ordered = trainers.OrderByDescending(x => x.NumberOfBadges);
             

            foreach (var trainer in ordered)
            {
                sb.AppendLine(trainer.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        private static void TreatTrainers(ref Trainer[] trainers)
        {
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string element = input;

                foreach (var trainer in trainers)
                {
                    if (trainer.Pokemons.Count(p => p.Element == element) == 1)
                    {
                        trainer.AddBadge();
                    }
                    else
                    {
                        trainer.DecreaseAllPokemonsHealth(10);
                    }
                }
            }
        }

        private static Trainer[] GenerateTrainers()
        {
            ICollection<Trainer> trainers = new List<Trainer>();

            string input;
            while ((input = Console.ReadLine()) != "Tournament")
            {
                string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string trainerName = tokens[0];
                string pokemonName = tokens[1];
                string pokemonElement = tokens[2];
                int pokemonHealth = int.Parse(tokens[3]);

                Trainer trainer = trainers.FirstOrDefault(x => x.Name == trainerName);

                if (trainer == null)
                {
                    trainer = new Trainer(trainerName);
                }

                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
                trainer.AddPokemon(pokemon);

                if (trainers.All(x => x.Name != trainerName))
                {
                    trainers.Add(trainer);
                }
            }

            return trainers.ToArray();
        }
    }
}
