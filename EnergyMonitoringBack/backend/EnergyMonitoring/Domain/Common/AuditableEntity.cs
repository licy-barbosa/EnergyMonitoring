namespace EnergyMonitoring.Domain.Common
{
    public abstract class AuditableEntity
    {
        public DateTime CreatedAt { get; protected set; }

        public string CreatedBy { get; protected set; } = default!;

        public DateTime? UpdatedAt { get; protected set; }

        public string? UpdatedBy { get; protected set; }

        public void SetCreated(string userId)
        {
            CreatedAt = DateTime.UtcNow;
            CreatedBy = userId;
        }

        public void SetUpdated(string userId)
        {
            UpdatedAt = DateTime.UtcNow;
            UpdatedBy = userId;
        }
    }
}