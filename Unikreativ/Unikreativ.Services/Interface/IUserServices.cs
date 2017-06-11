using System.Linq;
using Unikreativ.Entities.Entities;
using Unikreativ.Entities.ViewModel;

namespace Unikreativ.Services.Interface
{
    public interface IUserServices
    {
        User GetUserByName(string name);

        IQueryable<Member> GetTeamMember();

        IQueryable<User> GetClients();
    }
}