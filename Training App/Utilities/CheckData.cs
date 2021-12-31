using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Training_App.Models;

namespace Training_App.Utilities
{
    public class CheckData
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CheckData(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public  string ChooseImage(Gender gender, string image)
        {
            if (string.IsNullOrWhiteSpace(image))
            {
                image = GetDefaultImage(gender);
            }
            else 
            {
                string path = Path.Combine(_webHostEnvironment.WebRootPath, "images", image);
                if (!File.Exists(path))
                {
                    image = GetDefaultImage(gender);
                }
            }

            return image;
        }

        private static string GetDefaultImage(Gender gender)
        {
            switch (gender)
            {
                case Gender.Male:
                    return "MaleNoImage.jpg";
                case Gender.Female:
                    return "FemaleNoImage.jpg";
                default:
                    return "MaleNoImage.jpg";
            }
        }
    }
}
