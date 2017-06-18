using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unikreativ.Entities.Entities;

namespace Unikreativ.Repositories.Interface
{
    public interface IAccountRepository
    {
        Task<IQueryable<AccountRequest>> GetAccountRequestId(string email);

        Task<AccountRequest> AddNewRequestAccount(string email, string token);
    }
}