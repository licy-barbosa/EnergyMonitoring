using EnergyMonitoring.Application.DTOs.EnergyReadings;
using EnergyMonitoring.Application.Interfaces;
using EnergyMonitoring.Domain.Entities;
using Merkcon.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EnergyMonitoring.Infrastructure.Services
{
    public class DeviceMeasurementService : IDeviceMeasurementService
    {
        private readonly ApplicationDbContext _context;

        public DeviceMeasurementService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MeasurementDTO>> GetByDeviceAsync(Guid deviceId, string userId)
        {
            return await _context.DeviceMeasurements
                .Where(x => x.DeviceId == deviceId && x.CreatedByUserId == userId)
                .OrderByDescending(x => x.Timestamp)
                .Select(x => new MeasurementDTO
                {
                    Id = x.Id,
                    DeviceId = x.DeviceId,
                    PowerWatts = x.PowerWatts,
                    EnergyKWh = x.EnergyKWh,
                    Voltage = x.Voltage,
                    Current = x.Current,
                    Timestamp = x.Timestamp
                })
                .ToListAsync();
        }

        public async Task<MeasurementDTO> CreateAsync(CreateMeasurementDTO dto, string userId)
        {
            var entity = new DeviceMeasurement
            {
                Id = Guid.NewGuid(),
                DeviceId = dto.DeviceId,
                PowerWatts = dto.PowerWatts ?? 0m,
                EnergyKWh = dto.EnergyKWh ?? 0m,
                Voltage = dto.Voltage ?? 0m,
                Current = dto.Current ?? 0m,
                Timestamp = dto.Timestamp,
                CreatedByUserId = userId
            };

            _context.DeviceMeasurements.Add(entity);
            await _context.SaveChangesAsync();

            return new MeasurementDTO
            {
                Id = entity.Id,
                DeviceId = entity.DeviceId,
                PowerWatts = entity.PowerWatts,
                EnergyKWh = entity.EnergyKWh,
                Voltage = entity.Voltage,
                Current = entity.Current,
                Timestamp = entity.Timestamp
            };
        }
    }
}
