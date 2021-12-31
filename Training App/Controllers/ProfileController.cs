using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Training_App.Models;
using Training_App.ViewModels;

namespace Training_App.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProfileController(UserManager<ApplicationUser> userManager,
                                 IWebHostEnvironment webHostEnvironment)
        {
            _userManager = userManager;
            _webHostEnvironment = webHostEnvironment;
        }

        [Route("Profile")]
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Profile()
        {
            var user = await _userManager.GetUserAsync(User);

            UserProfilViewModel model = new UserProfilViewModel
            {
                UserId = user.Id,
                FirtName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Birthday = user.Birthday,
                Gender = user.Gender,
                Headline = user.Headline,
                CurrentPosition = user.CurrentPosition,
                ImageUrl = user.ImageUrl
            };

            return View(model);

        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            var model = new EditProfileViewModel
            {
                UserId = user.Id,
                FirtName = user.FirstName,
                LastName = user.LastName,
                Birthday = user.Birthday,
                PhoneNumber = user.PhoneNumber,
                Gender = user.Gender,
                ImageUrl = user.ImageUrl,
                Headline = user.Headline,
                CurrentPosition = user.CurrentPosition
            };

            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(EditProfileViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(model.UserId);
                if(user == null)
                {
                    return NotFound();
                }
                
                user.FirstName = model.FirtName;
                user.LastName = model.LastName;
                user.Birthday = model.Birthday;
                user.PhoneNumber = model.PhoneNumber;
                user.Gender = model.Gender;
                user.Headline = model.Headline;
                user.CurrentPosition = model.CurrentPosition;
                user.ImageUrl = UploadsFile(model.File, model.ImageUrl);

                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("profile");
                }

                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }

        string UploadsFile(IFormFile file, string oldImage)
        {
            if (file == null)
            {
                return oldImage;
            }
            else
            {
                DeleteOldFile(oldImage);

                string uniqueFileName = Guid.NewGuid() + "_" + file.FileName;

                string fullPath = Path.Combine(_webHostEnvironment.WebRootPath, 
                                                          "images", uniqueFileName);

                using FileStream fileStream = new FileStream(fullPath, FileMode.Create);

                file.CopyTo(fileStream);

                return uniqueFileName;
            }
        }
        void DeleteOldFile(string oldImage)
        {
            if (!string.IsNullOrWhiteSpace(oldImage))
            {
                string webRootPath = _webHostEnvironment.WebRootPath;
                string fullPath = Path.Combine(webRootPath, "images", oldImage);
                System.IO.File.Delete(fullPath);
            }
        }

    }
}
