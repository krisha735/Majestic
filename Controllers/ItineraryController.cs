using Microsoft.AspNetCore.Mvc;

public class ItineraryController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Save(List<Place> itineraryItems)
    {
        // Save logic
        return Json(new { success = true });
    }
}
