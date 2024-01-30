using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }
        public IEnumerable<Employee> GetAllEmployees()
        {
            return FindAll()
                .OrderBy(em => em.EmployeeId)
                .ToList();
        }

        public Employee GetEmployeeById(Guid empid)
        {
            return FindByCondition(e => e.EmployeeId == empid)
                .FirstOrDefault();
        }
        public void AddEmployee(Employee employee)
        {
            Create(employee);
        }
        public void UpdateEmployee(Employee employee)
        {
            Update(employee);
        }
        public void DeleteEmployee(Employee employee)
        {
            Delete(employee);
        }
    }
}
