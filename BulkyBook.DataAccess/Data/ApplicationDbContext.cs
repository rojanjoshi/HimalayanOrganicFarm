
using BulkyBook.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BulkyBook.DataAccess;
public class ApplicationDbContext :IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

   
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }

  
    public DbSet<Department> Departments { get; set; }
    public DbSet<Designation> Designations { get; set; }

    public DbSet<Employee> Employees { get; set; }

    public DbSet<Salary> Salarys { get; set; }

    public DbSet<Leave> Leaves { get; set; }

    

        public DbSet<CreateLeave> CreateLeaves { get; set; }

    public DbSet<Vaccancy> Vaccancys { get; set; }

}
