namespace EnergyMonitoring.Application.DTOs.Divices
{
    public class CreateDeviceDTO
    {
        public int DeviceTypeId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public double? RatedPowerWatts { get; set; }
        public bool IsActive { get; set; }
        public decimal ExpectedMonthlyConsumptionKWh { get; set; }
        public Guid SolarPlantId { get; set; }
    }
}