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
        public Guid Id { get; set; }

        public Guid CompanyId { get; private set; }

        public Guid SolarPlantId { get; set; }
        public SolarPlant SolarPlant { get; private set; } = default!;

        /// <summary>
        /// Device name.
        /// Nombre del dispositivo.
        /// </summary>
        public string Name { get; private set; } = default!;

        /// <summary>
        /// Device description.
        /// Descripción del equipo.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Rated power according to specifications.
        /// Potencia nominal según fabricante.
        /// </summary>
        public double? RatedPowerWatts { get; set; }
        public bool IsActive { get; set; } = true;

        public ICollection<DeviceMeasurement> Measurements { get; set; } = new List<DeviceMeasurement>();

        private Device() { }
        public Device(Guid companyId, Guid solarPlantId, string name)
        {
            CompanyId = companyId;
            SolarPlantId = solarPlantId;
            Name = name;
        }
    }
}