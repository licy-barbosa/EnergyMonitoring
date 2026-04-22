using EnergyMonitoring.Application.DTOs.DeviceTypes;
using EnergyMonitoring.Application.Interfaces;
using EnergyMonitoring.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Merkcon.Infrastructure.Data;

namespace EnergyMonitoring.Infrastructure.Services
{
    public class DeviceTypeService : IDeviceTypeService
    {
        private readonly ApplicationDbContext _context;
        private readonly ICurrentUserService _currentUser;

        public DeviceTypeService(ApplicationDbContext context, ICurrentUserService currentUser)
        {
            _context = context;
            _currentUser = currentUser;
        }

        public async Task<List<DeviceTypeSelectDTO>> GetAllAsync()
        {
            return await _context.DeviceTypes
                .Select(x => new DeviceTypeSelectDTO
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .ToListAsync();
        }


        public async Task<DeviceTypeDTO?> GetByIdAsync(int id)
        {
            return await _context.DeviceTypes
                .Where(x => x.Id == id)
                .Select(x => new DeviceTypeDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    MinVoltage = x.MinVoltage,
                    MaxVoltage = x.MaxVoltage,
                    MinCurrent = x.MinCurrent,
                    MaxCurrent = x.MaxCurrent,
                    MinPowerWatts = x.MinPowerWatts,
                    MaxPowerWatts = x.MaxPowerWatts
                })
                .FirstOrDefaultAsync();
        }

        public async Task<bool> CreateAsync(CreateDeviceTypeDTO dto)
        {
            var companyId = _currentUser.CompanyId;

            if (companyId is null)
                return false;

            var deviceType = new DeviceType(companyId.Value, dto.Name, dto.MinVoltage, dto.MaxVoltage, dto.MinCurrent, dto.MaxCurrent, dto.MinPowerWatts, dto.MaxPowerWatts);

            await _context.DeviceTypes.AddAsync(deviceType);

            var result = await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateAsync(int id, UpdateDeviceTypeDTO dto)
        {
            var entity = await _context.DeviceTypes
                .FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null) return false;

            entity.Update(dto.Name, dto.MinVoltage, dto.MaxVoltage, dto.MinCurrent, dto.MaxCurrent, dto.MinPowerWatts, dto.MaxPowerWatts);

            var result = await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.DeviceTypes
                .FirstOrDefaultAsync(x => x.Id == id);
    
            if (entity == null) return false;
    
            _context.DeviceTypes.Remove(entity);
            var result = await _context.SaveChangesAsync();
            return true;
        }
    }
}