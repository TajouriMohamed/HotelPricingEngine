namespace HotelPricingEngine.Models
{
    public class RoomAllocationResponse
    {
        public string? RoomType { get; set; }
        public int? AllocatedRoomId { get; set; }
        public decimal? TotalPrice { get; set; }
        public SpecialRequests? SpecialRequests { get; set; }
    }
}
