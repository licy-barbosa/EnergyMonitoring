namespace EnergyMonitoring.Application.DTOs.Divices
{
    public class DeviceDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Location { get; set; }
        public decimal? RatedPowerWatts { get; set; }
        public decimal ExpectedMonthlyConsumptionKWh { get; set; }
        public bool IsActive { get; set; }
    }
}