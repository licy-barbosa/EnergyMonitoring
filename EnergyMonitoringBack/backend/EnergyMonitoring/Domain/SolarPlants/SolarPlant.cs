using EnergyMonitoring.Application.DTOs.SolarPlants;
using EnergyMonitoring.Domain.Common;

namespace EnergyMonitoring.Domain.Entities
{
    /// <summary>
    /// Represents a solar installation or system.
    /// Representa la instalación solar completa.
    /// </summary>
    public class SolarPlant : AuditableEntity, ICompanyEntity
    {
        /// <summary>
        /// Unique identifier of the solar plant.
        /// Identificador único de la planta solar.
        /// </summary>
        public Guid Id { get; private set; }

        public Guid CompanyId { get; private set; }

        public Company Company { get; private set; } = default!;

        /// <summary>
        /// Name of the solar plant.
        /// Nombre de la planta solar.
        /// </summary>
        public string Name { get; private set; } = default!;

        /// <summary>
        /// Physical location of the installation.
        /// Ubicación física de la instalación.
        /// </summary>
        public string? Location { get; private set; }

        public bool IsActive { get; private set; }

        public DateTime InstallationDate { get; private set; }

        private readonly List<SolarPanel> _panels = new();
        private readonly List<Inverter> _inverters = new();
        private readonly List<EnergyReading> _energyReadings = new();

        private SolarPlant() { } // EF

        public SolarPlant(
            Guid companyId,
            string name,
            string? location,
            bool isActive,
            DateTime installationDate)
        {
            Id = Guid.NewGuid();
            CompanyId = companyId;
            Name = name;
            Location = location;
            IsActive = isActive;
            InstallationDate = installationDate;
        }

        public void Update(string name, string? location,  bool isActive, DateTime installationDate)
        {
            Name = name;
            Location = location;
            IsActive = isActive;
            InstallationDate = installationDate;
        }

        public void AddInverter(
            string? brand,
            string? model,
            string? platform,
            DateTime installationDate)
                {
            var inverter = new Inverter(
                Id,
                brand,
                model,
                platform,
                installationDate
            );

            _inverters.Add(inverter);
        }

        // 🔹 Panels
        public IReadOnlyCollection<SolarPanel> Panels => _panels.AsReadOnly();

        public void SyncPanels(IEnumerable<UpdateSolarPanelDTO> panels)
        {
            var existingPanels = _panels.ToList();

            foreach (var dto in panels)
            {
                SolarPanel? existing = null;

                if (dto.Id.HasValue)
                {
                    existing = existingPanels
                        .FirstOrDefault(p => p.Id == dto.Id.Value);
                }

                if (existing != null)
                {
                    existing.Update(
                        dto.Brand,
                        dto.Model,
                        dto.Quantity,
                        dto.PowerWatts
                    );
                }
                else
                {
                    var panel = new SolarPanel(
                        Id,
                        dto.Brand,
                        dto.Model,
                        dto.Quantity,
                        dto.PowerWatts
                    );
                 
                    _panels.Add(panel);
                }
            }

            var dtoIds = panels
                .Where(p => p.Id.HasValue)
                .Select(p => p.Id!.Value)
                .ToHashSet();

            var toRemove = existingPanels
                .Where(p => !dtoIds.Contains(p.Id))
                .ToList();

            foreach (var panel in toRemove)
            {
                _panels.Remove(panel);
            }
        }

        public int PanelCount =>
            _panels.Sum(p => p.Quantity);

        public decimal TotalPowerKw =>
            _panels.Sum(p => p.Quantity * p.PowerWatts) / 1000m;

        // 🔹 Inverters
        public IReadOnlyCollection<Inverter> Inverters => _inverters.AsReadOnly();

        // 🔹 Energy Readings
        public IReadOnlyCollection<EnergyReading> EnergyReadings => _energyReadings.AsReadOnly();

        public void AddEnergyReading(EnergyReading reading)
            => _energyReadings.Add(reading);

        // 🔥 Comportamiento de dominio
        public void Activate()
            => IsActive = true;

        public void Deactivate()
        {
            if (_panels.Any())
                throw new InvalidOperationException(
                    "Cannot deactivate plant with panels installed.");

            IsActive = false;
        }

        public ICollection<Device> Devices { get; private set; } = new List<Device>();
    }
}