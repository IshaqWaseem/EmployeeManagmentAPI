using Microsoft.EntityFrameworkCore;
using EmployeeManagmentAPI.Models;

namespace EmployeeManagmentAPI.Data
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options) { }
        public DbSet<Employee> Employees { get; set; }
    }
}
