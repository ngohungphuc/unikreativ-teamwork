using System;
using System.Threading.Tasks;
using Unikreativ.Entities.Data;
using Unikreativ.Entities.Entities;
using Unikreativ.Helper.Auth;
using Unikreativ.Repositories.Interface;
namespace Unikreativ.Repositories.Repositories
{

    public class EventRepository : IEventRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserResolverService _userResolverService;
        public EventRepository(
             ApplicationDbContext context,
             IUserResolverService userResolverService
             )
        {
            _context = context;
            _userResolverService = userResolverService;
        }

        public async Task<Event> AddEventAsync(Project projectInfo)
        {
            var currentUser = await _userResolverService.GetUser();
            var projectEvent = new Event
            {
                TaskName = projectInfo.ProjectName,
                AssignBy = currentUser.FullName,
                DateAssigned = DateTime.Now,
                IsCompleted = false,
                Description =
                    $"{currentUser.FullName} create project {projectInfo.ProjectName} at {DateTime.Now}",
                Project = projectInfo
            };

            await _context.Events.AddAsync(projectEvent);
            await _context.SaveChangesAsync();

            return projectEvent;
        }
    }
}
