using Microsoft.EntityFrameworkCore;

namespace CarRental.Models
{
    public class CarRentalDBContext: DbContext
    {
        public DbSet<Car> CarSet { get; set; }
        public DbSet<Customer> CustomerSet { get; set; }

        public CarRentalDBContext(DbContextOptions dbContextOptions): base(dbContextOptions)
        {
            

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EFProviders.InMemory;Trusted_Connection=True;ConnectRetryCount=0");
            }
        }

    }
}