using System.ComponentModel.DataAnnotations;

namespace FINAL.Data.Entities
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime? DateOfCompletion { get; set; }
        public DateTime DateOfPresumedEnd { get; set; }
    }
}
