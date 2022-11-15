namespace WebShopDemo.Core.Services
{
    using Microsoft.Extensions.Configuration;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using WebShopDemo.Core.Contracts;
    using WebShopDemo.Core.Models;

    public class ProductService : IProductService
    {
        private readonly IConfiguration config;

        /// <summary>
        /// Inversion of control (IoC)
        /// </summary>
        /// <param name="config">Application configuration</param>
        public ProductService(IConfiguration config)
        {
            this.config = config;
        }

        /// <summary>
        /// Gets all products
        /// </summary>
        /// <returns>Collection of products</returns>
        public async Task<IEnumerable<ProductDto>> GetAll()
        {
            string dataPath = config.GetSection("DataFiles:products").Value;
            //string dataPath = "Data/products.json";

            string data = await File.ReadAllTextAsync(dataPath);
            return JsonConvert.DeserializeObject<IEnumerable<ProductDto>>(data);
        }
    }
}
