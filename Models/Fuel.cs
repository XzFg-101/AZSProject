using AZSProject.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZSProject
{
    [Table("Fuel")]
    public class Fuel : Product
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set ; }
        public string Status { get; set ; }
    }
}