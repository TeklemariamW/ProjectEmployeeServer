using Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repoContext;
        private IProjectRepository _projectRepository;
        private IEmployeeRepository _employeeRepository;
        public RepositoryWrapper(RepositoryContext repositoryContext) 
        { 
            _repoContext = repositoryContext;
        }
        public IProjectRepository ProjectRepo
        {
            get
            {
                _projectRepository ??= new ProjectRepository(_repoContext);
                return _projectRepository;
            }
        }

        public IEmployeeRepository EmployeeRepo 
        { 
            get
            {
                _employeeRepository ??= new EmployeeRepository(_repoContext);
                return _employeeRepository;
            }
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
