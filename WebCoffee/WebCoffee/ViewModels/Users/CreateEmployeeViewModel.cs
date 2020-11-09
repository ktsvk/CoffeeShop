using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCoffee.Models;

namespace WebCoffee.ViewModels.Users
{
    public class CreateEmployeeViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

    }
}
