using EnergyMonitoring.Application.DTOs.SolarPanels;

namespace EnergyMonitoring.Application.DTOs.SolarPlants
{
    public class SolarPlantDetailDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Location { get; set; }
        public DateTime InstallationDate { get; set; }
        public decimal TotalPowerKw { get; set; }
        public bool IsActive { get; set; }
        public List<SolarPanelDetailDTO> Panels { get; set; } = new();
    }
}