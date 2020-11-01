using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebCoffee.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public float Price { get; set; }
        public bool Completed { get; set; }
        public bool Taken { get; set; }
        public string DateOfTaking { get; set; }
        public string TimeOfTaking { get; set; }
        public ApplicationUser Employee { get; set; }
        public ApplicationUser User { get; set; }
        public List<Purchase> Purchases { get; set; }
    }
}
