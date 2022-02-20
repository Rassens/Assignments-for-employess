using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using FINAL.Models;
using FINAL.Data.Entities;
using FINAL.Data.Repositories;


namespace FINAL.Controlers
{
    [Route("api/[controller]")]
    public class AssignmentController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IProjectRepository _repository;

        public AssignmentController(IProjectRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<AssignmentModel[]>> Get()
        {
            try
            {
                var result = await _repository.GetAllAssignmentsAsync();
                return _mapper.Map<AssignmentModel[]>(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }

        [HttpPost]
        public async Task<ActionResult<AssignmentModel>> Post([FromBody] AssignmentModel assignModel)
        {
            try
            {
                var project = await _repository.GetProjectByIdAsync(assignModel.Project.ProjectId);
                if (project == null) return NotFound($"Project with Id: {assignModel.Project.ProjectId} does not exist");

                var employee = await _repository.GetEmployeeByIdAsync(assignModel.Employee.EmployeeID);
                if (project == null) return NotFound($"Employee with Id: {assignModel.Employee.EmployeeID} does not exist");


                var assignment = _mapper.Map<Assignment>(assignModel);

                assignment.Project =  project;
                assignment.Employee = employee;


                _repository.Add(assignment);
                if (await _repository.SaveChangesAsync())
                    return Created($"/api/{assignment.AssigmentId}", _mapper.Map<AssignmentModel2>(assignment));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
            return BadRequest();
        }
    }
}
 