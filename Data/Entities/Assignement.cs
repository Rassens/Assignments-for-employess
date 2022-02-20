using System.ComponentModel.DataAnnotations;

namespace FINAL.Data.Entities
{
    public class Assignment
    {
        [Key]
        public int AssigmentId { get; set; }
        public string Role { get; set; }
        public Project Project { get; set; }
        public Employee Employee { get; set; }
        public static bool? Completed { get; set; }
    }
}
