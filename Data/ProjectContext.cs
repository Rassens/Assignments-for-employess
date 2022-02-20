using Microsoft.EntityFrameworkCore;
using FINAL.Data.Entities;

namespace FINAL.Data
{
    public class ProjectContext : DbContext
    {
        private readonly IConfiguration _config;
        //private readonly DbContextOptions _options;

        public ProjectContext(DbContextOptions options, IConfiguration config) : base(options)
        {
            _config = config;
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("CodeCamp"));
        }
    }
}
