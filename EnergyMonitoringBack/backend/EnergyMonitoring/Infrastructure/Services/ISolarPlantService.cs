using EnergyMonitoring.Application.DTOs.SolarPanels;
using EnergyMonitoring.Application.DTOs.SolarPlants;
using EnergyMonitoring.Application.Interfaces;
using EnergyMonitoring.Domain.Entities;
using Merkcon.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EnergyMonitoring.Infrastructure.Services
{
    public class SolarPlantService : ISolarPlantService
    {
        private readonly ApplicationDbContext _context;
        private readonly ICurrentUserService _currentUser;

        public SolarPlantService(ApplicationDbContext context, ICurrentUserService currentUser)
        {
            _context = context;
            _currentUser = currentUser;
        }

        public async Task<List<SolarPlantDetailDTO>> GetByUserAsync()
        {
            var plants = await _context.SolarPlants
                .Include(p => p.Panels)
                .ToListAsync();

            return plants.Select(Map).ToList();
        }

        public async Task<SolarPlantDetailDTO> GetDetailAsync(Guid id)
        {
            var plant = await _context.SolarPlants
                .Include(p => p.Panels)
                .FirstAsync(p => p.Id == id );

            return Map(plant);
        }

        public async Task<bool> CreateAsync(CreateSolarPlantDTO dto)
        {
            var companyId = _currentUser.CompanyId;

            if (companyId is null)
                return false;

            var plant = new SolarPlant(companyId.Value, dto.Name, dto.Location, dto.IsActive, dto.InstallationDate);

            if(dto.Panels.Count > 0)
                plant.SyncPanels(dto.Panels);

            await _context.SolarPlants.AddAsync(plant); 

            var result =  await _context.SaveChangesAsync();
            Console.WriteLine($"Created Solar Plant with ID: {plant.Id}, SaveChanges result: {result}");
            return true;
        }

        public async Task<bool> UpdateAsync(Guid id, UpdateSolarPlantDTO dto) {

            var plant = await _context.SolarPlants
               .Include(p => p.Panels)
               .FirstOrDefaultAsync(p => p.Id == id );

            if (plant == null)
                return false;

            plant.Update(dto.Name, dto.Location, dto.IsActive, dto.InstallationDate);

            if (dto.Panels.Count > 0)
                plant.SyncPanels(dto.Panels);

             await _context.SaveChangesAsync();
            return true;
        }

        private static SolarPlantDetailDTO Map(SolarPlant plant)
        {
            return new SolarPlantDetailDTO
            {
                Id = plant.Id,
                Name = plant.Name,
                Location = plant.Location,
                IsActive = plant.IsActive,
                InstallationDate = plant.InstallationDate,
                TotalPowerKw = plant.TotalPowerKw,
                Panels = plant.Panels.Select(p => new SolarPanelDetailDTO
                {
                    Id = p.Id,
                    Brand = p.Brand?? string.Empty,
                    Model = p.Model?? string.Empty,
                    PowerWatts = p.PowerWatts,
                    Quantity = p.Quantity,
                   
                }).ToList()
            };
        }
    }
}