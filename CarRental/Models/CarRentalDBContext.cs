using Microsoft.EntityFrameworkCore;

namespace CarRental.Models
{
    public class CarRentalDBContext: DbContext
    {
        public DbSet<Car> CarSet { get; set; }
        public CarRentalDBContext(DbContextOptions dbContextOptions): base(dbContextOptions)
        {

        }
    }
}