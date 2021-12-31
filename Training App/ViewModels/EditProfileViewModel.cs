using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Training_App.Models;

namespace Training_App.ViewModels
{
    public class EditProfileViewModel
    {
        public string UserId { get; set; }
        [Required]
        public string FirtName { get; set; }

        [Required]
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        [DataType(DataType.Date)]
        public string Birthday { get; set; }
        public Gender Gender { get; set; }
        public string ImageUrl { get; set; }
        public string CurrentPosition { get; set; }
        public string Headline { get; set; }

        public IFormFile File { get; set; }

    }
}
