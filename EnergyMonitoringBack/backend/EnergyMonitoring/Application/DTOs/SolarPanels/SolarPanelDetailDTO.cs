namespace EnergyMonitoring.Application.DTOs.SolarPanels
{
    public class SolarPanelDetailDTO
    {
        public Guid Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public decimal PowerWatts { get; set; }
        public int Quantity { get; set; }
        public DateTime? InstallationDate { get; set; }
    }
}