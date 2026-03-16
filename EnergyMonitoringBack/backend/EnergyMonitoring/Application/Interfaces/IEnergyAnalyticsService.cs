using EnergyMonitoring.Application.DTOs.Analytics;

namespace EnergyMonitoring.Application.Interfaces
{
    public interface IEnergyAnalyticsService
    {
        Task<EnergyAnalyticsDTO> GetEnergyHistoryAsync(string userId, DateTime from,DateTime to);
    }
}