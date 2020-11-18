using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebCoffee.ViewModels.Products
{
    public class CreateBagItemViewModel
    {
        public int Id { get; set; }
        public int Portion { get; set; }
        [Range(1, 20)]
        public int Amount { get; set; }
    }
}
