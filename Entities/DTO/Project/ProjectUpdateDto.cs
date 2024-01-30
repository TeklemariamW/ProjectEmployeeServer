using System.ComponentModel.DataAnnotations;

namespace Entities.DTO.Project
{
    public class ProjectUpdateDto
    {
        [Required(ErrorMessage = "Name is required")]
        public string? ProjectOwner { get; set; }
        public DateTime? ProjectEndTime { get; set; }
        public bool IsActive { get; set; } = false;
    }
}
