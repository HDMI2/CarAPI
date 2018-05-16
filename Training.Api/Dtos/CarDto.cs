using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWebApi.Dtos
{
    public class CarDto
    {
        public int Id { get; set; }
        public string FullLabel { get; set; }
        public int Age { get; set; }
    }
}
