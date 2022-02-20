using System.ComponentModel.DataAnnotations;
namespace FINAL.Models
{
    public enum Role
    {
        Developer,
        Analyst,
        Tester,
        ProjectManager,
        SoftwareArchitect
    }

    public class AssignmentModel
    {
        public int AssigmentId { get; set; }
        public Role Role { get; set; }
        public ProjectModel Project { get; set; }
        public EmployeeModel Employee { get; set; }
    }
    public class AssignmentModel2
    {
        public int AssigmentId { get; set; }
        public Role Role { get; set; }
        public int EmployeeEmployeeID { get; set; }
        public int ProjectProjectId { get; set; }

        
    }
}
