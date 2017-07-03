using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Unikreativ.Entities.Entities;
using Unikreativ.Entities.Models;
using Unikreativ.Entities.Models.AccountViewModels;
using Unikreativ.Entities.Params;
using Unikreativ.Entities.ViewModel;
using Unikreativ.Helper.Filter;
using Unikreativ.Repositories.UnitOfWork;
using Unikreativ.Services.Interface;
using Unikreativ.Helper.Auth;
using Unikreativ.Helper.Confirm;
using Unikreativ.Helper.Security;

namespace Unikreativ.Controllers.API
{
    [Authorize("Bearer")]
    [Route("api/[controller]/[action]")]
    public class AdminController : Controller
    {
        private readonly UnitOfWork _unitOfWork = new UnitOfWork();
        private readonly UserManager<User> _userManager;
        private readonly IUserServices _userServices;
        private readonly IAccountServices _accountServices;
        private readonly ValidateAccount _validateAccount;
        private readonly IEmailSender _emailSender;
        private readonly IEmailTemplateService _emailTemplateService;

        public AdminController(
            UserManager<User> userManager,
            IUserServices userServices,
            IAccountServices accountServices,
            ValidateAccount validateAccount,
            IEmailSender emailSender,
             IEmailTemplateService emailTemplateService)
        {
            _userManager = userManager;
            _userServices = userServices;
            _validateAccount = validateAccount;
            _emailSender = emailSender;
            _accountServices = accountServices;
            _emailTemplateService = emailTemplateService;
        }

        #region Manage Account

        [HttpPost]
        [ValidModel]
        public async Task<IActionResult> NewClient([FromBody] Client clientDto)
        {
            var account = await CreateNewAccount(clientDto);

            await _userManager.AddToRoleAsync(account.User, "Client");
            var signUpInfo = new SignUpInfo
            {
                UserName = account.User.UserName,
                SignupUrl = account.CallbackUrl,
                RandomPassword = account.RandomPassword
            };
            var bodyContent = await _emailTemplateService.RenderTemplateAsync("Account/AccountConfirm.cshtml", signUpInfo);
            await _emailSender.SendEmail(EmailType.ClientAccount, clientDto.Email, bodyContent);

            return Json(new { result = true, msg = "Create new client success" });
        }

        [HttpPost]
        [ValidModel]
        public async Task<IActionResult> NewMember([FromBody] Member memberDto)
        {
            var account = await CreateNewAccount(memberDto);

            await _userManager.AddToRoleAsync(account.User, memberDto.Role);
            var signUpInfo = new SignUpInfo
            {
                UserName = account.User.UserName,
                SignupUrl = account.CallbackUrl,
                RandomPassword = account.RandomPassword
            };
            var bodyContent = await _emailTemplateService.RenderTemplateAsync("Account/AccountConfirm.cshtml", signUpInfo);
            await _emailSender.SendEmail(EmailType.MemberAccount, memberDto.Email, bodyContent);

            return Json(new { result = true, msg = "Create new member success", accountId = account.User.Id });
        }

        [HttpPut]
        [ValidModel]
        public async Task<IActionResult> UpdateClientInfo([FromBody] Client clientDto)
        {
            var client = Mapper.Map<User>(clientDto);
            await UpdateUserInfoAsync(client);
            return Json(new { result = true, msg = "Update Client success" });
        }

        [HttpPut]
        [ValidModel]
        public async Task<IActionResult> UpdateMemberInfo([FromBody] Member memberDto)
        {
            var member = Mapper.Map<User>(memberDto);
            await UpdateUserInfoAsync(member);
            return Json(new { result = true, msg = "Update Member success" });
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAccount(string id)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));

            var clientToDelete = await _unitOfWork.UserRepository.GetByIdAsync(id);
            await _unitOfWork.UserRepository.DeleteAsync(clientToDelete);

            return Json(new { result = true, msg = "Delete account success" });
        }


        #endregion Manage Account

        #region Private 

        private async Task<RegisterViewModel> CreateNewAccount(dynamic accountDto)
        {
            if (accountDto == null)
                throw new ArgumentNullException(nameof(accountDto));

            var account = Mapper.Map<User>(accountDto);

            if (await _validateAccount.CheckAccountExist(accountDto.UserName)) throw new Exception("Account already exist");
            if (await _validateAccount.CheckEmailExist(accountDto.Email)) throw new Exception("Email already exist");

            var randomPassword = GenerateToken.RandomString();
            var result = await _userManager.CreateAsync(account, randomPassword);
            if (!result.Succeeded) throw new Exception("Something went wrong please try again later");

            var code = await _userManager.GenerateEmailConfirmationTokenAsync(account);
            var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = account.Id, code }, HttpContext.Request.Scheme);

            return new RegisterViewModel()
            {
                User = account,
                Code = code,
                CallbackUrl = callbackUrl,
                RandomPassword = randomPassword
            };
        }

        private async Task UpdateUserInfoAsync(dynamic accountDto)
        {
            if (accountDto == null) throw new Exception("Account not exist");
            await _userServices.UpdateAccountInfo(accountDto, accountDto.Id);
        }
        #endregion
    }
}