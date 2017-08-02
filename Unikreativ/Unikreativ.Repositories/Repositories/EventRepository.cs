using System;
using System.Threading.Tasks;
using Unikreativ.Entities.Entities;
using Unikreativ.Repositories.Interface;
namespace Unikreativ.Repositories.Repositories
{

    public class EventRepository : IEventRepository
    {
        private readonly UnitOfWork.UnitOfWork _unitOfWork = new UnitOfWork.UnitOfWork();
        public async Task<Event> AddEventAsync(Project projectInfo)
        {
            var projectEvent = new Event
            {
                TaskName = projectInfo.ProjectName,
                AssignBy = projectInfo.Client.UserName,
                DateAssigned = DateTime.Now,
                IsCompleted = false,
                Description =
                    $"{projectInfo.Client.UserName} create project {projectInfo.ProjectName} at {DateTime.Now}",
                Project = projectInfo,
                TasksRequest = null
            };

            await _unitOfWork.EventRepository.AddAsync(projectEvent);

            return projectEvent;
        }
    }
}
