using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZSProject
{
    [Table("Fuel")]
    public class Fuel
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }
}