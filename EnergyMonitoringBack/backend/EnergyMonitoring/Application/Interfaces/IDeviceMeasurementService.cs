using EnergyMonitoring.Application.DTOs.EnergyReadings;

namespace EnergyMonitoring.Application.Interfaces
{
    public interface IDeviceMeasurementService
    {
        Task<IEnumerable<MeasurementDTO>> GetByDeviceAsync(Guid deviceId, string userId);
        Task<MeasurementDTO> CreateAsync(CreateMeasurementDTO dto, string userId);
    }
}