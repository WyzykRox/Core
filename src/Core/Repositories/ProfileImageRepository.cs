using Core.Repositories.Abstract;
using Infrastructure.DAO.Data;
using Models.Entities;
using System;

namespace Core.Repositories
{
    public class ProfileImageRepository : EntityBaseRepository<ProfileImage, Guid>, IProfileImageRepository
    {
        public ProfileImageRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
   
}
