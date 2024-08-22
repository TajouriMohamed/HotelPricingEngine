using HotelPricingEngine.Controllers;
using HotelPricingEngine.Models;

namespace HotelPricingEngine.Services
{
    public class RoomAllocationService
    {
        private readonly PricingController _pricingController;
        private static int _nextRoomId = 100; // Mock room ID generator

        public RoomAllocationService(PricingController pricingController)
        {
            _pricingController = pricingController;
        }

        public RoomAllocationResponse AllocateRoom(RoomAllocationRequest request)
        {
            // Call the pricing engine to get the price
            var pricingRequest = new PricingRequest
            {
                RoomType = request.RoomType,
                Season = request.Season,
                OccupancyRate = GetOccupancyRate(request.Season)
            };

            var actionResult = _pricingController.CalculatePrice(pricingRequest);
            var pricingResponse = actionResult.Value as PricingResponse;

            if (pricingResponse == null)
                throw new Exception("Pricing engine failed to return a valid response.");

            // Calculate the total price based on nights
            var totalPrice = pricingResponse.AdjustedPrice * request.Nights;

            // Allocate a room ID (mock implementation)
            var allocatedRoomId = GetNextRoomId();

            // Return the room allocation response
            return new RoomAllocationResponse
            {
                RoomType = request.RoomType,
                AllocatedRoomId = allocatedRoomId,
                TotalPrice = totalPrice,
                SpecialRequests = request.SpecialRequests
            };
        }

        private int GetNextRoomId()
        {
            return ++_nextRoomId;
        }

        private int GetOccupancyRate(string season)
        {
            // Implement logic to return occupancy rate based on season.
            // For simplicity, return a fixed value (this would ideally be dynamic).
            return season switch
            {
                "Off-Season" => 50,
                "Peak Season" => 85,
                "High Occupancy" => 90,
                _ => 70
            };
        }
    }
}