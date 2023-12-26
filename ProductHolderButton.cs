using AZSProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AZSProject
{
    public class ProductHolderButton : Button
    {
        public IProduct Product { get; set; }
    }
}
