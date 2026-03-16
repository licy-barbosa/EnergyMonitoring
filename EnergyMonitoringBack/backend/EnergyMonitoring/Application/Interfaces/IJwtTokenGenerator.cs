using EnergyMonitoring.Application.DTOs.Auth;
using EnergyMonitoring.Domain.Entities;

namespace EnergyMonitoring.Application.Interfaces
{
    public interface IJwtTokenGenerator
    {
        Task<AuthResponseDTO> GenerateTokenAsync(ApplicationUser user);
    }
}