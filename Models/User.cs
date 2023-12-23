using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZSProject
{
    [Table("User")]
    public class User
    {
        public string PhoneNumber { get; set; }
        public bool IsClient { get; set; }
        public string Password { get; set; }
    }
}
