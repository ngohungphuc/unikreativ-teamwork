using System.Collections.Generic;
using System.Threading.Tasks;
using Unikreativ.Entities.Entities;
using Unikreativ.Repositories.Interface;
using Unikreativ.Services.Interface;

namespace Unikreativ.Services.Services
{
    public class ProjectServices : IProjectServices
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectServices(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<Project> GetProjectByName(string projectName)
        {
            return await _projectRepository.GetProjectByName(projectName);
        }

        public async Task AddProjectAsync(Project project)
        {
            await _projectRepository.AddProjectAsync(project);
        }
    }
}
