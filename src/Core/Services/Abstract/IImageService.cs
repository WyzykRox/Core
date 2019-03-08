using Core.Services.Abstract;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Abstract
{
    public interface IImageService : IEntityBaseService<Image, Guid>
    {
        string GetExtension(Guid id);
    }
}
