using EnergyMonitoring.Domain.Common;

namespace EnergyMonitoring.Domain.Entities
{
    /// <summary>
    /// Represents an individual solar panel.
    /// Representa un panel solar individual.
    /// </summary>
    public class SolarPanel : AuditableEntity
    {
        /// <summary>
        /// Unique identifier of the panel.
        /// Identificador único del panel.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Related solar plant ID.
        /// Id de la planta solar a la que pertenece.
        /// </summary>
        public Guid SolarPlantId { get; private set; }

        /// <summary>
        /// Manufacturer brand.
        /// Marca del panel.
        /// </summary>
        public string? Brand { get; private set; }

        /// <summary>
        /// Panel model.
        /// Modelo del panel.
        /// </summary>
        public string? Model { get; private set; }

        /// <summary>
        /// Nominal power in watts.
        /// Potencia nominal en watts.
        /// </summary>
        public int PowerWatts { get; private set; }

        public int Quantity { get; private set; } 

        public SolarPlant SolarPlant { get; private set; } = default!;

        private SolarPanel() { } // EF Core

        public SolarPanel(
            Guid solarPlantId,
            string brand,
            string model,
            int quantity,
            int powerWatts){

            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero");

            if (powerWatts <= 0)
                throw new ArgumentException("Power must be greater than zero");

            //Id = Guid.NewGuid();
            SolarPlantId = solarPlantId;
            Brand = brand;
            Model = model;
            Quantity = quantity;
            PowerWatts = powerWatts;
        }

        /// <summary>
        /// Update panel data.
        /// </summary>
        public void Update(
            string brand,
            string model,
            int quantity,
            int powerWatts)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero");

            if (powerWatts <= 0)
                throw new ArgumentException("Power must be greater than zero");

            Brand = brand;
            Model = model;
            Quantity = quantity;
            PowerWatts = powerWatts;
        }
    }
}