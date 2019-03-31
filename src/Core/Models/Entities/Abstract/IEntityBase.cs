using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models.Entities.Abstract
{
    public interface IEntityBase <T>
    {
        T Id { get; set; }
        DateTime CreatedDate { get; }
    }
}
