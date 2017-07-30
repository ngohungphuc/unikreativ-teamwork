using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Unikreativ.Entities.Data;
using Unikreativ.Entities.Entities;
using Unikreativ.Entities.Mapping;
using Unikreativ.Entities.ViewModel;
using Unikreativ.Repositories.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Unikreativ.Repositories.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Member>> GetTeamMembers()
        {
            return await (from user in _context.Users
                          join userRole in _context.UserRoles on user.Id equals userRole.UserId
                          join role in _context.Roles on userRole.RoleId equals role.Id
                          where role.Name != "Client"
                          select new Member()
                          {
                              Id = user.Id,
                              CompanyName = user.CompanyName,
                              Email = user.Email,
                              PhoneNumber = user.PhoneNumber,
                              Role = role.Name,
                              JobTitle = user.JobTitle,
                              NormalizedUserName = user.NormalizedUserName,
                              ChargeRate = user.ChargeRate
                          }).AsNoTracking().ToListAsync();
        }

        public async Task<List<Client>> GetClients(string clientName = null)
        {
            var role = _context.Roles.SingleOrDefault(r => r.Name == "Client");

            var client = await _context.Users
                .Where(m => m.Roles.All(r => r.RoleId == role.Id))
                .Select(Mapping.ClientMapping)
                .AsNoTracking()
                .ToListAsync();

            return !string.IsNullOrEmpty(clientName) ? client.Where(x => x.UserName.Contains(clientName.ToLower())).ToList() : client;
        }
    }
}