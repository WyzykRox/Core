using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Entities.Abstract
{
    public interface IEntityBase <T>
    {
        T Id { get; set; }
        DateTime CreatedDate { get; }
    }
}
