using FINAL.Data.Entities;
using FINAL.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FINAL.Data
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ProjectContext _context;
        private readonly ILogger<ProjectRepository> _logger;

        public ProjectRepository(ILogger<ProjectRepository> logger, ProjectContext context)
        {
            _logger = logger;
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _logger.LogInformation($"Adding an object of type {entity.GetType()} to the content");
            _context.Add(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _logger.LogInformation($"Removing an object of type {entity.GetType()} to the content");
            _context.Remove(entity);
        }
        public async Task<Project[]> GetAllProjectAsync()
        {
            _logger.LogInformation("Getting all Projects");
            var query = _context.Projects;
            return await query.ToArrayAsync();
        }
        public async Task<Project> GetProjectByIdAsync(int ProjectId)
        {
            _logger.LogInformation("Getting project by ");
            var query = _context.Projects.Where(p => p.ProjectId == ProjectId);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Employee[]> GetAllEmployeesAsync()
        {
            _logger.LogInformation("Getting all employees");
            var query = _context.Employees;
            return await query.ToArrayAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int EmployeeId, bool IncludeAssignments)
        {
            _logger.LogInformation($"Getting employee by EmployeeId: {EmployeeId}");
            var query = _context.Employees.Where(p => p.EmployeeID == EmployeeId);
            if (IncludeAssignments) query = query.Include(t => t.Assignments).ThenInclude(t => t.Project);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Assignment[]> GetAllAssignmentsAsync()
        {
            _logger.LogInformation("Getting all assignments");
            var query = _context.Assignments;
            return await query.ToArrayAsync();

        }

        public async Task<Assignment> GetAssignmentByIdAsync(int AssignmentId)
        {
            _logger.LogInformation("Getting all assignments");
            var query = _context.Assignments.Where(e => AssignmentId == AssignmentId);
            return await query?.FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            _logger.LogInformation("Attempting to save the changes to the content");
            return (await _context.SaveChangesAsync()) >= 0;
        }
    }
}
