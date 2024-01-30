using System;

namespace Entities.DTO.Project
{
    public class ProjectDto
    {
        public string? ProjectName { get; set; }
        public string? ProjectOwner { get; set; }
        public DateTime ProjectCreationTime { get; set; }
        public DateTime? ProjectEndTime { get; set; }
        public bool IsActive { get; set; }
    }
}
