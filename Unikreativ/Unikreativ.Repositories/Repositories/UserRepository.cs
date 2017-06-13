using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Unikreativ.Entities.Data;
using Unikreativ.Entities.Entities;
using Unikreativ.Entities.ViewModel;
using Unikreativ.Repositories.Interface;

namespace Unikreativ.Repositories.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DbSet<User> _dbSet;
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");
            _context = context;
            _dbSet = context.Set<User>();
        }

        public User GetUserByName(string name)
        {
            return _dbSet.FirstOrDefault(x => x.UserName == name);
        }

        public IQueryable<Member> GetTeamMembers()
        {
            var teamMembers = from user in _context.Users
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
                              };
            return teamMembers;
        }

        public IQueryable<User> GetClients()
        {
            var role = _context.Roles.SingleOrDefault(r => r.Name == "Client");
            var usersNotInRole = _dbSet.Where(m => m.Roles.All(r => r.RoleId == role.Id)).Include(ur => ur.Roles);
            return usersNotInRole;
        }
    }
}