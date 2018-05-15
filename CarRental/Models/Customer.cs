using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [MaxLength(20)]
        public string Address { get; set; }
    }
}
