namespace EnergyMonitoring.Application.DTOs.Divices
{
    public class UpdateDeviceDTO
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public double RatedPowerWatts { get; set; }
        public bool IsActive { get; set; }
        public decimal ExpectedMonthlyConsumptionKWh { get; set; }
    }
}
