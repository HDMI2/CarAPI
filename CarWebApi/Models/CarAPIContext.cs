using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWebApi.Models
{
    public class CarAPIContext : DbContext
    {

        public DbSet<Car> CarSet { get; set; }

        public async Task<Car> GetCar(int id)
        {
            return await CarSet.FirstOrDefaultAsync(c => c.Id == id);
        }

        public CarAPIContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        public CarAPIContext() : base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string conStr = "Server=DHDEAB-L001;Database=CarAPI; Trusted_Connection=True;";


            optionsBuilder.UseSqlServer(conStr);
        }

    }
}
