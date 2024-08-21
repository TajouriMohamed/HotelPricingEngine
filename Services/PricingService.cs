using HotelPricingEngine.Models;

namespace HotelPricingEngine.Services
{
    public class PricingService
    {
        public decimal CalculatePrice(Room room)
        {
            decimal finalPrice = room.BasePrice;
            finalPrice += finalPrice * room.SeasonalityFactor;
            finalPrice += finalPrice * room.OccupancyRateFactor;
            finalPrice += finalPrice * room.CompetitorAdjustmentFactor;

            return finalPrice;
        }

        public decimal GetSeasonalityFactor(string season)
        {
            return season switch
            {
                "Off-Season" => -0.2m,
                "Peak Season" => 0.3m,
                _ => 0m
            };
        }

        public decimal GetOccupancyRateFactor(int occupancyRate)
        {
            if (occupancyRate <= 30) return -0.1m;
            if (occupancyRate <= 70) return 0m;
            return 0.2m;
        }
    }
}
