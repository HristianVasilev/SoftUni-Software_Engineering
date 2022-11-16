namespace WebShopDemo.Api.Controllers
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using WebShopDemo.Core.Contracts;
    using WebShopDemo.Core.Models;

    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns>json array</returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(200, StatusCode = StatusCodes.Status200OK, Type = typeof(IEnumerable<ProductDto>))]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await productService.GetAll());
        }
    }
}
