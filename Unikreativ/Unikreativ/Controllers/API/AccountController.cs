using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Unikreativ.Entities.Entities;
using Unikreativ.Helper.Filter;
using Unikreativ.Entities.Params;
using Unikreativ.Helper.Auth;
using Unikreativ.Helper.Confirm;
using Unikreativ.Repositories.UnitOfWork;
using Unikreativ.Services.Interface;

namespace Unikreativ.Controllers.API
{
    [Route("[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly UnitOfWork _unitOfWork = new UnitOfWork();
        private readonly UserManager<User> _userManager;
        private readonly IUserServices _userServices;
        private readonly IAccountServices _accountServices;
        private readonly ValidateAccount _validateAccount;
        private readonly IEmailSender _emailSender;

        public AccountController(
            UserManager<User> userManager,
            IUserServices userServices,
            IAccountServices accountServices,
            ValidateAccount validateAccount,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _userServices = userServices;
            _validateAccount = validateAccount;
            _emailSender = emailSender;
            _accountServices = accountServices;
        }

        [HttpGet]
        [ValidModel]
        public async Task<IActionResult> Confirm(RegisterQueryParams queryParams)
        {
            var result = await _accountServices.ActivateAccount(queryParams);
            return Json(result ? new { result = true, msg = "You can now login to website" } : new { result = false, msg = "Something went wrong" });
        }
    }
}