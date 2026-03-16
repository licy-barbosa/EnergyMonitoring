using EnergyMonitoring.Application.DTOs.EnergyReadings;
using EnergyMonitoring.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EnergyMonitoring.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class EnergyReadingsController : ControllerBase
    {
        private readonly IDeviceMeasurementService _service;

        public EnergyReadingsController(IDeviceMeasurementService service)
        {
            _service = service;
        }

        private string GetUserId() => User.FindFirst("uid")!.Value;

        [HttpGet("{deviceId}")]
        public async Task<IActionResult> GetByDevice(Guid deviceId)
        {
            var data = await _service.GetByDeviceAsync(deviceId, GetUserId());
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMeasurementDTO dto)
        {
            var result = await _service.CreateAsync(dto, GetUserId());
            return Ok(result);
        }
    }
}