using System.Linq;
using Unikreativ.Entities.Entities;
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

        public User GetUserByName(string name)
        {
            return _userRepository.GetUserByName(name);
        }

        public IQueryable<Member> GetTeamMember()
        {
            return _userRepository.GetTeamMembers();
        }

        public IQueryable<User> GetClients()
        {
            return _userRepository.GetClients();
        }
    }
}