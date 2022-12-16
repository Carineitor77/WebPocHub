using Microsoft.EntityFrameworkCore;
using WebPocHub.Models;

namespace WebPocHub.Dal
{
    public class WebPocHubDbContext : DbContext
    {
        public WebPocHubDbContext()
        {
        }

        public WebPocHubDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<Event> Events => Set<Event>();
        public DbSet<Role> Roles => Set<Role>();
        public DbSet<User> Users => Set<User>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; 
                                        Database=WebApiDb;
                                        Trusted_Connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee() { EmployeeId = 1, EmployeeName = "John Mark", 
                    Address = "East Wing, Z/101", City = "London", 
                    Country = "United Kingdom", Zipcode = "473837", 
                    Phone = "+044 73783783", Email = "john.mark@email.com", 
                    Skillsets = "DBA", Avatar = "/images/john-mark.png" },
                new Employee() { EmployeeId = 2, EmployeeName = "Alisha C.", 
                    Address = "Nort Wing, Moon-01", City = "Mumbai", 
                    Country = "India", Zipcode = "367534", Phone = "+91 7865678645", 
                    Email = "alisha.c@email.com", Skillsets = "People Management", 
                    Avatar = "/images/alisha-c.png" },
                new Employee() { EmployeeId = 3, EmployeeName = "Pravinkumar Dabade", 
                    Address = "Suncity, A8/404", City = "Pune", Country = "India", 
                    Zipcode = "411051", Phone = "+044 73783783", 
                    Email = "dabade.pravinkumar@email.com", 
                    Skillsets = "Trainer & Consultant", 
                    Avatar = "/images/dabade-pravinkumar.png" }
            );

            modelBuilder.Entity<Role>().HasData(
                new Role() { RoleId = 1, RoleName = "Employee", 
                    RoleDescription = "Employee of our Organization!" },
                new Role() { RoleId = 2, RoleName = "Hr", 
                    RoleDescription = "Hr of our Organization!" }
            );
        }
    }
}
