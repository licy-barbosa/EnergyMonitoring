using EnergyMonitoring.Application.DTOs.SolarPlants;
using EnergyMonitoring.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EnergyMonitoring.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class SolarPlantsController : ControllerBase
    {
        private readonly ISolarPlantService _service;

        public SolarPlantsController(ISolarPlantService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get() {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var plants = await _service.GetByUserAsync();

                return Ok(plants);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetail(Guid id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var plant = await _service.GetDetailAsync(id);

            return Ok(plant);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSolarPlantDTO dto)
        {
            var id = await _service.CreateAsync(dto);

            return Ok(id);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateSolarPlantDTO dto)
        {
            var updated =  await _service.UpdateAsync(id, dto);

            if (!updated)
                return NotFound();
            return Ok();
        }
    }
}