using Microsoft.AspNetCore.Identity;
using Core.Models.Entities;
using Core.Models.Entities.Abstract;
using System;
using System.Collections.Generic;

namespace Core.Models.Entities
{
    public class User : IdentityUser<Guid>, IEntityBase<Guid>
    {
        public User() : base() { }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Age { get; set; }

        public DateTime CreatedDate { get; set; }

        public ProfileImage ProfileImage { get; set; }
        public Guid ProfileImageId { get; set; }
        public List<News> News { get; set; }

    }
}
