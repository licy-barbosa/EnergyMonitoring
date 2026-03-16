namespace EnergyMonitoring.Application.DTOs.SolarPanels
{
    public class PanelDTO
    {
        public Guid Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int PowerWatts { get; set; }
        public DateTime InstallationDate { get; set; }
        public Guid OwnerId { get; set; }
        public int Quantity { get; set; }
    }
}