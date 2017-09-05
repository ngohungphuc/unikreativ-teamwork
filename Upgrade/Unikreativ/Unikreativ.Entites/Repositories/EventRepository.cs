using System;
using System.Threading.Tasks;
using Unikreativ.Entities.Data;
using Unikreativ.Entities.Entities;
using Unikreativ.Repositories.Interface;
namespace Unikreativ.Repositories.Repositories
{

    public class EventRepository : IEventRepository
    {
        private readonly ApplicationDbContext _context;

        public EventRepository(ApplicationDbContext context)
        {
            _context = context;
        }

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
                Project = projectInfo
            };

            await _context.Events.AddAsync(projectEvent);
            await _context.SaveChangesAsync();

            return projectEvent;
        }
    }
}
