using AutoMapper;
using Contracts;
using Entities.DTO.Project;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace ProjectEmployeeServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private IRepositoryWrapper _repoWr;
        private IMapper _mapper;
        public ProjectController(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            _repoWr = repositoryWrapper;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllProjects()
        {
            try
            {
                var projects = _repoWr.ProjectRepo.GetAllProjects();

                //check if projects is null
                if (projects == null)
                {
                    return NotFound();
                }

                var projectsResult = _mapper.Map<IEnumerable<ProjectDto>>(projects);
                return Ok(projectsResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
        [HttpGet("{id}", Name = "ProjectById")]
        public IActionResult GetProjectById(Guid id)
        {
            try
            {
                var project = _repoWr.ProjectRepo.GetProjectById(id);
                if (project == null)
                {
                    return NotFound();
                }

                var projectResult = _mapper.Map<ProjectDto>(project);
                return Ok(projectResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateProject([FromBody] ProjectCreateDto project)
        {
            try
            {
                if (project == null)
                {
                    return BadRequest("Project object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                var projectEntiry = _mapper.Map<Project>(project);

                _repoWr.ProjectRepo.CreateProject(projectEntiry);
                _repoWr.Save();

                var createdProject = _mapper.Map<ProjectDto>(projectEntiry);

                return CreatedAtRoute("ProjectById", new { id = projectEntiry.ProjectId }, createdProject);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProject(Guid id, [FromBody] ProjectUpdateDto project)
        {
            try
            {
                if (project == null)
                {
                    return BadRequest("Project object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                var projectEntity = _repoWr.ProjectRepo.GetProjectById(id);

                if (projectEntity == null)
                {
                    return NotFound();
                }

                _mapper.Map(project, projectEntity);

                _repoWr.ProjectRepo.UpdateProject(projectEntity);
                _repoWr.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProject(Guid id)
        {
            try
            {
                var project = _repoWr.ProjectRepo.GetProjectById(id);

                if (project == null)
                {
                    return NotFound();
                }

                _repoWr.ProjectRepo.DeleteProject(project);
                _repoWr.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
