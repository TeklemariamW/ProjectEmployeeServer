namespace Entities.DTO.Employee
{
    public class EmployeeUpdateDto
    {
        public string? EmpName { get; set; }
        public string? EmpAddress { get; set; }
        public string? EmpEmail { get; set; }
        public int EmpTelefon { get; set; }
        public bool EmpAtWork { get; set; }
    }
}
