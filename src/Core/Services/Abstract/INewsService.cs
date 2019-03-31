using Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Abstract
{
    public interface INewsService : IEntityBaseService<News, Guid>
    {
    }
}
