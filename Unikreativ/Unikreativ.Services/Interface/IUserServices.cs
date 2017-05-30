using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unikreativ.Entities.Entities;
using Unikreativ.Entities.ViewModel;
using Unikreativ.Repositories.Interface;

namespace Unikreativ.Services.Interface
{
    public interface IUserServices
    {
        User GetUserByName(string name);

        IQueryable<Member> GetTeamMember();

        IQueryable<User> GetClients();
    }
}