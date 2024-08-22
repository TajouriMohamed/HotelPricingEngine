using Microsoft.AspNetCore.Mvc;
using HotelPricingEngine.Models;
using HotelPricingEngine.Services;

namespace HotelPricingEngine.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PricingController(PricingService pricingService) : ControllerBase
    {
        private readonly PricingService _pricingService = pricingService;

        [HttpPost("calculate")]
        public IActionResult CalculatePrice([FromBody] PricingRequest request)
        {
            var response = _pricingService.CalculatePrice(request);
            return Ok(response);
        }
    }
}
