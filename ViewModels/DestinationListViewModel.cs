using Majestic.Models; 

namespace Majestic.ViewModels
{
    public class DestinationListViewModel
    {
        public List<Destination> Destinations { get; set; }
        public bool IsAdmin { get; set; }
    }
}
