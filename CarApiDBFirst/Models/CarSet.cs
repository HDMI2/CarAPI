using System;
using System.Collections.Generic;

namespace CarApiDBFirst.Models
{
    public partial class CarSet
    {
        public int Id { get; set; }
        public int BrandName { get; set; }
        public string ModelName { get; set; }
        public int YearOfConstruction { get; set; }
        public Guid Idnummer { get; set; }
    }
}
