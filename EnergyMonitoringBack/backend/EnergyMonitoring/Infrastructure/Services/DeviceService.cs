using EnergyMonitoring.Application.DTOs.Divices;
using EnergyMonitoring.Application.Interfaces;
using EnergyMonitoring.Domain.Entities;
using Merkcon.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EnergyMonitoring.Infrastructure.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly ApplicationDbContext _context;

        public DeviceService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DeviceDTO>> GetByUserAsync(string userId)
        {
            return await _context.Devices
                .Where(x => x.CreatedByUserId == userId)
                .Select(x => new DeviceDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Location = x.Location,
                    RatedPowerWatts = x.RatedPowerWatts,
                    //ExpectedMonthlyConsumptionKWh = x.ExpectedMonthlyConsumptionKWh,
                    IsActive = x.IsActive
                })
                .ToListAsync();
        }

        public async Task<DeviceDTO?> GetByIdAsync(Guid id, string userId)
        {
            return await _context.Devices
                .Where(x => x.Id == id && x.CreatedByUserId == userId)
                .Select(x => new DeviceDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Location = x.Location,
                    RatedPowerWatts = x.RatedPowerWatts,
                    //ExpectedMonthlyConsumptionKWh = x.ExpectedMonthlyConsumptionKWh,
                    IsActive = x.IsActive
                })
                .FirstOrDefaultAsync();
        }

        public async Task<DeviceDTO> CreateAsync(CreateDeviceDTO dto, string userId)
        {
            var entity = new Device
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Description = dto.Description,
                Location = dto.Location,
                RatedPowerWatts = dto.RatedPowerWatts,
                //ExpectedMonthlyConsumptionKWh = dto.ExpectedMonthlyConsumptionKWh,
                CreatedByUserId = userId
            };

            _context.Devices.Add(entity);
            await _context.SaveChangesAsync();

            return new DeviceDTO
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Location = entity.Location,
                RatedPowerWatts = entity.RatedPowerWatts,
                //ExpectedMonthlyConsumptionKWh = entity.ExpectedMonthlyConsumptionKWh,
                IsActive = entity.IsActive
            };
        }

        public async Task<bool> UpdateAsync(Guid id, CreateDeviceDTO dto, string userId)
        {
            var entity = await _context.Devices
                .FirstOrDefaultAsync(x => x.Id == id && x.CreatedByUserId == userId);

            if (entity == null) return false;

            entity.Name = dto.Name;
            entity.Description = dto.Description;
            entity.Location = dto.Location;
            entity.RatedPowerWatts = dto.RatedPowerWatts;
            //entity.ExpectedMonthlyConsumptionKWh = dto.ExpectedMonthlyConsumptionKWh;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id, string userId)
        {
            var entity = await _context.Devices
                .FirstOrDefaultAsync(x => x.Id == id && x.CreatedByUserId == userId);

            if (entity == null) return false;

            _context.Devices.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
