using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarsApi.Models
{
    public class Car
    {
        public int Id { get; set; }

        [Required]
        public BrandNames BrandName { get; set; }

        [Required]
        [MaxLength(10)]
        public string ModelName { get; set; }

        [Range(1900,2018)]
        public int YearOfConstruction { get; set; }
    }

}
