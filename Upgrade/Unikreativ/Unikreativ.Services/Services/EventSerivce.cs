using System.Threading.Tasks;
using Unikreativ.Entities.Entities;
using Unikreativ.Repositories.Interface;
using Unikreativ.Services.Interface;

namespace Unikreativ.Services.Services
{
    public class EventSerivce : IEventService
    {
        private readonly IEventRepository _eventRepository;

        public EventSerivce(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public async Task<Event> AddEventAsync(Project projectInfo)
        {
            return await _eventRepository.AddEventAsync(projectInfo);
        }
    }
}
