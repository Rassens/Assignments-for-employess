using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using FINAL.Models;
using FINAL.Data.Entities;
using FINAL.Data;
using FINAL.Data.Repositories;




namespace FINAL.Controlers
{
    [Route("api/[controller]")]
    public class ProjectController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IProjectRepository _repository;

        public ProjectController(IProjectRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<ProjectModel[]>> Get()
        {
            try
            {
                var result = await _repository.GetAllProjectAsync();
                return _mapper.Map<ProjectModel[]>(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }

        [HttpGet("{ProjectId:int}")]
        public async Task<ActionResult<ProjectModel>> Get(int ProjectId)
        {
            try
            {
                var project = await _repository.GetProjectByIdAsync(ProjectId);
                if (project == null) return NotFound($"Could not find a project with id of {ProjectId}");
                return _mapper.Map<ProjectModel>(project);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to get Project");
            }
        }

        public async Task<ActionResult<ProjectModel>> Post([FromBody] ProjectModel model)
        {
            try
            {
                var existing = await _repository.GetEmployeeByIdAsync(model.ProjectId);
                if (existing != null) return BadRequest("Project exist");

                var project = _mapper.Map<Project>(model);

                _repository.Add(project);
                if (await _repository.SaveChangesAsync())
                    return Created($"/api/{project.ProjectId}", _mapper.Map<ProjectModel>(project));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

            return BadRequest();
        }

        [HttpPut("{ProjectId:int}")]
        public async Task<ActionResult<ProjectModel>> Put(int ProjectId,[FromBody] ProjectModel model, Assignment asignModel)
        {
            try
            {
                var odlProject = await _repository.GetProjectByIdAsync(ProjectId);
                if (odlProject == null) return NotFound("Couldn't find the project");

                _mapper.Map(model, odlProject);

                if (model.DateOfCompletion != null)
                {

                }

                if (await _repository.SaveChangesAsync()) return _mapper.Map<ProjectModel>(odlProject);
                
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to update project");
            }
            return BadRequest();
        }
    }
}
