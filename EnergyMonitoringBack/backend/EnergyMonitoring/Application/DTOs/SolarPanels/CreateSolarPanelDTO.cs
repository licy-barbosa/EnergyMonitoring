namespace EnergyMonitoring.Application.DTOs.SolarPanels
{
    public class CreateSolarPanelDTO
    {
        public decimal RatedPowerWatts { get; set; }
        public string? Manufacturer { get; set; }
        public string? Model { get; set; }
        public DateTime? InstallationDate { get; set; }
    }
}
