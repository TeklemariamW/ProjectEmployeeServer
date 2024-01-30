using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Repository
{
    public class ProjectRepository : RepositoryBase<Project>, IProjectRepository
    {
        public ProjectRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }

        public IEnumerable<Project> GetAllProjects()
        {
            return FindAll()
                .OrderByDescending(p => p.ProjectCreationTime)
                .ToList();
        }

        public void CreateProject(Project project)
        {
            Create(project);
        }

        public Project GetProjectById(Guid projId)
        {
            return FindByCondition(p => p.ProjectId.Equals(projId))
                .FirstOrDefault();
        }
        public void UpdateProject(Project project)
        {
            Update(project);
        }

        public void DeleteProject(Project project)
        {
            Delete(project);
        }
    }
}
