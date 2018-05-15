using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Training.Api.Models
{
    public class CarAPIContext : DbContext
    {
        public DbSet<Car> CarSet { get; set; }

        public CarAPIContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }
    }
}
