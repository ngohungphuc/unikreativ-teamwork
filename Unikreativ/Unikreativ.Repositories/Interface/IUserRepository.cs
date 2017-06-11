using System.Linq;
using Unikreativ.Entities.Entities;
using Unikreativ.Entities.ViewModel;

namespace Unikreativ.Repositories.Interface
{
    public interface IUserRepository
    {
        User GetUserByName(string name);

        IQueryable<Member> GetTeamMembers();

        IQueryable<User> GetClients();
    }
}