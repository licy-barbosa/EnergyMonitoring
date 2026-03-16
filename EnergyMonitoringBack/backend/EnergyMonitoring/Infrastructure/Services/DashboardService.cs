using EnergyMonitoring.Application.DTOs.Dashboard;
using EnergyMonitoring.Application.Interfaces;
using Merkcon.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EnergyMonitoring.Infrastructure.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly ApplicationDbContext _context;

        public DashboardService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DashboardSummaryDTO> GetDashboardSummaryAsync(string userId)
        {
            var today = DateTime.UtcNow.Date;

            var generatedToday = await _context.EnergyReadings
                .Where(x => x.RecordedByUserId == userId && x.Timestamp >= today)
                .SumAsync(x => (decimal?)x.GeneratedKWh) ?? 0m;

            var consumedToday = await _context.DeviceMeasurements
                .Where(x => x.CreatedByUserId == userId && x.Timestamp >= today)
                .SumAsync(x => (decimal?)x.EnergyKWh) ?? 0m;

            var generatedTotal = await _context.EnergyReadings
                .Where(x => x.RecordedByUserId == userId)
                .SumAsync(x => (decimal?)x.GeneratedKWh) ?? 0m;

            var consumedTotal = await _context.DeviceMeasurements
                .Where(x => x.CreatedByUserId == userId)
                .SumAsync(x => (decimal?)x.EnergyKWh) ?? 0m;

            var topDevices = await _context.Devices
                .Where(d => d.CreatedByUserId == userId) // 🔴 importante filtrar por usuario
                .Select(d => new DeviceConsumptionDTO
                {
                    DeviceId = d.Id,
                    DeviceName = d.Name,
                    ConsumptionKWh = d.Measurements
                        .Sum(m => (decimal?)m.EnergyKWh) ?? 0m
                })
                .OrderByDescending(x => x.ConsumptionKWh)
                .Take(5)
                .ToListAsync();

            return new DashboardSummaryDTO
            {
                EnergyGeneratedTodayKWh = generatedToday,
                EnergyConsumedTodayKWh = consumedToday,
                EnergyExportedTodayKWh = generatedToday - consumedToday,
                EnergyGeneratedTotalKWh = generatedTotal,
                EnergyConsumedTotalKWh = consumedTotal,
                TotalDevices = await _context.Devices
                    .CountAsync(d => d.CreatedByUserId == userId),
                TopDevices = topDevices
            };
        }
    }
}
