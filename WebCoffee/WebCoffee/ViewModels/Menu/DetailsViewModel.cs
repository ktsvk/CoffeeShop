using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCoffee.Models;

namespace WebCoffee.ViewModels.Menu
{
    public class DetailsViewModel
    {
        public Product Product { get; set; }
        public List<Product> Similar { get; set; }
        public List<Product> Latest { get; set; }
        public List<Product> Popular { get; set; }
    }
}
