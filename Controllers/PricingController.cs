using Microsoft.AspNetCore.Mvc;
using HotelPricingEngine.Models;

namespace HotelPricingEngine.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PricingController : ControllerBase
    {
        [HttpPost("calculate")]
        public IActionResult CalculatePrice([FromBody] PricingRequest request)
        {
            decimal basePrice = GetBasePrice(request.RoomType);
            decimal adjustedPrice = basePrice;

            // Apply Seasonality Factor
            adjustedPrice = ApplySeasonalityFactor(adjustedPrice, request.Season);

            // Apply Occupancy Rate Factor
            adjustedPrice = ApplyOccupancyRateFactor(adjustedPrice, request.OccupancyRate);

            // Fetch Competitor Price
            decimal competitorPrice = GetCompetitorPrice(request.CompetitorPrices.First());

            return Ok(new PricingResponse
            {
                RoomType = request.RoomType,
                BasePrice = basePrice,
                AdjustedPrice = adjustedPrice
            });
        }

        private decimal GetBasePrice(string roomType)
        {
            return roomType switch
            {
                "Standard" => 100,
                "Deluxe" => 150,
                "Suite" => 250,
                _ => throw new ArgumentException("Invalid room type")
            };
        }

        private decimal ApplySeasonalityFactor(decimal price, string season)
        {
            return season switch
            {
                "Off-Season" => price * 0.80M, // Reduce by 20%
                "Peak Season" => price * 1.30M, // Increase by 30%
                _ => price
            };
        }

        private decimal ApplyOccupancyRateFactor(decimal price, int occupancyRate)
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

        private decimal GetCompetitorPrice(string competitorName)
        {
            // This method should simulate fetching competitor price.
            // For now, let's return a mock value. 
            // In a real scenario, you'd probably fetch this from a database or another service.
            return competitorName switch
            {
                "Nazl Al Jabal" => 140,
                "Muntasar Al Bahar" => 130,
                _ => 150
            };
        }
    }
}
