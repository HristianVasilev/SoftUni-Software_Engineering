using System.Collections.Generic;

namespace _03.ShoppingSpree.Models
{
    public interface IPerson
    {
        public string Name { get; }
        public decimal Money { get; }
        public IReadOnlyCollection<Product> Products { get; }
    }
}