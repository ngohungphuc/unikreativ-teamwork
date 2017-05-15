using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Unikreativ.Entities.Entities;
using Unikreativ.Entities.Models.AccountViewModels;
using ILoggerFactory = Microsoft.Extensions.Logging.ILoggerFactory;

namespace Unikreativ.Controllers.API
{
    [Route("api/[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ILogger _logger;

        public AccountController(
             UserManager<User> userManager,
             SignInManager<User> signInManager,
             ILoggerFactory loggerFactory)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = loggerFactory.CreateLogger<AccountController>();
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, true);
            if (result.Succeeded)
            {
                _logger.LogInformation(1, "User logged in.");
                return Json(new { success = true });
            }

            return Json(new { isInvalid = true });
        }
    }
}