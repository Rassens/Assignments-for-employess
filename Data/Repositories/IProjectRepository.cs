using FINAL.Data.Entities;

namespace FINAL.Data.Repositories
{
    public interface IProjectRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<Project[]> GetAllProjectAsync();
        Task<Project> GetProjectByIdAsync(int ProjectId);
        Task<Employee[]> GetAllEmployeesAsync();
        Task<Employee> GetEmployeeByIdAsync(int EmployeeId, bool IncludeAssignments = false);
        Task<Assignment[]> GetAllAssignmentsAsync();
        Task<Assignment> GetAssignmentByIdAsync(int AssignmentId);
        Task<bool> SaveChangesAsync();
    }
}
