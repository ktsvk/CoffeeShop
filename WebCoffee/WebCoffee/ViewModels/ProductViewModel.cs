using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebCoffee.ViewModels
{
    public class ProductViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(1, 100)]
        public int Price { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public IFormFile Photo { get; set; }
        [Required]
        public string Category { get; set; }
    }
}
