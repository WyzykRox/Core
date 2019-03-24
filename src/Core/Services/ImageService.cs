using Core.Repositories.Abstract;
using Core.Services;
using Models.Entities;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class ImageService : EntityBaseService<Image, Guid>, IImageService
    {
        public ImageService(IEntityBaseRepository<Image, Guid> repository) : base(repository)
        {
        }

        public string GetExtension(Guid id)
        {
            // TO DO
            // wez sciezke do pliku
            // wyciagnij po kropce
            // zwroc
            throw new NotImplementedException();
        }
    }
}