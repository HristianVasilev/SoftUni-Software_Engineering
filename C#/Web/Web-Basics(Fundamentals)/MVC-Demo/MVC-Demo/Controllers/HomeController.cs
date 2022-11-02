namespace MVC_Demo.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MVC_Demo.Models;
    using System.Diagnostics;

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Message = "Hello World!";
            return View();
        }

        public IActionResult About()
        {
            ViewBag.Message = "This is an ASP.NET Core MVC app.";
            return View();
        }

        public IActionResult Numbers()
        {
            ViewBag.Message = "Numbers from 1 to 50";
            return View();
        }

        public IActionResult NumbersToN(int count = 3)
        {
            ViewBag.Count = count;
            ViewBag.Message = $"Numbers from 1 to {ViewBag.Count}";
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}