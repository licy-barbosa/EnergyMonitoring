using EnergyMonitoring.Application.Interfaces;
using System.Security.Claims;

namespace EnergyMonitoring.Infrastructure.Identity
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string? UserId =>
            _httpContextAccessor.HttpContext?.User?
                .FindFirstValue(ClaimTypes.NameIdentifier)
            ?? _httpContextAccessor.HttpContext?.User?
                .FindFirstValue("uid");

        public Guid? CompanyId
        {
            get
            {
                var value = _httpContextAccessor.HttpContext?.User?
                    .FindFirstValue("companyId");

                if (Guid.TryParse(value, out var id))
                    return id;

                return null;
            }
        }
    }
}