namespace EnergyMonitoring.Domain.Entities
{
    /// <summary>
    /// Represents a measurement captured from the energy meter.
    /// Representa una medición del medidor eléctrico.
    /// </summary>
    public class DeviceMeasurement
    {
        /// <summary>
        /// Unique identifier.
        /// Identificador único.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Related device.
        /// Dispositivo asociado.
        /// </summary>
        public Guid DeviceId { get; set; }

        /// <summary>
        /// Instant power consumption (W).
        /// Potencia instantánea.
        /// </summary>
        public decimal PowerWatts { get; set; }

        /// <summary>
        /// Voltage (V).
        /// Voltaje.
        /// </summary>
        public decimal Voltage { get; set; }

        /// <summary>
        /// Current (A).
        /// Corriente.
        /// </summary>
        public decimal Current { get; set; }

        /// <summary>
        /// Accumulated energy consumption (kWh).
        /// Energía acumulada.
        /// </summary>
        public decimal EnergyKWh { get; set; }

        /// <summary>
        /// Measurement timestamp.
        /// Fecha de medición.
        /// </summary>
        public DateTime Timestamp { get; set; }
        public string CreatedByUserId { get; set; } = default!;
        public Device Device { get; set; } = default!;
    }
}