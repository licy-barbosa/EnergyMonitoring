using EnergyMonitoring.Application.DTOs.Costs;
using EnergyMonitoring.Application.Interfaces;
using Merkcon.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EnergyMonitoring.Infrastructure.Services
{
    public class CostCalculationService : ICostCalculationService
    {

        private readonly ApplicationDbContext _context;

        // 🔹 Tarifa promedio CFE (puedes moverla a configuración)
        private const decimal CfeRatePerKWh = 1.2m;

        public CostCalculationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CostSummaryDTO> CalculateAsync(
            string userId,
            DateTime from,
            DateTime to)
        {
            var readings = await _context.EnergyReadings
                .Where(x =>
                  
                    x.Timestamp >= from &&
                    x.Timestamp <= to)
                .ToListAsync();

            var totalGenerated = readings.Sum(x => x.GeneratedKWh);
            var totalConsumed = readings.Sum(x => x.ConsumedKWh);
            var totalImported = readings.Sum(x => x.ImportKWh);
            var totalExported = readings.Sum(x => x.ExportKWh);

            var costWithoutSolar = totalConsumed * CfeRatePerKWh;
            var costWithSolar = totalImported * CfeRatePerKWh;
            var savings = costWithoutSolar - costWithSolar;

            return new CostSummaryDTO
            {
                TotalGeneratedKWh = totalGenerated,
                TotalConsumedKWh = totalConsumed,
                TotalImportedKWh = totalImported,
                TotalExportedKWh = totalExported,
                EstimatedCostWithoutSolar = costWithoutSolar,
                EstimatedCostWithSolar = costWithSolar,
                EstimatedSavings = savings
            };
        }
    }
}
