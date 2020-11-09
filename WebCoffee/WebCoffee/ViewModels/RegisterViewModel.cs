using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebCoffee.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "Пароли не совпадают!")]
        [DataType(DataType.Password)]
        [Display(Name = "ConfirmPassword")]
        public string ConfirmPassword { get; set; }

    }
}
