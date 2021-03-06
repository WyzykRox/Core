﻿using Core.Models.Entities;
using Core.Models.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models.Entities
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
