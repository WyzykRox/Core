using Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repositories.Abstract
{
    public interface INewsRepository : IEntityBaseRepository<News, Guid>
    {
    }
}
