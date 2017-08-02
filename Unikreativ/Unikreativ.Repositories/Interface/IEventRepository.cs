using System.Threading.Tasks;
using Unikreativ.Entities.Entities;

namespace Unikreativ.Repositories.Interface
{
    public interface IEventRepository
    {
        Task<Event> AddEventAsync(Project projectInfo);
    }
}
