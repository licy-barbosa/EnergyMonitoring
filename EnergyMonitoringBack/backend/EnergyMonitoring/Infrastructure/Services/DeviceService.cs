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
        private readonly ICurrentUserService _currentUser;

        public DeviceService(ApplicationDbContext context, ICurrentUserService currentUser)
        {
            _context = context;
            _currentUser = currentUser;
        }

        public async Task<IEnumerable<DeviceDTO>> GetByPlantAsync(Guid id)
        {
            return await _context.Devices
                .Where(d=> d.SolarPlantId == id)
                .Select(x => new DeviceDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    RatedPowerWatts = x.RatedPowerWatts,
                    //ExpectedMonthlyConsumptionKWh = x.ExpectedMonthlyConsumptionKWh,
                    IsActive = x.IsActive
                })
                .ToListAsync();
        }

        public async Task<DeviceDTO?> GetByIdAsync(Guid id)
        {
            return await _context.Devices
                .Where(x => x.Id == id)
                .Select(x => new DeviceDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    RatedPowerWatts = x.RatedPowerWatts,
                    IsActive = x.IsActive
                })
                .FirstOrDefaultAsync();
        }

        public async Task<bool> CreateAsync(CreateDeviceDTO dto)
        {
            var companyId = _currentUser.CompanyId;

            if(companyId is null)
                return false;

            var device = new Device(companyId.Value, dto.SolarPlantId, dto.Name, dto.Description, dto.RatedPowerWatts, dto.IsActive);

            await _context.Devices.AddAsync(device);

            var result = await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateAsync(Guid id, UpdateDeviceDTO dto)
        {
            var entity = await _context.Devices
                .FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null) return false;

            entity.Update(dto.Name, dto.Description, dto.RatedPowerWatts, dto.IsActive);

            var result = await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _context.Devices.FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null) return false;

            _context.Devices.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
