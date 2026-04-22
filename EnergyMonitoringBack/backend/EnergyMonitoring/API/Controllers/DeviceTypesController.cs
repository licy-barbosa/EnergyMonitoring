using EnergyMonitoring.Application.DTOs.DeviceTypes;
using EnergyMonitoring.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EnergyMonitoring.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class DeviceTypesController : ControllerBase
    {
        private readonly IDeviceTypeService _service;

        public DeviceTypesController(IDeviceTypeService deviceTypeService)
        {
            _service = deviceTypeService;
        }

        [HttpGet]
        public async Task<ActionResult<List<DeviceTypeSelectDTO>>> GetAll()
        {
            var deviceTypes = await _service.GetAllAsync();
            return Ok(deviceTypes);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            var device = await _service.GetByIdAsync(id);
            if (device == null) return NotFound();
            return Ok(device);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateDeviceTypeDTO dto)
        {
            var device = await _service.CreateAsync(dto);

            if (!device)
                return NotFound();

            return Ok(device);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateDeviceTypeDTO dto)
        {
            var updated = await _service.UpdateAsync(id, dto);

            if (!updated) return NotFound();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);

            if (!deleted) return NotFound();

            return Ok();
        }
    }
}