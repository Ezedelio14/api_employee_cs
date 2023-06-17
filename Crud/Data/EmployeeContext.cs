using Crud.Models;
using Microsoft.EntityFrameworkCore;

namespace Crud.Data
{
    public class EmployeeContext:DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext>options):base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json",false,true)
                .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("dbconnect"));
        }

        public DbSet<Employee> Employees { get; set;}
    }
}
