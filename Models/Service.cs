using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZSProject
{
    [Table("Sevice")]
    public class Service
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
