using EnergyMonitoring.Application.DTOs.Dashboard;

namespace EnergyMonitoring.Application.Interfaces
{
    public interface IDashboardService
    {
        Task<DashboardSummaryDTO> GetDashboardSummaryAsync(string userId);
    }
}
