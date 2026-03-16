namespace EnergyMonitoring.Application.DTOs.Dashboard
{
    public class DeviceConsumptionDTO
    {
        public Guid DeviceId { get; set; }
        public string DeviceName { get; set; } = default!;
        public decimal ConsumptionKWh { get; set; }
    }
}