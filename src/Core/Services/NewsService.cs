using Core.Models.Entities;
using Core.Repositories.Abstract;
using Core.Services.Abstract;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services
{
    public class NewsService : EntityBaseService<News, Guid>, INewsService
    {

        private readonly INewsRepository _repository;
        private readonly IHostingEnvironment _appEnvironment;

        public NewsService(INewsRepository repository, IHostingEnvironment appEnvironment) : base(repository)
        {
            _repository = repository;
            _appEnvironment = appEnvironment;
        }
    }
}
