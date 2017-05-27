using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Unikreativ.Entities.Entities;
using Unikreativ.Repositories.Interface;
using Unikreativ.Services.Interface;

namespace Unikreativ.Services.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;

        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User GetUserByName(string name)
        {
            return _userRepository.GetUserByName(name);
        }

        public object GetTeamMember()
        {
            return _userRepository.GetTeamMembers();
        }
    }
}