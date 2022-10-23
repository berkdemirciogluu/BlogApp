using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.WebUI.Models
{
    public class UserSignUpViewModel
    {
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Please Enter Full Name")]
        public string NameSurname { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please Enter Password")]
        public string Password { get; set; }

        [Display(Name = "Try Again!")]
        [Required(ErrorMessage = "Invalid Password or Name")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Please Enter Email")]
        public string Email { get; set; }

        [Display(Name = "Username")]
        [Required(ErrorMessage = "Please Enter Username")]
        public string Username { get; set; }
    }
}
