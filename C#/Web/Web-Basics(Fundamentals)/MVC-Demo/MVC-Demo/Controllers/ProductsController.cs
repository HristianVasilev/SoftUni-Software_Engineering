namespace MVC_Demo.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Net.Http.Headers;
    using MVC_Demo.Models;
    using System.Text;
    using System.Text.Json;

    public class ProductsController : Controller
    {
        private IEnumerable<ProductViewModel> products = new List<ProductViewModel>()
        {
            new ProductViewModel(205066,"Beer", 1.69),
            new ProductViewModel(173044, "Pizza", 9.39),
            new ProductViewModel(294033, "Ice cream", 2.09)
        };

        [ActionName("My-Products")]
        public IActionResult All(string keyword)
        {
            IEnumerable<ProductViewModel> products = this.products;
            if (keyword != null)
            {
                products = this.products.Where(pr => pr.Name.ToLower().Contains(keyword.ToLower()));
            }
            return View(products);
        }

        public IActionResult ById(int id)
        {
            var product = this.products.FirstOrDefault(p => p.Id.Equals(id));
            if (product is null)
            {
                return BadRequest();
            }
            return View(product);
        }

        public IActionResult AllAsJson()
        {
            var jsonOptions = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            return Json(products, jsonOptions);
        }

        public IActionResult AllAsText()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var pr in this.products)
            {
                stringBuilder.AppendLine(pr.ToString());
            }
            return Content(stringBuilder.ToString().TrimEnd());
        }

        public IActionResult AllAsTextFile()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var pr in this.products)
            {
                stringBuilder.AppendLine(pr.ToString());
            }
            Response.Headers.Add(HeaderNames.ContentDisposition, @"attachment;filename=products.txt");
            return File(Encoding.UTF8.GetBytes(stringBuilder.ToString().TrimEnd()), "text/plain");
        }
    }
}
