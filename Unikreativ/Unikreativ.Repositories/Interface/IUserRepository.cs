using System;
using System.Collections.Generic;
using System.Text;
using Unikreativ.Entities.Entities;

namespace Unikreativ.Repositories.Interface
{
    public interface IUserRepository : IGenericRepository<User>
    {
        //User GetUserById(string id);

        User GetUserByName(string name);

        Object GetTeamMembers();
    }
}