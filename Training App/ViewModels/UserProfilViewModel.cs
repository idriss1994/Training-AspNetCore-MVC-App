using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Training_App.Models;

namespace Training_App.ViewModels
{
    public class UserProfilViewModel
    {
        public string UserId { get; set; }
        public string FirtName { get; set; }
        public string LastName { get; set; }
        public string Birthday { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }
        public string Headline { get; set; }
        public string CurrentPosition { get; set; }
        public string ImageUrl { get; set; }
    }
}
