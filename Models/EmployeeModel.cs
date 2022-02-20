using FINAL.Data.Entities;
using System.ComponentModel.DataAnnotations;


namespace FINAL.Models
{
    public class EmployeeModel
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Salary { get; set; }
        public ICollection<Assignment>? Assignments { get; set; }
    }
}
