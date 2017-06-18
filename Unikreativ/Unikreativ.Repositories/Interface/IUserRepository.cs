using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unikreativ.Entities.Entities;
using Unikreativ.Entities.ViewModel;

namespace Unikreativ.Repositories.Interface
{
    public interface IUserRepository
    {
        User GetUserByName(string name);

        Task<List<Member>> GetTeamMembers();

        Task<List<User>> GetClients();
    }
}