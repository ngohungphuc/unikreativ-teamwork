using System.Threading.Tasks;
using Unikreativ.Entities.Entities;

namespace Unikreativ.Repositories.Interface
{
    public interface IProjectRepository
    {
        Task AddProjectAsync(Project project);
    }
}
