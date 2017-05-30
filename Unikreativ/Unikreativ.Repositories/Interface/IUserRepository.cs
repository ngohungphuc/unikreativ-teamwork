﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unikreativ.Entities.Entities;
using Unikreativ.Entities.ViewModel;

namespace Unikreativ.Repositories.Interface
{
    public interface IUserRepository : IGenericRepository<User>
    {
        //User GetUserById(string id);

        User GetUserByName(string name);

        IQueryable<Member> GetTeamMembers();

        IQueryable<User> GetClients();
    }
}