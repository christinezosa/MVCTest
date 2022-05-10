using Microsoft.EntityFrameworkCore;
using MVCTest.Models;

namespace MVCTest.Data
{
    public class MVCTestContext : DbContext
    {
        public MVCTestContext (DbContextOptions<MVCTestContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<Shift> Shift { get; set; }
        public DbSet<EmployeeWorksShift> EmployeeWorksShift { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().ToTable("Employee");
            modelBuilder.Entity<Shift>().ToTable("Shift");
            modelBuilder.Entity<EmployeeWorksShift>().ToTable("EmployeeWorksShift");

            modelBuilder.Entity<EmployeeWorksShift>()
                .HasKey(c => new { c.EmployeeId, c.ShiftId });
        }
    }
}
