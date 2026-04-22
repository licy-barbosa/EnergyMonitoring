namespace EnergyMonitoring.Application.DTOs.DeviceTypes
{
    public class DeviceTypeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public decimal MinVoltage { get; set; }
        public decimal MaxVoltage { get; set; }

        public decimal MinCurrent { get; set; }
        public decimal MaxCurrent { get; set; }

        public decimal MinPowerWatts { get; set; }
        public decimal MaxPowerWatts { get; set; }
    }
}
