﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Unikreativ.Entities.ViewModel;
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

        public async Task<List<Member>> GetTeamMembers()
        {
            return await _userRepository.GetTeamMembers();
        }

        public async Task<List<Client>> GetClients(string clientName)
        {
            return await _userRepository.GetClients(clientName);
        }

    }
}