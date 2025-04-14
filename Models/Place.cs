public class Place
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; } // e.g., Hotel, Attraction
    public double EstimatedCost { get; set; }
    public TimeSpan EstimatedTime { get; set; }
}
