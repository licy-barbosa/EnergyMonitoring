namespace EnergyMonitoring.Application.DTOs.Dashboard
{
    public class DashboardSummaryDTO
    {
        public decimal EnergyGeneratedTodayKWh { get; set; }
        public decimal EnergyConsumedTodayKWh { get; set; }
        public decimal EnergyExportedTodayKWh { get; set; }

        public decimal EnergyGeneratedTotalKWh { get; set; }
        public decimal EnergyConsumedTotalKWh { get; set; }

        public int TotalDevices { get; set; }

        public List<DeviceConsumptionDTO> TopDevices { get; set; } = new();
    }
}
