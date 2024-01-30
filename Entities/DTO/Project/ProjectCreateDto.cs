using System.ComponentModel.DataAnnotations;

namespace Entities.DTO.Project
{
    public class ProjectCreateDto
    {
        [Required(ErrorMessage = "Project name is required")]
        public string? ProjectName { get; set; }
        [Required(ErrorMessage = "Project owner is required")]
        public string? ProjectOwner { get; set; }
        public DateTime ProjectCreationTime { get; set; }
        public DateTime? ProjectEndTime { get; set; }
    }
}
