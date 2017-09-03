﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unikreativ.Entities.Entities;
using Unikreativ.Entities.Models.AccountViewModels;
using Unikreativ.Helper.Auth;
using Unikreativ.Helper.Security;
using Unikreativ.Repositories.UnitOfWork;
namespace Unikreativ.Helper.Account
{

    public interface IAccountHelper
    {
        Task UpdateUserInfoAsync(User account);
        Task<RegisterViewModel> CreateNewAccount(dynamic accountDto);
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
            if (account == null) throw new Exception("Account null");
            await _unitOfWork.Repository<User>().UpdateAsync(account);
        }

        public async Task<RegisterViewModel> CreateNewAccount(dynamic accountDto)
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
