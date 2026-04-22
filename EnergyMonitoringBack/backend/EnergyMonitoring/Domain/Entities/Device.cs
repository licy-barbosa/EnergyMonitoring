using EnergyMonitoring.Domain.Common;

namespace EnergyMonitoring.Domain.Entities
{
    /// <summary>
    /// Represents an electrical device being monitored.
    /// Representa un equipo eléctrico monitoreado.
    /// </summary>
    public class Device : AuditableEntity, ICompanyEntity
    {
        /// <summary>
        /// Unique identifier.
        /// Identificador único.
        /// </summary>
        public Guid Id { get; private set; }

        public Guid CompanyId { get; private set; }

        public Guid SolarPlantId { get; private set; }
        public SolarPlant SolarPlant { get; private set; } = default!;

        public int DeviceTypeId { get; private set; }
        public DeviceType DeviceType { get; set; }

        /// <summary>
        /// Device name.
        /// Nombre del dispositivo.
        /// </summary>
        public string Name { get; private set; } = default!;

        /// <summary>
        /// Device description.
        /// Descripción del equipo.
        /// </summary>
        public string? Description { get; private set; }

        /// <summary>
        /// Rated power according to specifications.
        /// Potencia nominal según fabricante.
        /// </summary>
        public double? RatedPowerWatts { get; private set; } = null;
        public bool IsActive { get; private set; } = true;

        public ICollection<DeviceMeasurement> Measurements { get; set; } = new List<DeviceMeasurement>();

        private Device() { }
        public Device(
            Guid companyId, 
            Guid solarPlantId, 
            string name, 
            string? description, 
            double? ratedPowerWatts, 
            bool isActive, int deviceTypeId)
        {
            Id = Guid.NewGuid();
            CompanyId = companyId;
            SolarPlantId = solarPlantId;
            Name = name;
            Description = description;
            RatedPowerWatts = ratedPowerWatts;
            IsActive = isActive;
            DeviceTypeId = deviceTypeId;
        }

        public void Update(string name, string? description, double? ratedPowerWatts, bool isActive, int deviceTypeId) {
            DeviceTypeId = deviceTypeId;
            Name = name;
            Description = description;
            RatedPowerWatts = ratedPowerWatts;
            IsActive = isActive;
        }
    }
}