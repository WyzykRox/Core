using Core.Models.Entities;
using Models.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Entities
{
    public class ProfileImage : IEntityBase<Guid>
    {
        public Guid Id { get; set; }

        public DateTime CreatedDate { get; }

        public string Src { get; set; } = "NoProfileImage.png";


        public User User { get; set; }
        public Guid UserId { get; set; }
    }
}
