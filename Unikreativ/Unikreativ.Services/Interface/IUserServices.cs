using System.Collections.Generic;
using System.Threading.Tasks;
using Unikreativ.Entities.ViewModel;

namespace Unikreativ.Services.Interface
{
    public interface IUserServices
    {
        Task<List<Member>> GetTeamMembers();

        Task<List<Client>> GetClients(string clientName);


    }
}