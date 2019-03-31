using Core.Models.Entities;
using Core.Repositories.Abstract;
using Infrastructure.DAO.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repositories
{
    public class NewsRepository : EntityBaseRepository<News, Guid>, INewsRepository
    {
        public NewsRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
