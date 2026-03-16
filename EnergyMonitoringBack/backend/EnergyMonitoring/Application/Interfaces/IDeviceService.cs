using EnergyMonitoring.Application.DTOs.Divices;

namespace EnergyMonitoring.Application.Interfaces
{
    public interface IDeviceService
    {
        Task<IEnumerable<DeviceDTO>> GetByUserAsync(string userId);
        Task<DeviceDTO?> GetByIdAsync(Guid id, string userId);
        Task<DeviceDTO> CreateAsync(CreateDeviceDTO dto, string userId);
        Task<bool> UpdateAsync(Guid id, CreateDeviceDTO dto, string userId);
        Task<bool> DeleteAsync(Guid id, string userId);
    }
}
