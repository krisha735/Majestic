public class Booking
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Type { get; set; } // Flight, Hotel, Tour
    public DateTime Date { get; set; }
    public string PromoCode { get; set; }
    public decimal FinalPrice { get; set; }
}
