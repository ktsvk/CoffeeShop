using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebCoffee.Models
{
    public class Suggestion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public FileModel Photo { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public IdentityUser User { get; set; }

    }
}
