namespace WebShopDemo.Core.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using WebShopDemo.Core.Models;

    /// <summary>
    /// Manipulates product data
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Gets all products
        /// </summary>
        /// <returns>Collection of products</returns>
        Task<IEnumerable<ProductDto>> GetAll();
    }
}
