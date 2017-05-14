using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using log4net.Repository.Hierarchy;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Unikreativ.Entities.Entities;
using Unikreativ.Entities.Models.AccountViewModels;
using Unikreativ.Web.Services;
using ILoggerFactory = Microsoft.Extensions.Logging.ILoggerFactory;

namespace Unikreativ.Web.Controllers.API
{
    [Route("api/[controller]")]
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

        [Route("Login")]
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, true);
                if (result.Succeeded)
                {
                    _logger.LogInformation(1, "User logged in.");
                    return Json(new { success = true });
                }
            }

            // If we got this far, something failed, redisplay form
            return Json(new { isInvalid = true });
        }

        [Route("GetSomething")]
        public IActionResult GetSomething()
        {
            return Json(new { success = true });
        }
    }
}