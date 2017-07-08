using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Unikreativ.Entities.Entities;
using Unikreativ.Repositories.Interface;
using Unikreativ.Repositories.UnitOfWork;
namespace Unikreativ.Repositories.Repositories
{

    public class EventRepository : IEventRepository
    {
        private readonly UnitOfWork.UnitOfWork _unitOfWork = new UnitOfWork.UnitOfWork();
        public async Task<Event> AddEventAsync(ClaimsIdentity user, Project projectInfo)
        {
            var dateCreate = DateTime.Now;
            var projectEvent = new Event
            {
                AssignBy = user.Name,
                DateAssigned = dateCreate,
                Description =
                    $"{user.Name} create project {projectInfo.ProjectName} at {dateCreate}"
            };

            await _unitOfWork.EventRepository.AddAsync(projectEvent);

            return projectEvent;
        }
    }
}
