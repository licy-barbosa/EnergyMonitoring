using EnergyMonitoring.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EnergyMonitoring.API.Controllers
{
    [ApiController]
    [Route("api/costs")]
    [Authorize]
    public class CostsController : ControllerBase
    {
        private readonly ICostCalculationService _service;

        public CostsController(ICostCalculationService service)
        {
            _service = service;
        }

        [HttpGet("summary")]
        public async Task<IActionResult> GetSummary(
            [FromQuery] DateTime from,
            [FromQuery] DateTime to)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;

            var result = await _service.CalculateAsync(userId, from, to);

            return Ok(result);
        }
    }
}