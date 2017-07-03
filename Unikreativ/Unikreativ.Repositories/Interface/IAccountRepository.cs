using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unikreativ.Entities.Entities;
using Unikreativ.Entities.Params;

namespace Unikreativ.Repositories.Interface
{
    public interface IAccountRepository
    {
        Task<AccountRequest> AddNewRequestAccount(string email, string token);

    }
}