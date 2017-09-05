using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using System;
using System.Threading.Tasks;
using Unikreativ.Entities.Entities;
using Unikreativ.Entities.Models.AccountViewModels;
using Unikreativ.Entities.ViewModel;
using Unikreativ.Helper.Auth;
using Unikreativ.Helper.Security;
using Unikreativ.Repositories.UnitOfWork;
namespace Unikreativ.Helper.Account
{
    public interface IAccountHelper
    {
        Task UpdateUserInfoAsync(User account);
        Task<dynamic> CreateNewAccount(dynamic accountDto);
    }

    public class AccountHelper: IAccountHelper
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;
        private readonly IValidateAccount _validateAccount;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUrlHelperFactory _urlHelperFactory;
        private readonly IActionContextAccessor _actionAccessor;
        public AccountHelper(
            IUnitOfWork unitOfWork,
            UserManager<User> userManager,
            IValidateAccount validateAccount,
            IHttpContextAccessor httpContextAccessor,
            IUrlHelperFactory urlHelperFactory,
            IActionContextAccessor actionAccessor
            )
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _validateAccount = validateAccount;
            _httpContextAccessor = httpContextAccessor;
            _urlHelperFactory = urlHelperFactory;
            _actionAccessor = actionAccessor;
        }

        public async Task UpdateUserInfoAsync(User account)
        {
            if (account == null) throw new ArgumentNullException(nameof(account));
            await _unitOfWork.Repository<User>().UpdateAsync(account);
        }

        public async Task<dynamic> CreateNewAccount(dynamic accountDto)
        {
            if (accountDto == null)
                throw new ArgumentNullException(nameof(accountDto));

            var account = Mapper.Map<User>(accountDto);

            if (await _validateAccount.CheckAccountExist(accountDto.UserName))
            {
                return AccountRegisterResult.AccountExist;
            }

            if (await _validateAccount.CheckEmailExist(accountDto.Email))
            {
                return AccountRegisterResult.EmailExist;
            }

            var randomPassword = GenerateToken.RandomString();
            var result = await _userManager.CreateAsync(account, randomPassword);

            if (!result.Succeeded)
            {
                return AccountRegisterResult.Failed;
            }

            var code = await _userManager.GenerateEmailConfirmationTokenAsync(account);
            var callbackUrl = _urlHelperFactory.GetUrlHelper(_actionAccessor.ActionContext)
                .Action("ConfirmEmail", "Account", new { userId = account.Id, code },
                _httpContextAccessor.HttpContext.Request.Scheme);

            return new RegisterViewModel()
            {
                User = account,
                Code = code,
                CallbackUrl = callbackUrl,
                RandomPassword = randomPassword
            };
        }

    }

  
}
