using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Unikreativ.Entities.Entities;

namespace Unikreativ.Services.Interface
{
    public interface IEventService
    {
        Task<Event> AddEventAsync(ClaimsIdentity user, Project projectInfo);
    }
}
