using EnergyMonitoring.Application.DTOs.Analytics;
using EnergyMonitoring.Application.Interfaces;
using Merkcon.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EnergyMonitoring.Infrastructure.Services
{
    public class EnergyAnalyticsService : IEnergyAnalyticsService
    {
        private readonly ApplicationDbContext _context;

        public EnergyAnalyticsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<EnergyAnalyticsDTO> GetEnergyHistoryAsync(
            string userId,
            DateTime from,
            DateTime to)
        {
            var generation = await _context.EnergyReadings
                 .Where(x =>
                
                     x.Timestamp >= from &&
                     x.Timestamp <= to)
                 .GroupBy(x => x.Timestamp.Date)
                 .Select(g => new
                 {
                     Date = g.Key,
                     Generated = g.Sum(x => x.GeneratedKWh),
                     Consumed = g.Sum(x => x.ConsumedKWh)
                 })
                 .ToListAsync();

            var consumption = await _context.DeviceMeasurements
                .Where(x => x.CreatedByUserId == userId && x.Timestamp >= from && x.Timestamp <= to)
                .GroupBy(x => x.Timestamp.Date)
                .Select(g => new
                {
                    Date = g.Key,
                    Consumed = g.Sum(x => x.EnergyKWh)
                })
                .ToListAsync();

            var dates = generation.Select(x => x.Date)
                .Union(consumption.Select(x => x.Date))
                .Distinct()
                .OrderBy(x => x)
                .ToList();

            var series = generation.Select(x => new EnergySeriesPointDTO
            {
                Date = x.Date,
                GeneratedKWh = x.Generated,
                ConsumedKWh = x.Consumed,
                ExportedKWh = x.Generated - x.Consumed
            }).ToList();

            return new EnergyAnalyticsDTO
            {
                Series = series
            };
        }
    }
}