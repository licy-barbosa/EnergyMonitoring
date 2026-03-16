namespace EnergyMonitoring.Application.DTOs.Auth
{
    public class AuthResponseDTO
    {
        public string UserId { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public DateTime Expiration { get; set; }
        public string Token { get; set; } = string.Empty;   
        public Guid CompanyId { get; set; }
    }
}