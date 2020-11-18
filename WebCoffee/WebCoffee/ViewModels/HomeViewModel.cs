using System.Collections.Generic;
using WebCoffee.Models;

namespace WebCoffee.ViewModels
{
    public class HomeViewModel
    {
        public List<Novetly> Novetlies { get; set; }
        public List<Category> Categories { get; set; }
    }
}
