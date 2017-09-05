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



    }
}