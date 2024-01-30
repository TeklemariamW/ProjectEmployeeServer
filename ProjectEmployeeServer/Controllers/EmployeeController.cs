using AutoMapper;
using Contracts;
using Entities.DTO.Employee;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace ProjectEmployeeServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IRepositoryWrapper _repoWr;
        private readonly IMapper _mapper;
        public EmployeeController(IRepositoryWrapper repoWr, IMapper mapper)
        {
            _repoWr = repoWr;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllEmployee()
        {
            try
            {
                var employees = _repoWr.EmployeeRepo.GetAllEmployees();

                //check if employees is null
                if (employees == null)
                {
                    return NotFound();
                }

                var employeeResult = _mapper.Map<IEnumerable<EmployeeDto>>(employees);
                return Ok(employeeResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{id}", Name = "EmployeeById")]
        public IActionResult GetEmployeeById(Guid id)
        {
            try
            {
                var employee = _repoWr.EmployeeRepo.GetEmployeeById(id);

                if (employee == null)
                {
                    return NotFound(id);
                }

                var employeeResult = _mapper.Map<EmployeeDto>(employee);
                return Ok(employeeResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpPost]
        public IActionResult AddEmployee([FromBody] EmployeeCreateDto employee)
        {
            try
            {
                if (employee == null)
                {
                    return BadRequest("Employee object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                var employeeEntity = _mapper.Map<Employee>(employee);

                _repoWr.EmployeeRepo.AddEmployee(employeeEntity);
                _repoWr.Save();

                var createdEmployee = _mapper.Map<EmployeeDto>(employeeEntity);

                return CreatedAtRoute("EmployeeById", new { id = employeeEntity.EmployeeId }, createdEmployee);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(Guid id, [FromBody] EmployeeUpdateDto employeeUpdate)
        {

            try
            {

                if (employeeUpdate is null)
                {
                    return BadRequest("Employee object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid employee model object");
                }

                var employee = _repoWr.EmployeeRepo.GetEmployeeById(id);

                if (employee == null)
                {
                    return NotFound();
                }

                _mapper.Map(employeeUpdate, employee);

                _repoWr.EmployeeRepo.UpdateEmployee(employee);
                _repoWr.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex?.Message);
            }

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            try
            {
                var employeeEntity = _repoWr.EmployeeRepo.GetEmployeeById(id);

                if (employeeEntity == null)
                {
                    return NotFound();
                }

                _repoWr.EmployeeRepo.DeleteEmployee(employeeEntity);
                _repoWr.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex?.Message);
            }
        }

    }
}
