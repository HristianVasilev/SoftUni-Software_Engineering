

namespace AquaShop.Repositories
{
    using AquaShop.Models.Decorations.Contracts;
    using AquaShop.Repositories.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class DecorationRepository : IRepository<IDecoration>
    {
        private ICollection<IDecoration> decorations;
        public DecorationRepository()
        {
            this.decorations = new List<IDecoration>();
        }

        public IReadOnlyCollection<IDecoration> Models => this.decorations as IReadOnlyCollection<IDecoration>;

        public void Add(IDecoration model)
        {
            this.decorations.Add(model);
        }

        public bool Remove(IDecoration model)
        {
            return this.decorations.Remove(model);
        }

        public IDecoration FindByType(string type)
        {
            return this.decorations.FirstOrDefault(x => x.GetType().Name.Equals(type));
        }
    }
}
