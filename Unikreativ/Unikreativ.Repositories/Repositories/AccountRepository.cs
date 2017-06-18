using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Unikreativ.Entities.Data;
using Unikreativ.Entities.Entities;
using Unikreativ.Repositories.Interface;

namespace Unikreativ.Repositories.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationDbContext _context;

        public AccountRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<AccountRequest> AddNewRequestAccount(string email, string token)
        {
            var newAccountRequest = new AccountRequest
            {
                Email = email,
                ExpireTime = 86400,
                Token = token
            };
            _context.AccountRequests.Add(newAccountRequest);
            await _context.SaveChangesAsync();
            return newAccountRequest;
        }

        public async Task<IQueryable<AccountRequest>> GetAccountRequestId(string email)
        {
            var accountRequestId = await _context.AccountRequests.Where(data => data.Email.Equals(email)).ToListAsync();
            return accountRequestId.AsQueryable();
        }
    }
}