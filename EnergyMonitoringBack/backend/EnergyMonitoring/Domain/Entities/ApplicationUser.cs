using Microsoft.AspNetCore.Identity;

namespace EnergyMonitoring.Domain.Entities
{
    /// <summary>
    /// Represents a system user.
    /// Representa un usuario del sistema.
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        /// <summary>
        /// Full name of the user.
        /// Nombre completo.
        /// </summary>
        public string? FullName { get; set; }

        /// <summary>
        /// Indicates if the user is active.
        /// Indica si el usuario está activo.
        /// </summary>
        public bool IsActive { get; set; } = true;

        public Guid CompanyId { get; set; }

        public Company Company { get; set; } = default!;
    }
}