using Entities.Models;

namespace Contracts
{
    public interface IProjectRepository
    {
        IEnumerable<Project> GetAllProjects();
        Project GetProjectById(Guid projId);
        void CreateProject(Project project);
        void UpdateProject(Project project);
        void DeleteProject(Project project);
    }
}
