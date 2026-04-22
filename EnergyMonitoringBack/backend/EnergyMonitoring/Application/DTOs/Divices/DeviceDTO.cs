namespace EnergyMonitoring.Application.DTOs.Divices
{
    public class DeviceDTO
    {
        public Guid Id { get; set; }
        public int DeviceTypeId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public double? RatedPowerWatts { get; set; }
        public bool IsActive { get; set; }
    }
}