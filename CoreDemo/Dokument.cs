using System;
using System.Collections.Generic;
using System.Text;

namespace CoreDemo
{
    public class Dokument
    {   
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public double Summe { get; set; }

        public override string ToString()
        {

            return $"{nameof(Id)}: {Id}, {nameof(Name)}: {Name}, {nameof(Path)}: {Path}";
        }
    }

}
