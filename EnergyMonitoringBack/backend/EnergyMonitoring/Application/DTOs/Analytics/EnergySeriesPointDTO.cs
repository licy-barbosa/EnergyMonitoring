namespace EnergyMonitoring.Application.DTOs.Analytics
{
    public class EnergySeriesPointDTO
    {
        public DateTime Date { get; set; }
        public decimal GeneratedKWh { get; set; }
        public decimal ConsumedKWh { get; set; }
        public decimal ExportedKWh { get; set; }
    }
}