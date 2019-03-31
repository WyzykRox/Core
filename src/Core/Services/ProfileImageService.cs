using Core.Repositories.Abstract;
using Core.Services;
using Core.Services.Abstract;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class ProfileImageService : EntityBaseService<ProfileImage, Guid>, IProfileImageService
    {
        private readonly IProfileImageRepository _repository;
        private readonly IHostingEnvironment _appEnvironment;

        public ProfileImageService(IProfileImageRepository repository, IHostingEnvironment appEnvironment) : base(repository)
        {
            _repository = repository;
            _appEnvironment = appEnvironment;
        }

        public string[] AllowedExtensions { get; } = {
            ".jpg",
            ".img",
            ".jpeg",
            ".png",
            ".gif"
        };

        public async Task<string> GetExtensionAsync(Guid id)
        {
            var image = await _repository.GetSingleAsync(id);
            return Path.GetExtension(image.Src);
        }

        public string GetAllowedExtensionsMsg()
        {
            string errorMsg = "Only this image extensions are allowed: ";
            foreach (var e in AllowedExtensions)
            {
                if (e != AllowedExtensions[AllowedExtensions.Count() - 1])
                    errorMsg += e + ", ";
                else
                    errorMsg += e;
            }
            return errorMsg;
        }

        public void DeleteImageFile(string src)
        {
            var path = Path.Combine(_appEnvironment.WebRootPath, "images\\userimages", src);
            if (File.Exists(path))
                File.Delete(path);
        }

        public async Task UpdateProfileImage(ProfileImage image, IFormFile file)
        {
            if( image.Src!= "NoProfileImage.png")
                DeleteImageFile(image.Src);
            

            
            var uploads = Path.Combine(_appEnvironment.WebRootPath, "images\\userimages");
            var fileName = image.UserId + Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);
            using (var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            image.Src = fileName;
            await UpdateAsync(image);
        }

        public async Task<ProfileImage> GetUserProfilePhoto(Guid id)
        {
            var r = await FindByAsync(_ => _.UserId == id);
            return r.FirstOrDefault();
        }
    }
}