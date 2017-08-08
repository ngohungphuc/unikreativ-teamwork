using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unikreativ.Entities.Entities;

namespace Unikreativ.Helper.Auth
{
    public interface IValidateAccount
    {
        Task<bool> CheckAccountExist(string username);
        Task<bool> CheckEmailExist(string email);
    }

    public class ValidateAccount : IValidateAccount
    {
        private readonly UserManager<User> _userManager;

        public ValidateAccount(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> CheckAccountExist(string username)
        {
            var accountExist = await _userManager.FindByNameAsync(username);
            return accountExist != null;
        }

        public async Task<bool> CheckEmailExist(string email)
        {
            var emailExist = await _userManager.FindByEmailAsync(email);
            return emailExist != null;
        }
    }
}