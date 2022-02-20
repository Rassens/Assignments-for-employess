using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using FINAL.Models;
using FINAL.Data.Entities;
using FINAL.Data.Repositories;


namespace FINAL.Controlers
{
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IProjectRepository _repository;

        public EmployeeController(IProjectRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<EmployeeModel[]>> Get()
        {
            try
            {
                var result = await _repository.GetAllEmployeesAsync();
                return _mapper.Map<EmployeeModel[]>(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }


        [HttpGet("{EmployeeId:int}")]
        public async Task<ActionResult<EmployeeModel>> Get(int EmployeeId)
        {
            try
            {
                var employee = await _repository.GetEmployeeByIdAsync(EmployeeId);
                if (employee == null) return NotFound($"Could not find a employee with id of {EmployeeId}");
                return _mapper.Map<EmployeeModel>(employee);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to get Project");
            }
        }

        public async Task<ActionResult<EmployeeModel>> Post([FromBody] EmployeeModel model)
        {
            try
            {
                var existing = await _repository.GetEmployeeByIdAsync(model.EmployeeID);
                if (existing != null) return BadRequest("Employee exist");

                var employee = _mapper.Map<Employee>(model);

                _repository.Add(employee);
                if (await _repository.SaveChangesAsync())
                    return Created($"/api/{employee.EmployeeID}", _mapper.Map<EmployeeModel>(employee));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
            return BadRequest();
        }
    }
}
