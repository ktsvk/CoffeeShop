using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebCoffee.Models;

namespace WebCoffee.ViewModels.Orders
{
    public class CreateOrderViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public bool Delivery { get; set; }
        public IEnumerable<Bag> Bags { get; set; }
    }
}
