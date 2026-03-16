namespace EnergyMonitoring.Application.DTOs.Costs
{
    public class CostSummaryDTO
    {
        public decimal TotalGeneratedKWh { get; set; }
        public decimal TotalConsumedKWh { get; set; }
        public decimal TotalImportedKWh { get; set; }
        public decimal TotalExportedKWh { get; set; }

        public decimal EstimatedCostWithoutSolar { get; set; }
        public decimal EstimatedCostWithSolar { get; set; }
        public decimal EstimatedSavings { get; set; }
    }
}
