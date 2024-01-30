using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryWrapper
    {
        IProjectRepository ProjectRepo { get; }
        IEmployeeRepository EmployeeRepo { get; }
        void Save();
    }
}
