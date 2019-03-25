using Core.Services.Abstract;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstract
{
    public interface IProfileImageService : IEntityBaseService<ProfileImage, Guid>
    {
        Task<string> GetExtensionAsync(Guid id);
        string[] AllowedExtensions { get; }
        string GetAllowedExtensionsMsg();
        // Task<bool> IsOwnerAsync(Guid userId, Guid id);
        void DeleteImageFile(string src);
        Task UpdateProfileImage(ProfileImage image, Microsoft.AspNetCore.Http.IFormFile file);
        Task<ProfileImage> GetUserProfilePhoto(Guid id);
    }
}
