namespace HotelPricingEngine.Models
{
    public class RoomAllocationRequest
    {
        public string? RoomType { get; set; }
        public int Nights { get; set; }
        public string? Season { get; set; }
        public SpecialRequests? SpecialRequests { get; set; }
    }

    public class SpecialRequests
    {
        public string? PreferredView { get; set; }
        public bool? ConnectingRoom { get; set; }
    }
}