namespace EnergyMonitoring.Domain.Entities
{
    /// <summary>
    /// Represents a solar inverter.
    /// Representa el inversor solar.
    /// </summary>
    public class Inverter
    {
        private Inverter() { } // EF

        public Inverter(
            Guid solarPlantId,
            string? brand,
            string? model,
            string? platform,
            DateTime installationDate)
        {
            Id = Guid.NewGuid();
            SolarPlantId = solarPlantId;
            Brand = brand;
            Model = model;
            Platform = platform;
            InstallationDate = installationDate;
        }

        /// <summary>
        /// Unique identifier.
        /// Identificador único.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Related solar plant.
        /// Planta solar asociada.
        /// </summary>
        public Guid SolarPlantId { get; private set; }

        public SolarPlant SolarPlant { get; private set; } = default!;

        /// <summary>
        /// Inverter brand.
        /// Marca del inversor.
        /// </summary>
        public string? Brand { get; private set; }

        /// <summary>
        /// Model of the inverter.
        /// Modelo del inversor.
        /// </summary>
        public string? Model { get; private set; }

        /// <summary>
        /// Monitoring platform (e.g., Aurora Vision).
        /// Plataforma de monitoreo.
        /// </summary>
        public string? Platform { get; private set; }

        /// <summary>
        /// Installation date.
        /// Fecha de instalación.
        /// </summary>
        public DateTime InstallationDate { get; private set; }

        // 🔥 Comportamiento de dominio (opcional pero recomendado)
        public void UpdateDetails(
            string? brand,
            string? model,
            string? platform,
            DateTime installationDate)
        {
            Brand = brand;
            Model = model;
            Platform = platform;
            InstallationDate = installationDate;
        }
    }
}