using Microsoft.EntityFrameworkCore;
namespace EFCoreCodeFirstSample.Models
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options)
            : base(options)
        { }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    EmployeeId = 1,
                    FirstName = "Ryan",
                    LastName = "Afzal",
                    DateOfBirth = new DateTime(2003, 1, 18),
                    PhoneNumber = "123-456-7890",
                    Email = "ryanafzal123gmail.com"
                },
                new Employee
                {
                    EmployeeId = 2,
                    FirstName = "Muhammad",
                    LastName = "Taimur",
                    DateOfBirth = new DateTime(2003, 1, 27),
                    PhoneNumber = "098-765-4321",
                    Email = "taimur123@gmail.com"
                }
            );
        }
    }
}
