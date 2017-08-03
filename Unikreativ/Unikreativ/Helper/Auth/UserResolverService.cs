using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading.Tasks;
using Unikreativ.Entities.Entities;

namespace Unikreativ.Helper.Auth
{
    public class UserResolverService
    {
        private readonly IHttpContextAccessor _context;
        private readonly UserManager<User> _userManager;
        public UserResolverService(IHttpContextAccessor context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<User> GetUser() => await _userManager.FindByNameAsync(_context.HttpContext.User?.Identity?.Name);

        public string GetUserName() => _context.HttpContext.User?.Identity?.Name;

        public async Task<string> GetUserId()
        {
            var user =  await _userManager.FindByNameAsync(_context.HttpContext.User?.Identity?.Name);
            return user.Id;
        }
    }
}
