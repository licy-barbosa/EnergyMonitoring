namespace EnergyMonitoring.Application.DTOs.Auth
{
    public class RegisterUserResponseDTO
    {
        public string UserId { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Role { get; set; } = default!;
    }
}
