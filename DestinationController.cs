using Majestic.Models;
using Majestic.ViewModels; // Reference your ViewModels namespace
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Majestic.Controllers
{
    public class DestinationController : Controller
    {
        private List<Destination> destinations = new List<Destination>
        {
            new Destination { Id = 1, Name = "Bali, Indonesia", Description = "Experience the Island of the Gods", Package = "5 Days 4 Nights Bali Getaway!", ImageUrl = "~/Images/bali.jpg" },
            new Destination { Id = 2, Name = "Paris, France", Description = "The City of Lights", Package = "7 Days 6 Nights Paris Escape!", ImageUrl = "~/Images/paris.jpg" },
            new Destination { Id = 3, Name = "Langkawi", Description = "Explore stunning islands", Package = "3 Days 2 Nights Langkawi Package!", ImageUrl = "~/Images/langkawi.jpg" }
        };

        // Action to show the list of destinations
        public ActionResult Index()
        {
            bool isAdmin = User.Identity.Name == "admin@majestic.com"; // Logic to determine if the user is admin

            var viewModel = new DestinationListViewModel
            {
                Destinations = destinations,
                IsAdmin = isAdmin
            };

            return View(viewModel); // Pass the view model to the view
        }

        // Action to edit a destination
        public ActionResult Edit(int id)
        {
            var destination = destinations.Find(d => d.Id == id);
            return View(destination);
        }

        // POST method for editing a destination
        [HttpPost]
        public ActionResult Edit(Destination destination)
        {
            if (ModelState.IsValid)
            {
                var existingDestination = destinations.Find(d => d.Id == destination.Id);
                if (existingDestination != null)
                {
                    existingDestination.Name = destination.Name;
                    existingDestination.Description = destination.Description;
                    existingDestination.Package = destination.Package;
                    existingDestination.ImageUrl = destination.ImageUrl;
                }

                return RedirectToAction("Index");
            }

            return View(destination);
        }

        // Action to delete a destination
        public ActionResult Delete(int id)
        {
            var destination = destinations.Find(d => d.Id == id);
            destinations.Remove(destination);
            return RedirectToAction("Index");
        }

        // Action to add a new destination
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Destination destination)
        {
            if (ModelState.IsValid)
            {
                destinations.Add(destination);
                return RedirectToAction("Index");
            }

            return View(destination);
        }
    }
}
