using Models.Entities;
using System;

namespace Core.Repositories.Abstract
{
    public interface IImageRepository : IEntityBaseRepository<Image, Guid>
    {
    }
}
