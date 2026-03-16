namespace EnergyMonitoring.Application.Auth
{
    /// <summary>
    /// Request to register a new user.
    /// Solicitud para registrar usuario.
    /// </summary>
    public class RegisterUserRequest
    {
        /// <summary>
        /// Email del usuario
        /// </summary>
        public string Email { get; set; } = default!;

        /// <summary>
        /// Contraseña
        /// </summary>
        public string Password { get; set; } = default!;

        /// <summary>
        /// Nombre completo
        /// </summary>
        public string FullName { get; set; } = default!;

        /// <summary>
        /// Rol (Owner, Technician, Admin)
        /// </summary>
        public string Role { get; set; } = "Owner";
    }
}
