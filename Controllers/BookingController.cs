using Microsoft.AspNetCore.Mvc;

public class BookingController : Controller
{
    public IActionResult Index() => View();

    [HttpPost]
    public IActionResult Confirm(Booking booking)
    {
        decimal basePrice = 500; // Example fixed base price
        if (booking.PromoCode == "MAJESTIC10")
            booking.FinalPrice = basePrice * 0.9m;
        else
            booking.FinalPrice = basePrice;

        return View("Confirmation", booking);
    }
}
