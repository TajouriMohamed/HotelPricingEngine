namespace HotelPricingEngine.Models
{
    public class Room
    {
        public string? RoomType { get; set; }
        public decimal BasePrice { get; set; }
        public decimal SeasonalityFactor { get; set; }
        public decimal OccupancyRateFactor { get; set; }
        public decimal CompetitorAdjustmentFactor { get; set; }
    }
}
