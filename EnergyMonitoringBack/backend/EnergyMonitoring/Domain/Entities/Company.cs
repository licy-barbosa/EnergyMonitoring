using EnergyMonitoring.Domain.Common;

namespace EnergyMonitoring.Domain.Entities
{
    public class Company : AuditableEntity
    {
        public Guid Id { get; private set; }

        public string Name { get; private set; } = default!;

        public bool IsActive { get; private set; } = true;

        public ICollection<ApplicationUser> Users { get; private set; } = new List<ApplicationUser>();

        public ICollection<SolarPlant> SolarPlants { get; private set; } = new List<SolarPlant>();

        private Company() { }

        public Company(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }
}
