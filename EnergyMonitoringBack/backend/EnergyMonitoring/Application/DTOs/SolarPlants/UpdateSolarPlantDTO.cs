
namespace EnergyMonitoring.Application.DTOs.SolarPlants
{
    public class UpdateSolarPlantDTO
    {
        public string Name { get; set; } = string.Empty;
        public string? Location { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public DateTime InstallationDate { get; set; }
        public List<UpdateSolarPanelDTO> Panels { get; set; } = new();
    }

    public class UpdateSolarPanelDTO
    {
        public Guid? Id { get; set; }
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public int PowerWatts { get; set; }
    }
}