using System.Collections.Generic;
using System.Threading.Tasks;
using Unikreativ.Entities.ViewModel;

namespace Unikreativ.Repositories.Interface
{
    public interface IUserRepository
    {
        Task<List<Member>> GetTeamMembers();

        Task<List<Client>> GetClients(string clientName);


    }
}