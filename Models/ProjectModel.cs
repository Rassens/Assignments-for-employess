using System.ComponentModel.DataAnnotations;
namespace FINAL.Models
{
    public class ProjectModel
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime? DateOfCompletion { get; set; }
        public DateTime DateOfEnd { get; set; }
        public EmployeeModel Employee { get; set; }

        bool Completed { get; set; }
    }
}
