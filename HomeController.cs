using System.Diagnostics;
using Majestic.Models;
using Majestic.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Majestic.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // Mock data for destinations
            var destinations = new List<Destination>
            {
                new Destination { Id = 1, Name = "Bali", Description = "Island of the Gods", Package = "5D4N", ImageUrl = "~/Images/bali.jpg" },
                new Destination { Id = 2, Name = "Paris", Description = "City of Lights", Package = "7D6N", ImageUrl = "~/Images/paris.jpg" },
                new Destination { Id = 3, Name = "Langkawi", Description = "Beautiful islands", Package = "3D2N", ImageUrl = "~/Images/langkawi.jpg" }
            };

            // Check if the user is admin (you can adjust this to a more robust check later)
            bool isAdmin = User.Identity.Name == "admin@majestic.com";

            // Create the ViewModel
            var viewModel = new DestinationListViewModel
            {
                Destinations = destinations,
                IsAdmin = isAdmin
            };

            // Pass the viewModel to the View
            return View(viewModel);
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
