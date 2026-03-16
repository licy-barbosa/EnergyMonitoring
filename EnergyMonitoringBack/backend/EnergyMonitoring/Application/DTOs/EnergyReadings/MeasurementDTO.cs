namespace EnergyMonitoring.Application.DTOs.EnergyReadings
{
    public class MeasurementDTO
    {
        public Guid Id { get; set; }
        public Guid DeviceId { get; set; }
        public decimal? PowerWatts { get; set; }
        public decimal? EnergyKWh { get; set; }
        public decimal? Voltage { get; set; }
        public decimal? Current { get; set; }
        public DateTime Timestamp { get; set; }
    }
}