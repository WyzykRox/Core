using Core.Models.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models.Entities
{
    public class News : IEntityBase<Guid>
    {
        public Guid Id { get; set; }

        public DateTime CreatedDate { get; }
        public string Title { get; set; }
        public string Contents { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
