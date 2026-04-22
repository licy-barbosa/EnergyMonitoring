using EnergyMonitoring.Domain.Common;

namespace EnergyMonitoring.Domain.Entities
{
    public class DeviceType: ICompanyEntity
    {
        public int Id { get; set; }
        public Guid CompanyId { get; private set; }
        public Company Company { get; private set; } = default!;

        public string Name { get; set; }

        public decimal MinVoltage { get; set; }
        public decimal MaxVoltage { get; set; }

        public decimal MinCurrent { get; set; }
        public decimal MaxCurrent { get; set; }

        public decimal MinPowerWatts { get; set; }
        public decimal MaxPowerWatts { get; set; }

        private DeviceType() { }
        public DeviceType(
            Guid companyId, 
            string name, 
            decimal minVoltage, 
            decimal maxVoltage,
            decimal minCurrent,
            decimal maxCurrent,
            decimal minPowerWatts,
            decimal maxPowerWatts
            ) 
        {
            CompanyId = companyId;
            Name = name;
            MinVoltage = minVoltage;
            MaxVoltage = maxVoltage;
            MinCurrent = minCurrent;
            MaxCurrent = maxCurrent;
            MinPowerWatts = minPowerWatts;
            MaxPowerWatts = maxPowerWatts;
        }

        public void Update(
            string name, 
            decimal minVoltage, 
            decimal maxVoltage, 
            decimal minCurrent, 
            decimal maxCurrent, 
            decimal minPowerWatts, 
            decimal maxPowerWatts)
        {
            Name = name;
            MinVoltage = minVoltage;
            MaxVoltage = maxVoltage;
            MinCurrent = minCurrent;
            MaxCurrent = maxCurrent;
            MinPowerWatts = minPowerWatts;
            MaxPowerWatts = maxPowerWatts;
        }
    }
}