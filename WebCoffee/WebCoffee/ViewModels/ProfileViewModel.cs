using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCoffee.Models;

namespace WebCoffee.ViewModels
{
    public class ProfileViewModel
    {
        public ApplicationUser User { get; set; }
        public int NotificationsCount { get; set; }
        public List<Order> Orders { get; set; }
    }
}
