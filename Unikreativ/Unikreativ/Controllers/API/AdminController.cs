using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Unikreativ.Entities.Entities;
using Unikreativ.Entities.Models;
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

        public AdminController(
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

        #region Manage Account

        [HttpPost]
        [ValidModel]
        public async Task<IActionResult> NewClient([FromBody] Client clientDto)
        {
            var account = await CreateNewAccount(clientDto);

            await _userManager.AddToRoleAsync(account, "Client");
            await _accountServices.AddNewRequestAccount(clientDto.Email, account.code);
            await _emailSender.SendEmail(EmailType.ClientAccount, clientDto.Email, account.callbackUrl);

            return Json(new { result = true, msg = "Create new client success" });
        }

        [HttpPost]
        [ValidModel]
        public async Task<IActionResult> NewMember([FromBody] Member memberDto)
        {
            var account = await CreateNewAccount(memberDto);

            await _userManager.AddToRoleAsync(account, memberDto.Role);
            await _accountServices.AddNewRequestAccount(memberDto.Email, account.code);
            await _emailSender.SendEmail(EmailType.MemberAccount, memberDto.Email, account.callbackUrl);

            return Json(new { result = true, msg = "Create new member success", accountId = account.Id });
        }

        [HttpPut]
        [ValidModel]
        public async Task<IActionResult> UpdateClientInfo([FromBody] Client clientDto)
        {
            await UpdateUserInfoAsync(clientDto);
            return Json(new { result = true, msg = "Update Client success" });
        }

        [HttpPut]
        [ValidModel]
        public async Task<IActionResult> UpdateMemberInfo([FromBody] Member memberDto)
        {
            await UpdateUserInfoAsync(memberDto);
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

        public async Task UpdateUserInfoAsync(dynamic accountDto)
        {
            var account = await _unitOfWork.UserRepository.GetByIdAsync(accountDto.Id);
            if (account == null) throw new Exception("Account not exist");

            var accountToUpdate = Mapper.Map<User>(accountDto);
            await _unitOfWork.UserRepository.UpdateAsync(accountToUpdate, accountToUpdate.Id);
        }

        private async Task<dynamic> CreateNewAccount(dynamic accountDto)
        {
            if (accountDto == null)
                throw new ArgumentNullException(nameof(accountDto));

            var account = Mapper.Map<User>(accountDto);

            if (await _validateAccount.CheckAccountExist(accountDto.UserName)) throw new Exception("Account already exist");
            if (await _validateAccount.CheckEmailExist(accountDto.Email)) throw new Exception("Email already exist");

            var result = _userManager.CreateAsync(account, account.PasswordHash);
            if (!result.Succeeded) throw new Exception("Something went wrong please try again later");

            var code = await _userManager.GenerateEmailConfirmationTokenAsync(account);
            var callbackUrl = Url.Action("Confirm", "Account", new { userId = account.Id, code = code });

            return new
            {
                account,
                code,
                callbackUrl
            };
        }

        #endregion Manage Account
    }
}