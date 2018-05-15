using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsApi.Models
{
    public class CarAPIContext : DBContext
    {
        public CarAPIContext(DBContextOptions options) : base(options)
        {
        }
    }
}
