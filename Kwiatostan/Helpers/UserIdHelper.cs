using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Kwiatostan.Helpers
{
    public class UserIdHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<IdentityUser> _userManager;

        public UserIdHelper(IHttpContextAccessor httpContextAccessor, UserManager<IdentityUser> userManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public string? GetCurrentUserId()
        {
            System.Security.Claims.ClaimsPrincipal? principal = _httpContextAccessor?.HttpContext?.User;
            if (principal == null) { return null; } 

            var userId = _userManager.GetUserId(principal);
            return userId;
        }

    }
}
