using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Training_App.Models
{
    public enum Gender
    {
        Unknown = 0,
        Male = 1,
        Female = 2
    }
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Birthday { get; set; }
        public string Headline { get; set; }
        public string CurrentPosition { get; set; }
        public string ImageUrl { get; set; }
        public Gender Gender { get; set; }
    }
}
