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

namespace Unikreativ.Repositories.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public User GetUserByName(string name)
        {
            return _context.Users.FirstOrDefault(x => x.UserName == name);
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
                              Phone = user.PhoneNumber,
                              Role = role.Name,
                              JobTitle = user.JobTitle,
                              NormalizedUserName = user.NormalizedUserName
                          }).ToListAsync();
        }

        public async Task<List<User>> GetClients()
        {
            var role = _context.Roles.SingleOrDefault(r => r.Name == "Client");
            var usersNotInRole = await _context.Users.Where(m => m.Roles.All(r => r.RoleId == role.Id)).Include(ur => ur.Roles).ToListAsync();
            return usersNotInRole;
        }
    }
}