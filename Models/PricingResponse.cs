namespace HotelPricingEngine.Models
{
    public class PricingResponse
    {
        public string? RoomType { get; set; }
        public decimal BasePrice { get; set; }
        public decimal AdjustedPrice { get; set; }
    }
}
