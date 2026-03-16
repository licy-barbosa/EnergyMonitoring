namespace EnergyMonitoring.Domain.Entities
{
    /// <summary>
    /// Represents an electrical device being monitored.
    /// Representa un equipo eléctrico monitoreado.
    /// </summary>
    public class Device
    {
        /// <summary>
        /// Unique identifier.
        /// Identificador único.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Device name.
        /// Nombre del dispositivo.
        /// </summary>
        public string Name { get; set; } = default!;

        /// <summary>
        /// Device description.
        /// Descripción del equipo.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Physical location.
        /// Ubicación física.
        /// </summary>
        public string? Location { get; set; }

        /// <summary>
        /// Rated power according to specifications.
        /// Potencia nominal según fabricante.
        /// </summary>
        public decimal? RatedPowerWatts { get; set; }
        public bool IsActive { get; set; } = true;
        public string CreatedByUserId { get; set; } = default!;
        public ApplicationUser CreatedByUser { get; set; } = default!;

        public ICollection<DeviceMeasurement> Measurements { get; set; } = new List<DeviceMeasurement>();
    }
}