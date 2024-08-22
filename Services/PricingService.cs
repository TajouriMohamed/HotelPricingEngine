using HotelPricingEngine.Models;

namespace HotelPricingEngine.Services
{
    public class PricingService
    {
        public PricingResponse CalculatePrice(PricingRequest request)
        {
            decimal basePrice = GetBasePrice(request.RoomType);
            decimal adjustedPrice = basePrice;

            // Apply Seasonality Factor
            adjustedPrice = ApplySeasonalityFactor(adjustedPrice, request.Season);

            // Apply Occupancy Rate Factor
            adjustedPrice = ApplyOccupancyRateFactor(adjustedPrice, request.OccupancyRate);

            return new PricingResponse
            {
                RoomType = request.RoomType,
                BasePrice = basePrice,
                AdjustedPrice = adjustedPrice
            };
        }

        private static decimal GetBasePrice(string roomType) => roomType switch
        {
            "Standard" => 100,
            "Deluxe" => 150,
            "Suite" => 250,
            _ => throw new ArgumentException("Invalid room type")
        };

        private static decimal ApplySeasonalityFactor(decimal price, string season)
        {
            return season switch
            {
                "Off-Season" => price * 0.80M, // Reduce by 20%
                "Peak Season" => price * 1.30M, // Increase by 30%
                _ => price
            };
        }

        private static decimal ApplyOccupancyRateFactor(decimal price, int occupancyRate)
        {
            if (occupancyRate <= 30)
            {
                return price * 0.90M; // Reduce by 10%
            }
            else if (occupancyRate >= 71)
            {
                return price * 1.20M; // Increase by 20%
            }
            return price; // No change
        }
    }
}
