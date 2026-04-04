using EnergyMonitoring.Application.DTOs.Divices;

namespace EnergyMonitoring.Application.Interfaces
{
    public interface IDeviceService
    {
        Task<IEnumerable<DeviceDTO>> GetByPlantAsync(Guid id);
        Task<DeviceDTO?> GetByIdAsync(Guid id);
        Task<bool> CreateAsync(CreateDeviceDTO dto);
        Task<bool> UpdateAsync(Guid id, UpdateDeviceDTO dto);
        Task<bool> DeleteAsync(Guid id);
    }
}