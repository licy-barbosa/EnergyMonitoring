using EnergyMonitoring.Application.DTOs.SolarPanels;

namespace EnergyMonitoring.Application.DTOs.SolarPlants
{
    public class CreateSolarPlantDTO
    {
        public string Name { get; set; } = default!;
        public string? Location { get; set; }
        public bool IsActive { get; set; }
        public int PanelCount { get; set; }
        public decimal TotalPowerKW { get; set; }
        public DateTime InstallationDate { get; set; }
        public List<UpdateSolarPanelDTO> Panels { get; set; } = new();
    }
}