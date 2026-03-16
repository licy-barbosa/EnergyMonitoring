using EnergyMonitoring.Application.DTOs.Auth;
using EnergyMonitoring.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EnergyMonitoring.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        /// <summary>
        /// Obtiene el usuario autenticado actualmente
        /// </summary>
        [Authorize]
        [HttpGet("current-user")]
        public async Task<IActionResult> GetCurrentUser()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
                return Unauthorized();

            var result = new CurrentUserDTO
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName
            };

            return Ok(result);
        }
    }
}