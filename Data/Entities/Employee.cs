using System.ComponentModel.DataAnnotations;

namespace FINAL.Data.Entities
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Salary { get; set; }
        public ICollection<Assignment>? Assignments { get; set; }
        public static int weekHours = 40;
    }
}
