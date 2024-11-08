using EmployeeDetailsEntity.Models.emp;
using Microsoft.EntityFrameworkCore;

namespace LinqEmployeeDetails.Data
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IConfiguration _configuration;


        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Employee> employees { get; set; }
        public DbSet<EmployeeDetails> employeeDetails { get; set; }
    }
}
