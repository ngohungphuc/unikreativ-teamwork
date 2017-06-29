using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Unikreativ.Entities.Data;
using Unikreativ.Entities.Entities;
using Unikreativ.Entities.Params;
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
                Token = token,
                RequestTime = DateTime.Today
            };

            await _context.AccountRequests.AddAsync(newAccountRequest);
            await _context.SaveChangesAsync();

            return newAccountRequest;
        }

        public async Task<bool> ActivateAccount(ActivateAccountQueryParams queryParams)
        {
            var currentTime = DateTime.Today.Day;
            var requestExist = _context.AccountRequests
                .Where(
                    request => request.Token == queryParams.Token
                               && request.RequestTime.Day - currentTime > 0);

            if (requestExist == null) return false;

            var users = await _context.Users.FirstOrDefaultAsync(x => x.Email == queryParams.EmailTo);
            users.EmailConfirmed = true;
            await _context.SaveChangesAsync();

            return true;
        }
    }
}