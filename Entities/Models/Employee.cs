using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Employee
    {
        public Guid EmployeeId { get; set; }
        [Required(ErrorMessage = "Employee name is required")]
        public string? EmpName { get; set; }
        [Required(ErrorMessage = "Employee address is required")]
        [StringLength(100, ErrorMessage = "Address cannot be longer than 100 characters")]
        public string? EmpAddress { get; set; }
        [Required(ErrorMessage = "Employee email is required")]
        public string? EmpEmail { get; set; }
        public int EmpTelefon { get; set; }
        public bool EmpAtWork { get; set; } = true;
    }
}
