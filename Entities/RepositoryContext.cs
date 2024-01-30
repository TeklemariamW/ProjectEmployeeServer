using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>()
                .ToContainer("Projects")
                .HasPartitionKey(p => p.ProjectId)
                .Property(p => p.IsActive).HasDefaultValue(true);

            modelBuilder.Entity<Employee>()
                .ToContainer("Employees")
                .HasPartitionKey(e => e.EmployeeId)
                .Property(e => e.EmpAtWork).HasDefaultValue(true);
        }
    }
}
