using System.Threading.Tasks;
using Unikreativ.Entities.Entities;

namespace Unikreativ.Services.Interface
{
    public interface IEventService
    {
        Task<Event> AddEventAsync(Project projectInfo);
    }
}
