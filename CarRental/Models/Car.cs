using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Models
{
    public class Car
    {
        public int Id { get; set; }

        //[BindNever]
        [DisplayName("Baujahr")]
        [Range(1900,2018)]
        [Required]
        public int YearOfConstruction { get; set; }

        //[FromQuery]
        [DisplayName("Marken Name")]
        [Required]
        public string BrandName { get; set; }

        [DisplayName("Model Name")]
        [Required]
        [MaxLength(10)]
        public string ModelName { get; set; }
    }
}
