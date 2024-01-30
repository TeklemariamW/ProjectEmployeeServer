using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Project
    {
        public Guid ProjectId { get; set; }
        [Required(ErrorMessage = "Project name is required")]
        public string? ProjectName { get; set; }
        [Required(ErrorMessage = "Project owner is required")]
        public string? ProjectOwner { get; set; }
        public DateTime ProjectCreationTime { get; set; }
        public DateTime? ProjectEndTime { get; set; }
        public bool IsActive { get; set; } = false;
    }
}
