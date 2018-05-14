using Microsoft.EntityFrameworkCore;

namespace CarRental.Models
{
    internal class CarRentalDBContext: DbContext
    {
        public DbSet<Car> CarSet { get; set; }
        public CarRentalDBContext(DbContextOptions dbContextOptions): base(dbContextOptions)
        {

        }
    }
}