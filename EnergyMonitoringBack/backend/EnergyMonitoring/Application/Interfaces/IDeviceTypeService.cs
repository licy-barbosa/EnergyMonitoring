using EnergyMonitoring.Application.DTOs.DeviceTypes;

namespace EnergyMonitoring.Application.Interfaces
{
    public interface IDeviceTypeService
    {
        Task<List<DeviceTypeSelectDTO>> GetAllAsync();
        Task<DeviceTypeDTO> GetByIdAsync(int id);
        Task<bool> CreateAsync(CreateDeviceTypeDTO dto);
        Task<bool> UpdateAsync(int id, UpdateDeviceTypeDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}