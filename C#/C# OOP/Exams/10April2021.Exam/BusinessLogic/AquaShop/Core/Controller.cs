namespace AquaShop.Core
{
    using AquaShop.Core.Contracts;
    using AquaShop.Models.Aquariums.Contracts;
    using AquaShop.Models.Aquariums.Models;
    using AquaShop.Models.Decorations.Contracts;
    using AquaShop.Models.Decorations.Models;
    using AquaShop.Models.Fish.Contracts;
    using AquaShop.Models.Fish.Models;
    using AquaShop.Repositories;
    using AquaShop.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Controller : IController
    {
        private DecorationRepository decorationRepository;
        private ICollection<IAquarium> aquariums;

        public Controller()
        {
            this.decorationRepository = new DecorationRepository();
            this.aquariums = new List<IAquarium>();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium;

            switch (aquariumType)
            {
                case nameof(FreshwaterAquarium):
                    aquarium = new FreshwaterAquarium(aquariumName);
                    break;
                case nameof(SaltwaterAquarium):
                    aquarium = new SaltwaterAquarium(aquariumName);
                    break;

                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }

            this.aquariums.Add(aquarium);

            return String.Format(OutputMessages.SuccessfullyAdded, aquariumType);
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decoration;

            switch (decorationType)
            {
                case nameof(Ornament):
                    decoration = new Ornament();
                    break;
                case nameof(Plant):
                    decoration = new Plant();
                    break;

                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }

            this.decorationRepository.Add(decoration);

            return String.Format(OutputMessages.SuccessfullyAdded, decorationType);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            IAquarium aquarium = this.aquariums.FirstOrDefault(x => x.Name.Equals(aquariumName));
            // potential bug
            if (aquarium == null)
            {
                throw new InvalidOperationException($"There isn't an aquarium with name {aquariumName}");
            }

            IDecoration decoration = this.decorationRepository.FindByType(decorationType);

            if (decoration == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InexistentDecoration, decorationType));
            }

            aquarium.AddDecoration(decoration);
            this.decorationRepository.Remove(decoration);

            return String.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IAquarium aquarium = this.aquariums.FirstOrDefault(x => x.Name.Equals(aquariumName));

            IFish fish;

            switch (fishType)
            {
                case nameof(FreshwaterFish):
                    fish = new FreshwaterFish(fishName, fishSpecies, price);
                    break;
                case nameof(SaltwaterFish):
                    fish = new SaltwaterFish(fishName, fishSpecies, price);
                    break;

                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }

            if (!FishCanLiveInAquarium(aquarium, fish))
            {
                return OutputMessages.UnsuitableWater;
            }

            aquarium.AddFish(fish);
            return String.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
        }

        public string FeedFish(string aquariumName)
        {
            IAquarium aquarium = this.aquariums.FirstOrDefault(x => x.Name.Equals(aquariumName));
            // potential bug
            if (aquarium == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }

            aquarium.Feed();
            return String.Format(OutputMessages.FishFed, aquarium.Fish.Count);
        }

        public string CalculateValue(string aquariumName)
        {
            IAquarium aquarium = this.aquariums.FirstOrDefault(x => x.Name.Equals(aquariumName));
            // potential bug
            if (aquarium == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }

            decimal value = aquarium.Fish.Sum(x => x.Price) + aquarium.Decorations.Sum(x => x.Price); ;
            return String.Format(OutputMessages.AquariumValue, aquariumName, value);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (IAquarium aquarium in this.aquariums)
            {
                sb.AppendLine(aquarium.GetInfo());
            }

            return sb.ToString().TrimEnd();
        }

        private bool FishCanLiveInAquarium(IAquarium aquarium, IFish fish)
        {
            return aquarium is FreshwaterAquarium && fish is FreshwaterFish
                || aquarium is SaltwaterAquarium && fish is SaltwaterFish;
        }
    }
}
