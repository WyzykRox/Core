using Microsoft.AspNetCore.Identity;
using Core.Models.Entities.Abstract;
using System;

namespace Core.Models.Entities
{
    public class Role : IdentityRole<Guid>, IEntityBase<Guid>
    {
        public Role() : base() { }

        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public override string Name { get => base.Name; set => base.Name = value; }
    }
}
