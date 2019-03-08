using Core.Repositories.Abstract;
using Infrastructure.DAO.Data;
using Models.Entities;
using System;

namespace Core.Repositories
{
    public class ImageRepository : EntityBaseRepository<Image, Guid>, IImageRepository
    {
        public ImageRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
