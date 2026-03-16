using EnergyMonitoring.Application.DTOs.SolarPlants;
using Microsoft.AspNetCore.Mvc;

namespace EnergyMonitoring.Application.Interfaces
{
    public interface ISolarPlantService
    {
        Task<bool> CreateAsync(CreateSolarPlantDTO dto);
        Task<SolarPlantDetailDTO> GetDetailAsync(Guid id);
        Task<List<SolarPlantDetailDTO>> GetByUserAsync();
        Task<bool> UpdateAsync(Guid id, UpdateSolarPlantDTO dto);
    }
}