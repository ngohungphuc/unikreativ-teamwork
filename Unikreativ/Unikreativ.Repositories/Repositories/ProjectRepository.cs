using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Unikreativ.Entities.Data;
using Unikreativ.Entities.Entities;
using Unikreativ.Repositories.Interface;

namespace Unikreativ.Repositories.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ApplicationDbContext _context;

        public ProjectRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Project> GetProjectByName(string projectName)
        {
            var projectDetail = await _context.Projects.Where(p => p.ProjectName == projectName)
                .Include("Billings")
                .Include("TasksRequests")
                .Include("SubTasks")
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return projectDetail;
        }

        public async Task AddProjectAsync(Project project)
        {
            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();
        }

       
    }
}
