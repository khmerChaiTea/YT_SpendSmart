using Microsoft.AspNetCore.Mvc;
using SpendSmart.Models;
using System.Diagnostics;

namespace SpendSmart.Controllers
{
    public class HomeController : Controller
    {
        // Private field to hold the logger instance for this controller.
        private readonly ILogger<HomeController> _logger;

        // Constructor to initialize the HomeController with a logger instance.
        // Dependency injection is used to provide the logger.
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Action method to handle requests for the Index view.
        // This method returns the default view associated with the Index action.
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Expenses()
        {
            return View();
        }

        // Action method to handle requests for the Privacy view.
        // This method returns the default view associated with the Privacy action.
        public IActionResult Privacy()
        {
            return View();
        }

        // Action method to handle requests for the Error view.
        // This method is decorated with the [ResponseCache] attribute to specify caching behavior.
        // It creates an ErrorViewModel with the current request ID or trace identifier.
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            // Return the Error view with an ErrorViewModel containing the request ID.
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

