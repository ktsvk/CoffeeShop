using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebCoffee.ViewModels
{
    public class SuggestionViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public float Price { get; set; }
        [Required]
        public IFormFile Photo { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Category { get; set; }
    }
}
