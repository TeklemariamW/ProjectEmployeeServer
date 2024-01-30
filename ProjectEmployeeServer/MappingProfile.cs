using AutoMapper;
using Entities.DTO.Employee;
using Entities.DTO.Project;
using Entities.Models;

namespace ProjectEmployeeServer
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // From --> To

            //Project
            CreateMap<Project, ProjectDto>();
            CreateMap<ProjectCreateDto, Project>();
            CreateMap<ProjectUpdateDto, Project>();

            //Employee
            CreateMap<Employee, EmployeeDto>();
            CreateMap<EmployeeCreateDto, Employee>();
            CreateMap<EmployeeUpdateDto, Employee>();
        }
    }
}
