using Microsoft.AspNetCore.Mvc;
using HotelPricingEngine.Models;
using HotelPricingEngine.Services;

namespace HotelPricingEngine.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AllocationController : ControllerBase
    {
        private readonly RoomAllocationService _allocationService;

        public AllocationController(RoomAllocationService allocationService)
        {
            _allocationService = allocationService;
        }

        [HttpPost("allocate")]
        public IActionResult AllocateRooms([FromBody] List<RoomAllocationRequest> requests)
        {
            var responses = new List<RoomAllocationResponse>();

            foreach (var request in requests)
            {
                var response = _allocationService.AllocateRoom(request);
                responses.Add(response);
            }

            return Ok(responses);
        }
    }
}
