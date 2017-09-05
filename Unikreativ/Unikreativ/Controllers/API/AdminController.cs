using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Unikreativ.Entities.Entities;
using Unikreativ.Entities.Models;
using Unikreativ.Entities.Models.Auth;
using Unikreativ.Entities.ViewModel;
using Unikreativ.Helper.Filter;
using Unikreativ.Repositories.UnitOfWork;
using Unikreativ.Services.Interface;
using Unikreativ.Helper.Auth;
using Unikreativ.Helper.Confirm;
using Unikreativ.Helper.Message;
using Unikreativ.Helper.Account;

namespace Unikreativ.Controllers.API
{
    [Authorize("Bearer")]
    [Route("api/[controller]/[action]")]
    public class AdminController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserServices _userServices;
        private readonly IAccountServices _accountServices;
        private readonly IValidateAccount _validateAccount;
        private readonly IEmailSender _emailSender;
        private readonly IEmailTemplateService _emailTemplateService;
        private readonly IAccountHelper _accountHelper;
        public AdminController(
            UserManager<User> userManager,
            IUnitOfWork unitOfWork,
            IUserServices userServices,
            IAccountServices accountServices,
            IValidateAccount validateAccount,
            IEmailSender emailSender,
            IEmailTemplateService emailTemplateService,
            IAccountHelper accountHelper)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _userServices = userServices;
            _validateAccount = validateAccount;
            _emailSender = emailSender;
            _accountServices = accountServices;
            _emailTemplateService = emailTemplateService;
            _accountHelper = accountHelper;
        }

        #region Manage Account

        [HttpPost]
        [ValidModel]
        public async Task<string> NewClient([FromBody] Client clientDto)
        {
            var account = await _accountHelper.CreateNewAccount(clientDto);

            await _userManager.AddToRoleAsync(account.User, "Client");
            var signUpInfo = new SignUpInfo
            {
                UserName = account.User.UserName,
                SignupUrl = account.CallbackUrl,
                RandomPassword = account.RandomPassword
            };

            string bodyContent = await _emailTemplateService.RenderTemplateAsync("Account/AccountConfirm.cshtml", signUpInfo);
            await _emailSender.SendEmail(EmailType.ClientAccount, clientDto.Email, bodyContent);

            return AccountValidate.ValidationMessage(RequestState.Success, "Create new client success");

        }

        [HttpPost]
        [ValidModel]
        public async Task<string> NewMember([FromBody] Member memberDto)
        {
            var account = await _accountHelper.CreateNewAccount(memberDto);
            await _userManager.AddToRoleAsync(account.User, memberDto.Role);
            var signUpInfo = new SignUpInfo
            {
                UserName = account.User.UserName,
                SignupUrl = account.CallbackUrl,
                RandomPassword = account.RandomPassword
            };
            string bodyContent = await _emailTemplateService.RenderTemplateAsync("Account/AccountConfirm.cshtml", signUpInfo);
            await _emailSender.SendEmail(EmailType.MemberAccount, memberDto.Email, bodyContent);

            return AccountValidate.ValidationMessage(RequestState.Success, "Create new member success");
        }

        [HttpPut]
        [ValidModel]
        public async Task<string> UpdateClientInfo([FromBody] Client clientDto)
        {
            var client = await _unitOfWork.Repository<User>().GetByIdAsync(clientDto.Id);
            client = Mapper.Map(clientDto, client);

            await _accountHelper.UpdateUserInfoAsync(client);

            return AccountValidate.ValidationMessage(RequestState.Success, "Update Client success");
        }

        [HttpPut]
        [ValidModel]
        public async Task<string> UpdateMemberInfo([FromBody] Member memberDto)
        {
            var member = await _unitOfWork.Repository<User>().GetByIdAsync(memberDto.Id);
            member = Mapper.Map(memberDto, member);

            await _accountHelper.UpdateUserInfoAsync(member);

            return AccountValidate.ValidationMessage(RequestState.Success, "Update Member success");
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<string> DeleteAccount(string id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var clientToDelete = await _unitOfWork.Repository<User>().GetByIdAsync(id);
            await _unitOfWork.Repository<User>().DeleteAsync(clientToDelete);

            return AccountValidate.ValidationMessage(RequestState.Success, "Delete account success");
        }

        #endregion Manage Account
    }
}