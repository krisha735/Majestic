public class Itinerary
{
    public int Id { get; set; }
    public string User { get; set; }
    public List<Place> Items { get; set; } = new List<Place>();
}
