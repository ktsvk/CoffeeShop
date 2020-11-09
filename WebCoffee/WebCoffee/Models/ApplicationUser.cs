using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCoffee.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public Gender Gender { get; set; }
        public FileModel Photo { get; set; }
        public string Address { get; set; }
        public int Rating { get; set; }
        public float Discount { get; set; }
        public bool Banned { get; set; }
    }
}
