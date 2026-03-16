using EnergyMonitoring.Application.DTOs.Costs;

namespace EnergyMonitoring.Application.Interfaces
{
    public interface ICostCalculationService
    {
        Task<CostSummaryDTO> CalculateAsync(string userId, DateTime from, DateTime to);
    }
}