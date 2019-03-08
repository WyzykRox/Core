using Microsoft.AspNetCore.Identity;
using Models.Entities;
using Models.Entities.Abstract;
using System;

namespace Core.Models.Entities
{
    public class User : IdentityUser<Guid>, IEntityBase<Guid>
    {
        public User() : base() { }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Age { get; set; }

        public DateTime CreatedDate { get; set; }

        public Image ProfileImage { get; set; }
        public Guid ProfileImageId { get; set; }
    }
}
