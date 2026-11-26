using Microsoft.EntityFrameworkCore;
using EmployeeManagementApi.Models;
namespace EmployeeManagementApi.Data
{
    public class EmployeeDbContext : DbContext
    {
        //Parameterised Constructor shall call the base version's constructor. DBContextOptions contains the info required for configuring the Context taking from the connectionstring set in the appsettings.json file. This constructor is required for the dependency injection to work properly.
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
        {
            
        }

        public DbSet<Employee> Employees { get; set; } = null!; //Represents the Employee Table of the database that gets created when the App runs for the first time.  This object shall be used for performing all the CRUD operations required for the application. 

        //Db level validation of the Business rule.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasIndex(e => e.Email).IsUnique(); //This line creates a unique index on the Email column of the Employee table. This ensures that no two employees can have the same email address in the database. If an attempt is made to insert or update an employee with an email that already exists, a DbUpdateException will be thrown, which can be caught and handled appropriately in the service layer.
        }
        //Open the Package Manager console and run the following commands to create the database and the Employee table based on the schema defined in the DbContext and the models.
        //PM> Add-Migration AddUniqueEmail
        //PM> Update-Database
    }
}
