using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unikreativ.Entities.Entities;
using Unikreativ.Entities.Params;
using Unikreativ.Repositories.Interface;
using Unikreativ.Services.Interface;

namespace Unikreativ.Services.Services
{
    public class AccountServices : IAccountServices
    {
        private readonly IAccountRepository _accountRepository;

        public AccountServices(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<IQueryable<AccountRequest>> GetAccountRequestId(string email)
        {
            return await _accountRepository.GetAccountRequestId(email);
        }

        public async Task<AccountRequest> AddNewRequestAccount(string email, string token)
        {
            return await _accountRepository.AddNewRequestAccount(email, token);
        }

        public async Task<bool> ActivateAccount(RegisterQueryParams queryParams)
        {
            return await _accountRepository.ActivateAccount(queryParams);
        }
    }
}