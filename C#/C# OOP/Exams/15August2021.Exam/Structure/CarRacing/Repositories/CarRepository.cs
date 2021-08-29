namespace CarRacing.Repositories
{
    using CarRacing.Models.Cars.Contracts;
    using CarRacing.Repositories.Contracts;
    using CarRacing.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CarRepository : IRepository<ICar>
    {
        private ICollection<ICar> models;

        public CarRepository()
        {
            this.models = new List<ICar>();
        }

        public IReadOnlyCollection<ICar> Models => this.models as IReadOnlyCollection<ICar>;


        public void Add(ICar model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidAddCarRepository);
            }

            this.models.Add(model);
        }

        public bool Remove(ICar model)
        {
            return this.models.Remove(model);
        }

        public ICar FindBy(string property)
        {
            return this.models.FirstOrDefault(c => c.VIN == property);
        }
    }
}
