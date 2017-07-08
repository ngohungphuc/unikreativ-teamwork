using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Unikreativ.Entities.Entities;
using Unikreativ.Repositories.Interface;
using Unikreativ.Services.Interface;

namespace Unikreativ.Services.Services
{
    public class EventSerivce : IEventService
    {
        private readonly IEventRepository _eventRepository;
        public Task<Event> AddEventAsync(ClaimsIdentity user, Project projectInfo)
        {
            return _eventRepository.AddEventAsync(user, projectInfo);
        }
    }
}
