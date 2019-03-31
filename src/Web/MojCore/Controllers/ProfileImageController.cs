using System;
using System.Threading.Tasks;
using Core.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Core.Services.Abstract;

namespace Web.MojCore.Controllers
{
    [Authorize(Roles = "User,Admin,Moderator")]
    public class ProfileImageController : Controller
    {
        private readonly IProfileImageService _imageService;
        private readonly UserManager<User> _userManager;

        public ProfileImageController(IProfileImageService imageService, UserManager<User> userManager)
        {
            _imageService = imageService;
            _userManager = userManager;
        }

        // GET: Image
        public async Task<IActionResult> Index()
        {

            Guid.TryParse(_userManager.GetUserId(User), out Guid userId);
            var r = await _imageService.GetUserProfilePhoto(userId);
            if ( r==null)
                    r = new ProfileImage() { UserId = userId };
            return View(r);
        }

        public async Task<IActionResult> Edit()
        {
            Guid.TryParse(_userManager.GetUserId(User), out Guid userId);
            var r = await _imageService.GetUserProfilePhoto(userId);
            return View(r);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Id,UserId")] ProfileImage image, IFormFile file)
        {
            Guid.TryParse(_userManager.GetUserId(User), out Guid userId);
            image = await _imageService.GetUserProfilePhoto(userId);
            if (image != null )
                await _imageService.UpdateProfileImage(image, file);
            return RedirectToAction(nameof(Index));
        }
    }
}