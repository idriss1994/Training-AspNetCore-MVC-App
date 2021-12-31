using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Training_App.Models;

namespace Training_App.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "The first name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The last name is required")]
        public string LastName { get; set; }

        
        [Required(ErrorMessage = "The phone number is required")]
        [Phone(ErrorMessage = "Invalid phone number format")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "The birthday is required")]
        [DataType(DataType.Date)]
        public string Birthday { get; set; }
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
            ErrorMessage = "Invalid email format")]

        public string Email { get; set; }
        [Required(ErrorMessage = "The password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and confirm password do not match")]
        public string ConfirmPassword { get; set; }
    }
}
