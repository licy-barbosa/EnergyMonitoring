namespace EnergyMonitoring.Application.DTOs.Analytics
{
    public class EnergyAnalyticsDTO
    {
        public List<EnergySeriesPointDTO> Series { get; set; } = new();
    }
}
