using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZSProject.Models
{
    public interface Product
    {
        [PrimaryKey]
        int Id { get; set; }
        string Description { get; set; }
        string Status { get; set; }
        string Name { get; set; }
        double Price { get; set; }
    }
}
