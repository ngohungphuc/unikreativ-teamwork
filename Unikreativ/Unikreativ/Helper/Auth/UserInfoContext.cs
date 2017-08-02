using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading.Tasks;
using Unikreativ.Entities.Entities;

namespace Unikreativ.Helper.Auth
{
    public static class UserInfoContext
    {
        private static IHttpContextAccessor _contextAccessor;
        private static HttpContext _context { get { return _contextAccessor.HttpContext; } }

        public static string GetUserId(this ClaimsPrincipal user)
        {
            if (!user.Identity.IsAuthenticated)
                return null;

            ClaimsPrincipal currentUser = user;
            return currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
        }

        private static string UserName
        {
            get
            {
                string userName = string.Empty;
                if (_context != null)
                {
                    if (_context.User != null)
                    {
                        var identity = _context.User.Identity;

                        if (identity != null && identity.IsAuthenticated)
                        {
                            userName = identity.Name;
                        }
                    }
                }

                return userName;
            }
        }
        public static string GetUserName()
        {
            return _context.User.Identity.Name;
        }
    }

    public class UserResolverService
    {
        private readonly IHttpContextAccessor _context;
        private readonly UserManager<User> _userManager;
        public UserResolverService(IHttpContextAccessor context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<User> GetUser()
        {
            return await _userManager.FindByNameAsync(_context.HttpContext.User?.Identity?.Name);
        }
    }
}
