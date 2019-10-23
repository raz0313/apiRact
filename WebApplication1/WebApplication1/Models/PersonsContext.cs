using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class PersonsContext : DbContext
    {
        public PersonsContext(DbContextOptions options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<persons>().HasData(new persons
            {
                EmployeeId = 1,
                FirstName = "Uncle",
                LastName = "Bob",
              

            }, new persons
            {
                EmployeeId = 2,
                FirstName = "Jan",
                LastName = "Kirsten",
              
            });
        }
        public DbSet<persons> persons { get; set; }
    }
}