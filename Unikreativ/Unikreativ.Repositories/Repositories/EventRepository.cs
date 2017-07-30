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
        public async Task<Event> AddEventAsync(Project projectInfo)
        {
            var project = await _unitOfWork.ProjectRepository.FindAsync(x => x.Id == projectInfo.Id);
            var projectEvent = new Event
            {
                TaskName = projectInfo.ProjectName,
                AssignBy = projectInfo.Client.FullName,
                DateAssigned = DateTime.Now,
                IsCompleted = false,
                Description =
                    $"{projectInfo.Client.FullName} create project {projectInfo.ProjectName} at {DateTime.Now}",
                Project = project,
                TasksRequest = null
            };


            await _unitOfWork.EventRepository.AddAsync(projectEvent);

            return projectEvent;
        }
    }
}
